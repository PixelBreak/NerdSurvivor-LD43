using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemHolderUI : MonoBehaviour {

    [SerializeField] GameObject ps4Panel;
    [SerializeField] GameObject xboxPanel;
    [SerializeField] GameObject galaxyS7;
    [SerializeField] GameObject unchartedPanel;
    [SerializeField] GameObject knackPanel;
    [SerializeField] GameObject lightSaberPanel;
    [SerializeField] GameObject boobafeetPanel;
    [SerializeField] GameObject maskPanel;
    [SerializeField] GameObject ringPanel;

    [SerializeField] CameraController cameraController;
    [SerializeField] TPSController tPSController;
    [SerializeField] Transform holder;

    [SerializeField] TextMeshProUGUI debugText;

	public void CreateList(ItemHolder itemHolder)
    {
        if(itemHolder.ps4 > 0)
        {
            GameObject p = Instantiate(ps4Panel, holder);
            ItemButton b = p.GetComponent<ItemButton>();
            b.itemHolder = itemHolder;
            b.count = itemHolder.ps4;
            b.countText.text = "x" + itemHolder.ps4.ToString();
        }
        if(itemHolder.xbox > 0)
        {
            GameObject x = Instantiate(xboxPanel, holder);
            ItemButton b = x.GetComponent<ItemButton>();
            b.itemHolder = itemHolder;
            b.count = itemHolder.xbox;
            b.countText.text = "x" + itemHolder.xbox.ToString();
        }

        if(itemHolder.galaxyS7 > 0)
        {
            GameObject x = Instantiate(galaxyS7, holder);
            ItemButton b = x.GetComponent<ItemButton>();
            b.itemHolder = itemHolder;
            b.count = itemHolder.galaxyS7;
            b.countText.text = "x" + itemHolder.galaxyS7.ToString();
        }
        if (itemHolder.boobafeetGun > 0)
        {
            GameObject x = Instantiate(boobafeetPanel, holder);
            ItemButton b = x.GetComponent<ItemButton>();
            b.itemHolder = itemHolder;
            b.count = itemHolder.boobafeetGun;
            b.countText.text = "x" + itemHolder.boobafeetGun.ToString();
        }
        if (itemHolder.unchartedDisk > 0)
        {
            GameObject x = Instantiate(unchartedPanel, holder);
            ItemButton b = x.GetComponent<ItemButton>();
            b.itemHolder = itemHolder;
            b.count = itemHolder.unchartedDisk;
            b.countText.text = "x" + itemHolder.unchartedDisk.ToString();
        }

        if (itemHolder.knack2Disk > 0)
        {
            GameObject x = Instantiate(knackPanel, holder);
            ItemButton b = x.GetComponent<ItemButton>();
            b.itemHolder = itemHolder;
            b.count = itemHolder.knack2Disk;
            b.countText.text = "x" + itemHolder.knack2Disk.ToString();
        }

        if (itemHolder.mask > 0)
        {
            GameObject x = Instantiate(maskPanel, holder);
            ItemButton b = x.GetComponent<ItemButton>();
            b.itemHolder = itemHolder;
            b.count = itemHolder.mask;
            b.countText.text = "x" + itemHolder.mask.ToString();
        }

        if (itemHolder.ring > 0)
        {
            GameObject x = Instantiate(ringPanel, holder);
            ItemButton b = x.GetComponent<ItemButton>();
            b.itemHolder = itemHolder;
            b.count = itemHolder.ring;
            b.countText.text = "x" + itemHolder.ring.ToString();
        }

        if (itemHolder.lightsaber > 0)
        {
            GameObject x = Instantiate(lightSaberPanel, holder);
            ItemButton b = x.GetComponent<ItemButton>();
            b.itemHolder = itemHolder;
            b.count = itemHolder.lightsaber;
            b.countText.text = "x" + itemHolder.lightsaber.ToString();
        }


    }

    public void ClosePanel()
    {
        int count = holder.childCount;

        for(int i= 0; i < count; i++)
        {
            Destroy(holder.GetChild(i).gameObject);
        }
        this.gameObject.SetActive(false);
        tPSController.canControl = true;
        cameraController.canOrbit = true;
    }
}
