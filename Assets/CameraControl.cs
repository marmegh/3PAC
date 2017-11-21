using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
    private Vector3 physic;
    public float delta;
    private int wait;

    void Start () {
        offset = transform.position - player.transform.position;
        wait = 10;
	}
	void LateUpdate () {
        while(wait > 0)
        {
            wait--;
        }
        if(wait < 1)
        {
            delta = Physics.gravity.y - physic.y;
            if (delta > 2f || delta < -2f)
            {
                transition();
            }
        }
        if(Physics.gravity.y < 0)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            transform.position = player.transform.position - offset;
        }
        physic = Physics.gravity;
	}
    void transition()
    {
        if (Physics.gravity.y < 0)
        {
            transform.Rotate(-180, 0, 180);
        }
        else
        {
            transform.Rotate(180, 0, -180);
        }

    }
}
