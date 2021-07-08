using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class old : MonoBehaviour
{

    Vector3 bounceforce = new Vector3(0, 600, 0);
    Vector3 plungerforce = new Vector3(0, 1200, 0);
    public bool plungerarea = true;
    public int ballcount = 3;
    public Text balltext;
    public Text pointtext;
    public GameObject gameover;
    public int points = 0;
    public bool flipcheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && plungerarea == true)
        {
            GetComponent<Rigidbody2D>().AddForce(plungerforce);
            plungerarea = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name.Contains("flipper") && Input.GetKey("d"))
        {
            GetComponent<Rigidbody2D>().AddForce(bounceforce);
        }
        if (coll.gameObject.name.Contains("bump"))
        {
            points += 1;
            pointtext.GetComponent<Text>().text = "" + points;

        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name.Contains("water"))
        {
            ballcount -= 1;
            balltext.GetComponent<Text>().text = "" + ballcount;
            if (ballcount >= 1)
            {
                this.transform.position = new Vector3(4.04f, -4.64f, 0);
                plungerarea = true;
            }
            else
            {
                gameover.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
}
