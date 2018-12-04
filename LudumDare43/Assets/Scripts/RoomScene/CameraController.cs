using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Transform holder;
    [SerializeField] Transform _camera;
    public bool canOrbit = true;
  //  [SerializeField] Vector3 offset;

  
    Vector3 desiredPos;

    Transform _XForm_Parent;

    protected Vector3 _LocalRotation;
    public float MouseSensitivity = 4f;

    public float OrbitDampening = 10f;

    private void Start()
    {

        holder.position = Vector3.zero;
        _XForm_Parent = holder;
        _LocalRotation = _XForm_Parent.transform.localEulerAngles;

    }

    /* private void FixedUpdate()
     {
         //desiredPos = target.position + target.up * offset.y + target.right * offset.x - target.forward * offset.z;
         desiredPos = target.position + offset;

         this._XForm_Parent.position = Vector3.Lerp(this._XForm_Parent.position, desiredPos, smoothness * Time.deltaTime);
         //transform.LookAt(target.position);

     }*/

    private void FixedUpdate()
    {
        holder.transform.position = Vector3.Lerp(holder.transform.position, target.position, 5 * Time.deltaTime);
    }
    void LateUpdate()
    {

        if (!canOrbit)
            return;

        //Rotation of the Camera based on Mouse Coordinates
        if (Input.GetAxis("Mouse X") != 0)
        {
            _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(0, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);
        // _camera.rotation = _camera.rotation * _XForm_Parent.rotation;
        _camera.LookAt(holder.position);


    }
}

