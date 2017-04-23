using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10f;
    private Animator anim;

    PlayerController player;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        anim.SetBool("isMoving", true);

    }


    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            if (player.transform.position.x < transform.position.x)
                anim.SetFloat("movingDirection", -1f);
            else if (player.transform.position.x > transform.position.x)
                anim.SetFloat("movingDirection", 1f);
            else
                anim.SetFloat("movingDirection", 0f);
        }


    }




    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void IncSpeed()
    {
        speed++;
    }

}
