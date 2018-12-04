using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] float carSpeed;

    public void Update()
    {
        transform.Translate(-transform.right * carSpeed * Time.deltaTime);
    }
}
