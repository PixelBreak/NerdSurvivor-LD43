using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour {

    [Header("Items")]
    public int ps4;
    public int galaxyS7;
    public int xbox;
    public int unchartedDisk;
    public int knack2Disk;
    public int mask;
    public int ring;
    public int lightsaber;
    public int boobafeetGun;

    public List<GameObject> ps4GO;
    public List<GameObject> galaxyS7GO;
    public List<GameObject> xboxGO;
    public List<GameObject> unchartedGO;
    public List<GameObject> knackGO;
    public List<GameObject> maskGO;
    public List<GameObject> ringGO;
    public List<GameObject> lightSaberGO;
    public List<GameObject> boobafeetGO;

    public GameObject particle;

    int totalCount = 0;


    public void RemovePS4()
    {
        ps4GO[0].gameObject.SetActive(false);
        ps4GO.RemoveAt(0);
        TurnOfCollider();
    }
    public void RemoveXbox()
    {
        xboxGO[0].gameObject.SetActive(false);
        xboxGO.RemoveAt(0);
        TurnOfCollider();
    }
    public void RemoveGalaxyS7()
    {
        galaxyS7GO[0].gameObject.SetActive(false);
        galaxyS7GO.RemoveAt(0);
        TurnOfCollider();
    }

    public void RemoveUncharted()
    {
        unchartedGO[0].gameObject.SetActive(false);
        unchartedGO.RemoveAt(0);
        TurnOfCollider();
    }
    public void RemoveKnack()
    {
        knackGO[0].gameObject.SetActive(false);
        knackGO.RemoveAt(0);
        TurnOfCollider();
    }
    public void RemoveMask()
    {
        maskGO[0].gameObject.SetActive(false);
        maskGO.RemoveAt(0);
        TurnOfCollider();
    }

    public void RemoveRing()
    {
        ringGO[0].gameObject.SetActive(false);
        ringGO.RemoveAt(0);
        TurnOfCollider();
    }
    public void RemoveLightSabar()
    {
        lightSaberGO[0].gameObject.SetActive(false);
        lightSaberGO.RemoveAt(0);
        TurnOfCollider();
    }
    public void RemoveGun()
    {
        boobafeetGO[0].gameObject.SetActive(false);
        boobafeetGO.RemoveAt(0);
        TurnOfCollider();
    }

    private void TurnOfCollider()
    {
        totalCount = ps4 + galaxyS7 + xbox + unchartedDisk + knack2Disk + mask + ring + lightsaber + boobafeetGun;
        if ( totalCount <= 0)
        {
            particle.SetActive(false);
            transform.gameObject.tag = "Untagged";
        }
    }
}
