using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

	public enum ItemType
    {
        PS4,
        Xbox,
        GalaxyS7,
        UnchartedDisk,
        Knack2Disk,
        Mask,
        Ring,
        LightSaber,
        Gun

    };
    public ItemType itemType;
    public ItemHolder itemHolder;
    public TextMeshProUGUI countText;
    public int count;

    Button b;

    private void Start()
    {
        b = GetComponent<Button>();
        b.onClick.AddListener(() => OnClickItemButton());
    }


    public void OnClickItemButton()
    {
        if (OnHand.instance.currentHand >= OnHand.instance.maxHand)
        {
            Debug.Log("CANT CARRY ANY MORE");
            AudioManager.instance.PlayFullHand();
            return;
        }
        
       OnHand.instance.currentHand++;
       if (itemType == ItemType.PS4)
       {
                count--;
            if (count <= 0)
                Destroy(gameObject);

             itemHolder.ps4--;
            countText.text = "x" + count;
            OnHand.instance.ps4++;
            itemHolder.RemovePS4();
            }
        if (itemType == ItemType.Xbox)
        {

            count--;
            if (count <= 0)
                Destroy(gameObject);
            itemHolder.xbox--;
            countText.text = "x" + count;
            OnHand.instance.xbox++;
            itemHolder.RemoveXbox();
        }
        if (itemType == ItemType.GalaxyS7)
        {
            count--;
            if (count <= 0)
                Destroy(gameObject);
            itemHolder.galaxyS7--;
            OnHand.instance.galaxyS7++;
            countText.text = "x" + count;
            itemHolder.RemoveGalaxyS7();
        }

        if (itemType == ItemType.UnchartedDisk)
        {
            count--;
            if (count <= 0)
                Destroy(gameObject);
            itemHolder.unchartedDisk--;
            OnHand.instance.uncharted++;
            countText.text = "x" + count;
            itemHolder.RemoveUncharted();
        }
        if (itemType == ItemType.Knack2Disk)
        {
            count--;
            if (count <= 0)
                Destroy(gameObject);
            itemHolder.knack2Disk--;
            OnHand.instance.knack++;
            countText.text = "x" + count;
            itemHolder.RemoveKnack();
        }
        if (itemType == ItemType.Mask)
        {
            count--;
            if (count <= 0)
                Destroy(gameObject);
            itemHolder.mask--;
            OnHand.instance.mask++;
            countText.text = "x" + count;
            itemHolder.RemoveMask();
        }
        if (itemType == ItemType.Ring)
        {
            count--;
            if (count <= 0)
                Destroy(gameObject);
            itemHolder.ring--;
            OnHand.instance.ring++;
            countText.text = "x" + count;
            itemHolder.RemoveRing();
        }
        if (itemType == ItemType.LightSaber)
        {
            count--;
            if (count <= 0)
                Destroy(gameObject);
            itemHolder.lightsaber--;
            OnHand.instance.lightSaber++;
            countText.text = "x" + count;
            itemHolder.RemoveLightSabar();
        }
        /*if (itemType == ItemType.Gun)
        {
            count--;
            if (count <= 0)
                Destroy(gameObject);
            itemHolder.boobafeetGun--;
            OnHand.instance.++;
            countText.text = "x" + count;
            itemHolder.RemoveGun();
        }*/


        OnHand.instance.PrintDebugText(OnHand.instance.currentHand);

    }



}
