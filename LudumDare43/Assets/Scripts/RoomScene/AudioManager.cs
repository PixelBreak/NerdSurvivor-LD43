using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField] AudioSource fullHandSource;
    [SerializeField] AudioSource putInBoxSound;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void PlayFullHand()
    {
        fullHandSource.Play();
    }
    public void PlayPutInBox()
    {
        putInBoxSound.Play();
    }
}
