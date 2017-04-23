using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    public GameObject prefab;
    public GameObject arrow;

    public Color treeColor = Color.white;

    public Vector3 offset;

    public int blueReq = 0;
    public int yellowReq = 0;
    public int redReq = 0;

    public bool blueMet = false;
    public bool yellowMet = false;
    public bool redMet = false;

    public bool activatesTeleporter = false;

    public bool activatesWarp = false;

    public GameObject teleporter;

    WarpChecker warpChecker;

    private void Start()
    {
        warpChecker = FindObjectOfType<WarpChecker>();
    }

    private void Update()
    {
        if (GameController.instance.tutorial && blueMet && redMet && yellowMet)
            arrow.SetActive(true);
        else if (arrow.activeInHierarchy)
            arrow.SetActive(false);          
    }

    public void Build()
    {
        if (blueMet && redMet && yellowMet)
        {
            GameObject tree = Instantiate(prefab, transform.position + offset, Quaternion.identity);
            tree.GetComponent<SpriteRenderer>().color = treeColor;

            if (!GameController.instance.GetAltSFX())
                SFXManager.instance.Play("Build", false);
            else
                SFXManager.instance.Play("Build", false, 0.5f);
   
            GameController.instance.PayCost(blueReq, yellowReq, redReq);

            if (GameController.instance.tutorial)
                GameController.instance.tutorial = false;

            if (activatesTeleporter)
            {
                teleporter.SetActive(true);

            }

            GameController.instance.ResetPickupSFX();
            GameController.instance.TreeBuilt();

            Level4Manager level4 = FindObjectOfType<Level4Manager>();
            if (level4 != null)
            {
                level4.treesBuilt++;
            }

            if (activatesWarp)
            {
                warpChecker.AddBuilt();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (blueMet && redMet && yellowMet)
                UIManager.instance.ToggleSpacebar();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (blueMet && redMet && yellowMet)
                UIManager.instance.ToggleSpacebar();
        }
    }
}
