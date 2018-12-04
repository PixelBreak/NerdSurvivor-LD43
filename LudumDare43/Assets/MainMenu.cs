using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {



    private void Start()
    {
        Invoke("LoadScene", 3);
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
	
}
