using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Camera : MonoBehaviour {
    public GameObject enemy;
    public GameObject enemyCutscene;
    public GameObject p1;
    public GameObject p2;
    public GameObject camMain;


	public void DestroyP1()
    {
        p1.GetComponent<Pickup>().DestroyManually();
    }

    public void DestroyP2()
    {
        p2.GetComponent<Pickup>().DestroyManually();
    }

    public void DestroySelf()
    {
        Destroy(enemyCutscene);
        enemy.SetActive(true);
        camMain.SetActive(true);
        FindObjectOfType<Level4Manager>().CutsceneDone();
        Destroy(gameObject);
    }
}
