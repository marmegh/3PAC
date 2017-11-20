using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostController : MonoBehaviour {
    public Rigidbody rb;
    public GameObject red;
    public GameObject player;
    public int leveltimer;
    private Vector3 start;
    private Vector3 physic;
    public float delta;
    private int wait;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start = transform.position;
        leveltimer = 0;
        DisableGravity();
        if(rb.name == "ghost red")
        {
            wait = 100;
        }
        if(rb.name == "ghost teal")
        {
            wait = 150;
        }
        if(rb.name == "ghost pink")
        {
            wait = 200;
        }
        if (rb.name == "ghost orange")
        {
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
}