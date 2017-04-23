using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMove : MonoBehaviour
{
    bool hor = false;
    bool vert = false;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            hor = true;
        if (Input.GetAxis("Vertical") != 0)
            vert = true;

        if (hor && vert)
            Destroy(gameObject);

    }
}
