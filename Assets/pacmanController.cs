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
        //rotate the cube world
        if (other.gameObject.CompareTag("Net"))
        {
            count += 5;
            SetScore();
        }
    }

    void SetScore ()
    {
        score.text = "Score: " + count.ToString();
    }
}
