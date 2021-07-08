using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballscript : MonoBehaviour
{

    Vector3 bounceforce = new Vector3(0, 250, 0);
    Vector3 plungerforce = new Vector3(0, 1200, 0);
    public bool plungerarea = true;
    public int ballcount = 3;
    public Text balltext;
    public Text pointtext;
    public GameObject gameover;
    public int points = 0;
    public bool flipcheckright = false;
    public bool flipcheckleft = false;
    public float righttimer;
    public float lefttimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            righttimer += 1 * Time.deltaTime;
           
        }
        if (righttimer > 0.15)
        {
            flipcheckright = false;
        }
        if (Input.GetKey("a"))
        {
            lefttimer += 1 * Time.deltaTime;

        }
        if (lefttimer > 0.15)
        {
            flipcheckleft = false;
        }
        if (Input.GetKeyUp("d"))
        {
            righttimer = 0;
        }
        if (Input.GetKeyUp("a"))
        {
            lefttimer = 0;
        }
        if (Input.GetKey("d") && flipcheckright == true)
        {
            GetComponent<Rigidbody2D>().AddForce(bounceforce);
        }
        
        if (Input.GetKey("a") && flipcheckleft == true)
        {
            GetComponent<Rigidbody2D>().AddForce(bounceforce);
        }

        if (Input.GetKeyDown("space") && plungerarea==true)
        {
            GetComponent<Rigidbody2D>().AddForce(plungerforce);
            plungerarea = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name.Contains("right"))
        {
            flipcheckright = true;
        }

        if (coll.gameObject.name.Contains("left"))
        {
            flipcheckleft = true;
        }

        if (coll.gameObject.name.Contains("plunger"))
        {
            plungerarea = true;
        }

        if (coll.gameObject.name.Contains("bump"))
        {
            points += 1;
            pointtext.GetComponent<Text>().text = "" + points;
           
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.name.Contains("right"))
        {
            flipcheckright = false;
        }
        if (coll.gameObject.name.Contains("left"))
        {
            flipcheckleft = false;
        }
        if (coll.gameObject.name.Contains("plunger"))
        {
            plungerarea = false;
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
                this.transform.position = new Vector3(4.04f, -4.19f, 0);
            }
            else
            {
                gameover.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
}
