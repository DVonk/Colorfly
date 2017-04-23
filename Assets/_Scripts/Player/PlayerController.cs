using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Animator anim;

    public GameObject destroyBurst;
    public bool lastLevel;

    public bool freeze = false;

    bool movingToPlanet = false;
    Vector3 destination = Vector3.zero;

    bool canBuild = false;
    Buildable currentBuildable;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {
        if (!freeze)
        {
            if (!movingToPlanet)
            {
                //Move
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
                transform.position += movement * speed * Time.deltaTime;

                if (movement.x != 0 || movement.y != 0)
                    anim.SetBool("isMoving", true);
                else
                    anim.SetBool("isMoving", false);

                anim.SetFloat("movingDirection", movement.x);

                //Build
                bool action = Input.GetButtonDown("Jump");

                if (canBuild && action)
                    currentBuildable.Build();
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, destination, 0.1f);
            }
        }


    }



    public void ToggleBuilding()
    {
        canBuild = !canBuild;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Buildable")
        {
            canBuild = true;
            currentBuildable = collision.GetComponent<Buildable>();
        }
        else if (collision.tag == "Warp")
        {
            if (!movingToPlanet)
            {
                Vector3 newPosition = collision.GetComponent<Teleporter>().GetDestination();
                destination = newPosition;
                movingToPlanet = true;
                GetComponent<CircleCollider2D>().isTrigger = true;

                string number = 1.ToString();


                switch (GameController.instance.lastWarpSFXNumber)
                {
                    case 1: number = "2"; GameController.instance.lastWarpSFXNumber = 2; break;
                    case 2: number = "3"; GameController.instance.lastWarpSFXNumber = 3; break;
                    case 3: number = "4"; GameController.instance.lastWarpSFXNumber = 4; break;
                    case 4: number = "5"; GameController.instance.lastWarpSFXNumber = 5; break;
                    case 5: number = "6"; GameController.instance.lastWarpSFXNumber = 6; break;
                    case 6: number = "1"; GameController.instance.lastWarpSFXNumber = 1; break;
                }


                SFXManager.instance.Play("Warp" + number, false);
            }


        }
        else if (collision.tag == "Destination")
        {

            movingToPlanet = false;
            GetComponent<CircleCollider2D>().isTrigger = false;


        }
        else if (collision.tag == "NextWorldWarp")
        {
            Vector3 newPosition = collision.GetComponent<Warp>().GetDestination();
            destination = newPosition;
            GetComponent<CircleCollider2D>().isTrigger = true;
            movingToPlanet = true;

            GameController.instance.ResetPickups();

            EnemyController[] enemies = FindObjectsOfType<EnemyController>();
            foreach (EnemyController enemy in enemies)
            {
                enemy.GetComponent<CircleCollider2D>().enabled = false;
            }

            if (!GameController.instance.GetAltSFX())
            {
                SFXManager.instance.Play("Pickup1", false);
                SFXManager.instance.Play("LevelDone", false);
            }
            else
            {
                SFXManager.instance.Play("Pickup1", false, 0.5f);
                SFXManager.instance.Play("LevelDone", false, 0.5f);
            }

            StartCoroutine(BGMManager.instance.FadeOutFast());

            CameraController cameraCon = Camera.main.GetComponent<CameraController>();
            if (cameraCon != null)
                cameraCon.follow = false;

            UIManager.instance.FadeOut(collision.GetComponent<Warp>().nextSceneName);
        }
        else if (collision.tag == "Enemy")
        {
            if (!lastLevel)
            {
                FindObjectOfType<Level4Manager>().ResetTrees();
                SFXManager.instance.Play("Hit", false);
                Instantiate(destroyBurst, transform.position + new Vector3(0f, 0f, -5f), Quaternion.identity);

                UIManager.instance.FadeOut(GameController.instance.GetSceneName(), 3f);
                Destroy(gameObject);
            }
            else
            {
                SFXManager.instance.Play("Hit", false);
                Instantiate(destroyBurst, transform.position + new Vector3(0f, 0f, -5f), Quaternion.identity);

                BGMManager.instance.FadeThisOut();
                UIManager.instance.FadeOut("08_Outro", 6f);
                Destroy(gameObject);
            }

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        canBuild = false;
        currentBuildable = null;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

}
