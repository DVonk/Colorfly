using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCameraController : MonoBehaviour
{
    PlayerController player;
    public GameObject particleSystemChild;


    private void Awake()
    {
        if (particleSystemChild != null)
            DontDestroyOnLoad(gameObject);

    }

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
            transform.position = player.transform.position + new Vector3(0f, 0f, -10f);

    }

    public void DeleteParticles()
    {
        if (particleSystemChild != null)
        {
            Destroy(particleSystemChild.gameObject);
        }
    }

    public void IntroDone()
    {
        GameController.instance.ChangeLevel("03_Game");
    }


}
