using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMover : MonoBehaviour {
    public GameObject butterfly;

	public void ChangeToIdle()
    {
        butterfly.GetComponent<Animator>().SetTrigger("IdleTrigger");
    }
}
