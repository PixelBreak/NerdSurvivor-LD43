using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    [SerializeField] Slider slider;
    [SerializeField]float seconds = 30;
    [SerializeField] Animator anim;
    bool startGame = true;
    [SerializeField] TPSController tpsController;
    [SerializeField] AudioSource tickSource;
   

    private void Start()
    {
        slider.maxValue = seconds;
    }
    private void Update()
    {
        if (!startGame)
            return;

        seconds -= Time.deltaTime;
        slider.value = seconds;
        if(slider.value <= 0)
        {
            Debug.Log("StartGame");
            StartCoroutine(LoadGameplay());
            tickSource.Stop();
        }
    }

    private IEnumerator LoadGameplay()
    {
        startGame = false;
        tpsController.canControl = false;
        anim.Play("GetReady");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }

}
