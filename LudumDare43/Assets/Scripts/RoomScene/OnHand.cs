using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnHand : MonoBehaviour {

    public static OnHand instance;
    public int maxHand = 3;
    public StoreManager storeManager;
    public  int ps4, xbox, galaxyS7,uncharted,knack,lightSaber,mask,ring;
    public TextMeshProUGUI debugText;
    public  int currentHand = 0;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


        storeManager.ps4Amount = 0;
        storeManager.xboxAmount = 0;
        storeManager.galaxyS7Amount = 0;
        storeManager.joystickAmount = 0;
        storeManager.knackAmount = 0;
        storeManager.lightSaberAmount = 0;
        storeManager.maskAmount = 0;
        storeManager.ringAmount = 0;
        storeManager.totalInBox = 0;
        currentHand = 0;
    }

    public void StoreToBox()
    {
        storeManager.ps4Amount += ps4;
        storeManager.xboxAmount += xbox;
        storeManager.galaxyS7Amount += galaxyS7;
        storeManager.joystickAmount += uncharted;
        storeManager.knackAmount += knack;
        storeManager.lightSaberAmount += lightSaber;
        storeManager.maskAmount += mask;
        storeManager.ringAmount += ring;

        storeManager.totalInBox = 0;

        storeManager.totalInBox = (storeManager.ps4Amount 
            + storeManager.xboxAmount 
            + storeManager.galaxyS7Amount
            + storeManager.joystickAmount
            + storeManager.knackAmount
            + storeManager.lightSaberAmount
            + storeManager.maskAmount
            + storeManager.ringAmount);
        currentHand = 0;
        ps4 = 0;
        xbox = 0;
        galaxyS7 = 0;
        uncharted = 0;
        knack = 0;
        lightSaber = 0;
        mask = 0;
        ring = 0;




    }

    public void PrintDebugText(int onHandCount)
    {
        debugText.text = "On Hand : " + onHandCount + "/"+maxHand;
    }
}
