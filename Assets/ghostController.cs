using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ghostController : MonoBehaviour {
    public Rigidbody rb;
    public GameObject red;
    public GameObject player;
    public int leveltimer;
    private Vector3 start;
    private Vector3 physic;
    public float delta;
    private int wait;
    private bool redg;
    private bool tealg;
    private bool og;
    private bool pinkg;
    private bool corner;
    private bool hunt;
    private bool hide;
    System.Random rand;

    // Use this for initialization
    void Start()
    {
        rand = new System.Random();
        rb = GetComponent<Rigidbody>();
        start = transform.position;
        leveltimer = 0;
        DisableGravity();
        if(rb.name == "ghost red")
        {
            hunt = false;
            hide = false;
            corner = true;
            redg = true;
            tealg = false;
            og = false;
            pinkg = false;
            wait = 100;
        }
        if(rb.name == "ghost teal")
        {
            redg = false;
            tealg = true;
            og = false;
            pinkg = false;
            wait = 150;
        }
        if(rb.name == "ghost pink")
        {
            redg = false;
            tealg = false;
            og = false;
            pinkg = true;
            wait = 200;
        }
        if (rb.name == "ghost orange")
        {
            redg = false;
            tealg = false;
            og = true;
            pinkg = false;
            wait = 250;
        }
    }
    private void Update()
    {
        leveltimer++;
        if (leveltimer == wait)
        {
            transition();
            EnableGravity();
            if(redg == true || og == true)
            {
                transform.position += new Vector3(1.5f, 0f, 0f);
            }
            else
            {
                transform.position += new Vector3(-1.7f, 0f, 0f);
            }
        }
        if (leveltimer > wait)
        {
            delta = Physics.gravity.y - physic.y;
            if (delta > 2f || delta < -2f)
            {
                transition();
            }
            if(red.activeInHierarchy == false)
            {
                transform.position = start;
                red.SetActive(true);
                DisableGravity();
                leveltimer = 0;

            }
            physic = Physics.gravity;
        }
        if (leveltimer > wait + 250 && leveltimer%100 == 0)
        {
            omove();
        }
    }
    void transition()
    {
        if (Physics.gravity.y < 0)
        {
            transform.Rotate(-180, 0, 0);
            transform.position = transform.position + new Vector3(0f, 7f, 0f);
        }
        else
        {
            transform.Rotate(180, 0, 0);
            transform.position = transform.position + new Vector3(0f, -3f, 0f);
        }

    }
    void EnableGravity()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }
    // Update is called once per frame
    void DisableGravity()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }
    public void reSpawn()
    {
        leveltimer = 0;
        transform.position = start;
        transform.Rotate(-180, 0, 0);
        DisableGravity();
    }
    public void omove()
    {
        int choice = rand.Next(1, 5);
        if(choice == 1)
        {
            if(transform.position.z <-12.4)
            {
                choice = rand.Next(2, 5);
            }
            else
            {
                transform.position += Vector3.back;
            }
        }
        if(choice == 2)
        {
            if (transform.position.z > 17)
            {
                choice = 1;
            }
            else
            {
                transform.position += Vector3.forward;
            }
            transform.position += Vector3.forward;
        }
        if(choice == 3)
        {
            if (transform.position.x < -6)
            {
                choice = 4;
            }
            else
            {
                transform.position += Vector3.left;
            }
        }
        else
        {
            if (transform.position.x > 10)
            {
                choice = rand.Next(1, 4);
            }
            else
            {
                transform.position += Vector3.right;
            }
        }
    }
}