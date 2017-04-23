using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutroCamera : MonoBehaviour {
    public GameObject thanksText;
    public GameObject treeText;

	public void ShowText()
    {
        thanksText.SetActive(true);
    }

    public void GoTitle()
    {
        GameController.instance.ResetPickups();
        GameController.instance.ResetPickupSFX();
        GameController.instance.ResetWarpSFX();
        GameController.instance.ChangeLevel("01_Menu");
    }

    public void ShowTreeText()
    {
        treeText.SetActive(true);
        treeText.GetComponent<Text>().text = GameController.instance.GetTreeCount().ToString() + "/30 Trees were planted.";
    }
}
