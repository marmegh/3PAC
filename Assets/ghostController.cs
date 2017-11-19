using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostController : MonoBehaviour {
    public Rigidbody rb;
    public GameObject player;
    public int leveltimer;
    private Vector3 start;
    private Vector3 physic;
    public float delta;
    private Vector3 physic2;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        leveltimer = 0;
        start = transform.position;
        DisableGravity();
        physic2 = Physics.gravity;
        physic = physic;
	}
    private void Update()
    {
        leveltimer++;
        if(leveltimer == 100)
        {
            transition();
            EnableGravity();
        }
        if(leveltimer > 150)
        {
            delta = Physics.gravity.y - physic.y;
            if(delta > 2f || delta < -2f)
            {
                transition();
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
}
