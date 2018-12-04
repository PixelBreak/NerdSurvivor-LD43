using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBox : MonoBehaviour {

    public ParticleSystem part;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            part.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            part.Stop();
    }
}
