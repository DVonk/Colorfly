using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    Buildable buildable;

    private void Awake()
    {
        buildable = GetComponent<Buildable>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (buildable.blueMet && buildable.redMet && buildable.yellowMet)
            UIManager.instance.ToggleSpacebar();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (buildable.blueMet && buildable.redMet && buildable.yellowMet)
            UIManager.instance.ToggleSpacebar();
    }
}
