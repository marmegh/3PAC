using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Ghost : Collider
{
    public Rigidbody rb { get; set; }
    public int timer { get; set; }
    public Vector3 start { get; set; }

    public Ghost(Rigidbody rigidbod)
    {
        rb = rigidbod;
        timer = 0;
        start = rb.transform.position;
    }
    public void rebirth()
    {
        timer = 0;
        rb.isKinematic = false;
        rb.detectCollisions = true;
        rb.transform.position = start;
    }
    public void enableGravity()
    {
        rb.isKinematic = true;
    }
}
