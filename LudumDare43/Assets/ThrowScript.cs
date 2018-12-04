using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowScript : MonoBehaviour {

    [SerializeField] Transform throwPoint;
    [SerializeField] GameObject[] prefab;
    [SerializeField] float force = 100;
    [SerializeField] ItemManager itemManager;
    [SerializeField] StoreManager storeManager;


    int index = 0;
    private void Update()
    {
        if (GameManager.instance.isGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            index = itemManager.currentIndex;
            if (index == 0)
            {
                if (ItemManager.ps4<= 0)
                    return;
            }
            if (index == 1)
            {
                if (ItemManager.xbox <= 0)
                    return;
            }
            if (index == 2)
            {
                if (ItemManager.s7 <= 0)
                    return;
            }
            if (index == 3)
            {
                if (ItemManager.joystick <= 0)
                    return;
            }
            if (index == 4)
            {
                if (ItemManager.knack <= 0)
                    return;

            }
            if (index == 5)
            {
                if (ItemManager.lightSaber <= 0)
                    return;

            }
            if (index == 6)
            {
                if (ItemManager.mask <= 0)
                    return;

            }
            if (index == 7)
            {
                if (ItemManager.ring <= 0)
                    return;

            }


            itemManager.ReduceItem(index);
            if(index <= prefab.Length)
            {
                GameObject o = Instantiate(prefab[index], throwPoint.position, throwPoint.rotation);
                o.GetComponent<Rigidbody>().AddForce(throwPoint.forward * force);
                GameManager.instance.ReduceNerdMeter(index);
            }
        
        }
    }


}
