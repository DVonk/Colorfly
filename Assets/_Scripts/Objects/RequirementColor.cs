using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementColor : MonoBehaviour
{
    Text text;
    public string color;

    public Color green;
    public Color red;



    private void Awake()
    {
        text = GetComponent<Text>();

        if (color == "B")
            text.text = GetComponentInParent<Buildable>().blueReq.ToString();
        else if (color == "Y")
            text.text = GetComponentInParent<Buildable>().yellowReq.ToString();
        else if (color == "R")
            text.text = GetComponentInParent<Buildable>().redReq.ToString();

    }

    void Update()
    {
        if (color == "B")
        {
            if (GameController.instance.GetBlue() < int.Parse(text.text))
            {
                text.color = red;
                GetComponentInParent<Buildable>().blueMet = false;
            }              
            else
            {
                text.color = green;
                GetComponentInParent<Buildable>().blueMet = true;
            }
             
        }
        else if (color == "Y")
        {
            if (GameController.instance.GetYellow() < int.Parse(text.text))
            {
                text.color = red;
                GetComponentInParent<Buildable>().yellowMet = false;
            }
            else
            {
                text.color = green;
                GetComponentInParent<Buildable>().yellowMet = true;
            }
        }
        else if (color == "R")
        {
            if (GameController.instance.GetRed() < int.Parse(text.text))
            {
                text.color = red;
                GetComponentInParent<Buildable>().redMet = false;
            }
            else
            {
                text.color = green;
                GetComponentInParent<Buildable>().redMet = true;
            }
        }


    }

 
    
}
