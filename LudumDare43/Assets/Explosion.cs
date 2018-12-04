using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float damage = 80;
    public float explosionForce = 100;
    public float radius = 10;
    public float upForce = 1;
    public GameObject expParticle;

    private Rigidbody rb;

    GameObject child;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("Explode", 2f);
        child = transform.GetChild(0).gameObject;
    }



    private void Explode()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider c in col)
        {
           // Rigidbody _rb = c.GetComponent<Rigidbody>();
            Zombie z = c.GetComponent<Zombie>();
           /* if (_rb)
            {
                _rb.AddExplosionForce(explosionForce, transform.position, radius, upForce, ForceMode.Impulse);
            }*/
            if (z)
            {
                z.TakeDamage(damage);
            }
        }
        Destroy(Instantiate(expParticle, transform.position,Quaternion.identity),2);
        child.SetActive(false);
        Destroy(gameObject, 4);
        GameManager.instance.PlayExp();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
