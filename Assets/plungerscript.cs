using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plungerscript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.transform.position += new Vector3(0, 0.25f, 0);
        }

        if (Input.GetKeyUp("space"))
        {
            this.transform.position += new Vector3(0, -0.25f, 0);
        }

    }
}