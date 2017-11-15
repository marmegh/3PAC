using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pacmanController : MonoBehaviour {
    public int speed;

    private Rigidbody rb;
    public Text score;

    private int count;

	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, -1, 0);
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetScore();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
	}
    void OnTriggerEnter(Collider other)
    {
        //collect a coin
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetScore();
        }
        //gather fruit for additional points and to change game rules
        if (other.gameObject.CompareTag("Fruit"))
        {
            count += 5;
            SetScore();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //rotate the cube world
        if (collision.collider.CompareTag("up"))
        {
            Physics.gravity = new Vector3(0, -10, 0);
        }
        if (collision.collider.CompareTag("down"))
        {
            Physics.gravity = new Vector3(0, 10, 0);
        }
        if (collision.collider.CompareTag("left"))
        {
            Physics.gravity = new Vector3(10, 0, 0);
        }
        if (collision.collider.CompareTag("right"))
        {
            Physics.gravity = new Vector3(-10, 0, 0);
        }
        if (collision.collider.CompareTag("back"))
        {
            Physics.gravity = new Vector3(0, 0, -10);
        }
        if (collision.collider.CompareTag("front"))
        {
            Physics.gravity = new Vector3(0, 0, 10);
        }

    }

    void SetScore ()
    {
        score.text = "Score: " + count.ToString();
    }
}
