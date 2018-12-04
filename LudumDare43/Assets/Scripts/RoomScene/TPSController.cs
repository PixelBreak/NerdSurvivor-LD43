using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour {

    public bool canControl = false;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] Animator anim;

    Rigidbody rb;
    float h, v;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!canControl)
            return;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxis("Vertical");

        transform.Rotate(0, rotSpeed * h * Time.deltaTime, 0);

    }
    private void FixedUpdate()
    {
        if (!canControl)
        {
            anim.SetBool("Walk", false);
            return;
        }

        if(Mathf.Abs(v) > 0)
        {
            anim.SetBool("Walk",true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.deltaTime * v);
    }
}
