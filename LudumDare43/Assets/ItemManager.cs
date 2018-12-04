using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Animator[] buttonAnim;
    [SerializeField] StoreManager storeManager;
    [SerializeField] Button[] buttons = new Button[8];

    public static int ps4, xbox, s7, joystick, knack, lightSaber, mask, ring;
    public TextMeshProUGUI ps4Text, xboxText, s7Text, joystickText, knackText, lightSaberText, maskText, ringText;

    public int currentIndex = 0;
   [SerializeField] private List<int> disabledButton;

    private void Start()
    {
       
        ps4 = storeManager.ps4Amount;
        xbox = storeManager.xboxAmount;
        s7 = storeManager.galaxyS7Amount;
        joystick = storeManager.joystickAmount;
        knack = storeManager.knackAmount;
        lightSaber = storeManager.lightSaberAmount;
        mask = storeManager.maskAmount;
        ring = storeManager.ringAmount;


        ps4Text.text = "x" + ps4.ToString();
        xboxText.text = "x" + xbox.ToString();
        s7Text.text = "x" + s7.ToString();
        joystickText.text = "x" + joystick.ToString();
        knackText.text = "x" + knack.ToString();
        lightSaberText.text = "x" + lightSaber.ToString();
        maskText.text = "x" + mask.ToString();
        ringText.text = "x" + ring.ToString();

        for(int i = 0; i < buttonAnim.Length; i++)
        {
            buttons[i] = buttonAnim[i].gameObject.GetComponent<Button>();
        }


        if (ps4 <= 0)
        {
            buttonAnim[0].SetTrigger("Disabled");
            disabledButton.Add(0);
        }

        if (xbox <= 0)
        {
            buttonAnim[1].SetTrigger("Disabled");
            disabledButton.Add(1);
        }

        if (s7 <= 0)
        {
            buttonAnim[2].SetTrigger("Disabled");
            disabledButton.Add(2);
        }

        if (joystick <= 0)
        {
            buttonAnim[3].SetTrigger("Disabled");
            disabledButton.Add(3);
        }

        if (knack <= 0)
        {
            buttonAnim[4].SetTrigger("Disabled");
            disabledButton.Add(4);
        }

        if (lightSaber <= 0)
        {
            buttonAnim[5].SetTrigger("Disabled");
            disabledButton.Add(5);
        }


        if (mask <= 0)
        {
            buttonAnim[6].SetTrigger("Disabled");
            disabledButton.Add(6);
        }

        if (ring <= 0)
        {
            buttonAnim[7].SetTrigger("Disabled");
            disabledButton.Add(7);
        }

        for(int j = 0; j < buttons.Length; j++)
        {
            if (disabledButton.Contains(j) == false)
            {
                currentIndex = j;
                break;
            }
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentIndex = 1;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            currentIndex = 2;

        if (Input.GetKeyDown(KeyCode.Alpha4))
            currentIndex = 3;

        if (Input.GetKeyDown(KeyCode.Alpha5))
            currentIndex = 4;

        if (Input.GetKeyDown(KeyCode.Alpha6))
            currentIndex = 5;

        if (Input.GetKeyDown(KeyCode.Alpha7))
            currentIndex = 6;

        if (Input.GetKeyDown(KeyCode.Alpha8))
            currentIndex = 7;


        buttonAnim[currentIndex].SetTrigger("Pressed");
        for (int i = 0; i < buttonAnim.Length; i++)
        {
            if (i != currentIndex && disabledButton.Contains(i) == false)
            {
                buttonAnim[i].SetTrigger("Normal");
            }
        }
    }

    public void OnClickItem(int index)
    {
        currentIndex = index;
    }

    public void ReduceItem(int itemIndex)
    {
        if(itemIndex == 0)
        {
            ps4--;
            ps4Text.text = "x" + ps4.ToString();
        }
        if (itemIndex == 1)
        {
            xbox--;
            xboxText.text = "x" + xbox.ToString();
        }
        if (itemIndex == 2)
        {
            s7--;
            s7Text.text = "x" + s7.ToString();
        }
        if (itemIndex == 3)
        {
            joystick--;
            joystickText.text = "x" + joystick.ToString();
        }
        if (itemIndex == 4)
        {
            knack--;
            knackText.text = "x" + knack.ToString();
        }
        if (itemIndex == 5)
        {
            lightSaber--;
            lightSaberText.text = "x" + lightSaber.ToString();
        }
        if (itemIndex == 6)
        {
            mask--;
            maskText.text = "x" + mask.ToString();
        }
        if (itemIndex == 7)
        {
            ring--;
            ringText.text = "x" + ring.ToString();
        }

        #region CheckIfZero
        if (ps4 <= 0)
        {
            buttonAnim[0].SetTrigger("Disabled");
            disabledButton.Add(0);
        }

        if (xbox <= 0)
        {
            buttonAnim[1].SetTrigger("Disabled");
            disabledButton.Add(1);
        }

        if (s7 <= 0)
        {
            buttonAnim[2].SetTrigger("Disabled");
            disabledButton.Add(2);
        }

        if (joystick <= 0)
        {
            buttonAnim[3].SetTrigger("Disabled");
            disabledButton.Add(3);
        }

        if (knack <= 0)
        {
            buttonAnim[4].SetTrigger("Disabled");
            disabledButton.Add(4);
        }

        if (lightSaber <= 0)
        {
            buttonAnim[5].SetTrigger("Disabled");
            disabledButton.Add(5);
        }


        if (mask <= 0)
        {
            buttonAnim[6].SetTrigger("Disabled");
            disabledButton.Add(6);
        }

        if (ring <= 0)
        {
            buttonAnim[7].SetTrigger("Disabled");
            disabledButton.Add(7);
        }
        #endregion
        
        
        
        
        
        
        
    }
}



