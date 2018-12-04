using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour {

    public ItemHolder itemHolder;
    public GameObject itemUIPanel;
    public ItemHolderUI itemHolderUI;
    [SerializeField] TPSController tpsController;
    [SerializeField] CameraController cameraController;
    [SerializeField] Animator storeboxAnim;
    bool canStore = false;

    private void Start()
    {
        itemHolder = null;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(canStore)
            {
                OnHand.instance.StoreToBox();
                storeboxAnim.Play("StoreBoxPop");
                OnHand.instance.PrintDebugText(OnHand.instance.currentHand);
                AudioManager.instance.PlayPutInBox();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.CompareTag("ItemHolder"))
        {
            if (OnHand.instance.currentHand >= OnHand.instance.maxHand)
                return;

            itemHolder = other.GetComponent<ItemHolder>();
            cameraController.canOrbit = false;
            itemUIPanel.SetActive(true);
            itemHolderUI.CreateList(itemHolder);
            tpsController.canControl = false;

        }
        else if(other.gameObject.CompareTag("StoreBox"))
        {
            canStore = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ItemHolder"))
        {
            itemHolder = null;
            //cameraController.canOrbit = true;
        }
        else if (other.gameObject.CompareTag("StoreBox"))
        {
            canStore = false;
        }
    }
}
