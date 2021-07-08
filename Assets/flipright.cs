using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipright: MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d") )
        {
            this.transform.eulerAngles += new Vector3(0, 0, -30);

        }

        if (Input.GetKeyUp("d") )
        {
            this.transform.eulerAngles += new Vector3(0, 0, 30);
        }

    }
}
