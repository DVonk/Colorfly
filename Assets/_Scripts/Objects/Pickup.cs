using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    enum PickupType { Blue, Red, Yellow };
    PickupType type;

    public ParticleSystem destroyBurst;

    private void Awake()
    {
        if (gameObject.name.Contains("Blue"))
            type = PickupType.Blue;
        else if (gameObject.name.Contains("Red"))
            type = PickupType.Red;
        else if (gameObject.name.Contains("Yellow"))
            type = PickupType.Yellow;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Enemy")
        {
            string number = 1.ToString();

            if(!GameController.instance.GetAltSFX())
            {
                switch (GameController.instance.lastPickupSFXNumber)
                {
                    case 3: number = "4"; GameController.instance.lastPickupSFXNumber = 4; break;
                    case 4: number = "5"; GameController.instance.lastPickupSFXNumber = 5; break;
                    case 5: number = "6"; GameController.instance.lastPickupSFXNumber = 6; break;
                    case 6: number = "7"; GameController.instance.lastPickupSFXNumber = 7; break;
                    case 7: number = "8"; GameController.instance.lastPickupSFXNumber = 8; break;
                    case 8: number = "3"; GameController.instance.lastPickupSFXNumber = 3; break;
                }

                SFXManager.instance.Play("Pickup" + number, false);
            }
            else
            {
                number = Random.Range(1, 4).ToString();
                SFXManager.instance.Play("PickupAlt" + number, false);
            }

            if (collision.tag == "Player")
            {
                switch (type)
                {
                    case PickupType.Blue:
                        GameController.instance.AddBlue(1);
                        break;
                    case PickupType.Red:
                        GameController.instance.AddRed(1);
                        break;
                    case PickupType.Yellow:
                        GameController.instance.AddYellow(1);
                        break;
                }
            }


            Instantiate(destroyBurst, transform.position + new Vector3(0f, 0f, -5f), Quaternion.identity);

            Level4Manager level4 = FindObjectOfType<Level4Manager>();
            if (level4 != null)
                level4.PickupCollected();

            Destroy(gameObject);
        }
        
    }

    public void DestroyManually()
    {
        string number = 1.ToString();

        if (!GameController.instance.GetAltSFX())
        {
            switch (GameController.instance.lastPickupSFXNumber)
            {
                case 3: number = "4"; GameController.instance.lastPickupSFXNumber = 4; break;
                case 4: number = "5"; GameController.instance.lastPickupSFXNumber = 5; break;
                case 5: number = "6"; GameController.instance.lastPickupSFXNumber = 6; break;
                case 6: number = "7"; GameController.instance.lastPickupSFXNumber = 7; break;
                case 7: number = "8"; GameController.instance.lastPickupSFXNumber = 8; break;
                case 8: number = "3"; GameController.instance.lastPickupSFXNumber = 3; break;
            }

            SFXManager.instance.Play("Pickup" + number, false);
        }
        else
        {
            number = Random.Range(1, 4).ToString();
            SFXManager.instance.Play("PickupAlt" + number, false);
        }

        Instantiate(destroyBurst, transform.position + new Vector3(0f, 0f, -5f), Quaternion.identity);

        Destroy(gameObject);
    }
}
