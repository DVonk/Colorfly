using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform destination;
    public string nextSceneName = "";



    public Vector3 GetDestination()
    {
        return destination.position;
    }


}
