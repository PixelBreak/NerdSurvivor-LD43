using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] Transform gunPoint;
    [SerializeField] Transform spawnPoint;
    [SerializeField] AudioSource bulletSource;
    [SerializeField] float gunRotSpeed = 5;
    [SerializeField] float gunAngleMin = 70;
    [SerializeField] float gunAngleMax = 26;
    [SerializeField] CameraShake cameraShake;
    float h;
    protected Vector3 _LocalRotation;
    public float MouseSensitivity = 4f;

    public float OrbitDampening = 10f;


    [SerializeField] float fireRate = 0.2f;
    private float nextFire;
    private void Update()
    {
        if (GameManager.instance.isGameOver)
            return;

        if(Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isShooting", true);
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject b = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                b.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * bulletForce);
                Destroy(b.gameObject, 2);
                float p = Random.Range(1.6f, 1.8f);
                bulletSource.pitch = p;
                bulletSource.Play();
                cameraShake.shakeDuration = 0.3f;
            }
        }
        else
            anim.SetBool("isShooting", false);

        h = Input.GetAxis("Horizontal");
        //  gunPoint.transform.Rotate(Vector3.up, h * gunRotSpeed * Time.deltaTime);
        //gunPoint.transform.localRotation = Quaternion.Euler(gunPoint.transform.localRotation.x,  Mathf.Clamp(gunPoint.transform.localRotation.y, -90, 90), gunPoint.transform.localRotation.z);
        /* var rot = gunPoint.transform.localEulerAngles;
         rot.Set(0f, h * gunRotSpeed * Time.deltaTime, 0f);
         gunPoint.transform.localEulerAngles = rot + gunPoint.transform.localEulerAngles;
        
        */
        ////WORKS!!
         Vector3 rot = gunPoint.transform.rotation.eulerAngles + new Vector3(0, h * gunRotSpeed * Time.deltaTime, 0f); //use local if your char is not always oriented Vector3.up
         rot.y = ClampAngle(rot.y, -gunAngleMin, gunAngleMax);

         gunPoint.transform.eulerAngles = rot;

       /* if (Input.GetAxis("Mouse X") != 0)
        {
            _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
        }

        print(_LocalRotation.x);
        _LocalRotation.x = Mathf.Clamp(_LocalRotation.x, -gunAngleMin, gunAngleMax);

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(0, _LocalRotation.x, 0);
        gunPoint.transform.rotation = Quaternion.Lerp(gunPoint.transform.rotation, QT, Time.deltaTime * OrbitDampening);
        //float y = ClampAngle(gunPoint.transform.rotation.y, -gunAngleMin, gunAngleMax);
        //gunPoint.transform.eulerAngles = new Vector3(gunPoint.transform.eulerAngles.x, y, gunPoint.transform.eulerAngles.z);
        */
    }

    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }

}
