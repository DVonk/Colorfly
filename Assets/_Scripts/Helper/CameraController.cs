using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerController player;

    public bool follow = true;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null && follow)
            transform.position = player.transform.position + new Vector3(0f, 0f, -10f);


    }



}
