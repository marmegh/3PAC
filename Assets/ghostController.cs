using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostController : MonoBehaviour {
    public Rigidbody rb;
    public GameObject player;
    private int leveltimer;
    private Vector3 start;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        leveltimer = 0;
        start = transform.position;
        DisableGravity();
	}
    private void Update()
    {
        leveltimer++;
        if(leveltimer >= 1000)
        {
            if(player.transform.position.y >= 1.5)
            {
                transform.position = transform.position + new Vector3(0f, 7f, 0f);
            }
            else
            {
                transform.position = transform.position + new Vector3(0f, -3f, 0f);
            }
            EnableGravity();
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
