using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [SerializeField] Animator deathPanelAnim;
    [SerializeField] Animator gameOverText;
    [SerializeField] Animator zombiesGotMe;
    [Space]
    [SerializeField] Slider distanceSlider;
    [SerializeField] float travelSpeed = 3;
    [Space]
    [SerializeField] AudioSource engine;
    [SerializeField] AudioSource exp;
    [SerializeField] AudioSource dieSound;
    [Space]
    [SerializeField] Slider nerdMeter;
    [SerializeField] int maxNerdness = 79;
    [SerializeField] StoreManager storeManager;
    [SerializeField] GameObject helpPanel;
    [SerializeField] Animator winPanelAnim;
    [SerializeField] TextMeshProUGUI winPercent;
    
    float dist = 0;

    public bool isGameOver = false;
    private bool win = false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Time.timeScale = 0;
    }

    private void Start()
    {
        nerdMeter.wholeNumbers = true;
        nerdMeter.maxValue = maxNerdness;
        nerdMeter.value = storeManager.totalInBox;
    }

    private void Update()
    {
        if (isGameOver)
            return;

        if (win)
            return;

        dist += travelSpeed * Time.deltaTime;
        distanceSlider.value = dist;
        if(dist >= distanceSlider.maxValue)
        {
            win = true;
            WIN();
            Time.timeScale = 0;
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        deathPanelAnim.Play("DeathPanelOnScreen");
        gameOverText.Play("GameOverText");
        zombiesGotMe.Play("ZombiesGotMe");
        Invoke("LoadLevel_0", 2);
    }

    public void ReduceNerdMeter(int itemIndex)
    {

        storeManager.totalInBox--;
        nerdMeter.value = storeManager.totalInBox;
    }

    private void LoadLevel_0()
    {
        Application.LoadLevel(0);
    }

    public void OK()
    {
        helpPanel.SetActive(false);
        Time.timeScale = 1;
        engine.Play();

    }

    private void WIN()
    {
        winPanelAnim.Play("WinPanel");
        float total = ItemManager.ps4
            + ItemManager.xbox
            + ItemManager.s7
            + ItemManager.joystick
            + ItemManager.knack
            + ItemManager.lightSaber
            + ItemManager.mask
            + ItemManager.ring;

        print("TOTAL NOW:  " + total);


        winPercent.text = "You managed to save " + (total / 79.0f)  * 100.0f + "% of your nerdy stuffs";
    }

    public void PlayExp()
    {
        if (exp.isPlaying)
            exp.Stop();

        exp.Play();
    }

    public void PlayDieSound()
    {
        float p = Random.Range(1.13f, 1.3f);
        dieSound.pitch = p;
        dieSound.Play();

    }
}
