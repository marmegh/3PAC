using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pacmanController : MonoBehaviour
{
    public int speed;
    private bool ghostbuster;
    private int countdown;
    private Rigidbody rb;
    public Text score;
    public Text cd;
    public Text winText;
    public int level;

    private int count;

    // Use this for initialization
    void Start()
    {
        ghostbuster = false;
        level = 1;
        winText.text = "";
        Physics.gravity = new Vector3(0, -1, 0);
        rb = GetComponent<Rigidbody>();
        countdown = 0;
        count = 0;
        SetScore();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void Update()
    {
        //countdown for ghostbuster feature
        if (ghostbuster == true)
        {
            countdown--;
            if (countdown % 5 == 0)
            {
                int temp = countdown / 5;
                cd.text = "Countdown: " + temp.ToString();
            }
        }
        if (countdown == 0 && ghostbuster == true)
        {
            ghostbuster = false;
            cd.text = "";
        }
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
            other.gameObject.SetActive(false);
            count += 50;
            SetScore();
        }
        //magic pill anyone?
        if (other.gameObject.CompareTag("cap"))
        {
            other.gameObject.SetActive(false);
            ghostbuster = true;
            countdown = 500;
            count += 5;
            SetCountDown();
            SetScore();
        }
        if (other.gameObject.CompareTag("tunnel"))
        {
            other.gameObject.SetActive(false);
        }
        if (level == 1 && count >= 250)
        {
            winText.text = "Level 1 complete! Proceed to level 2...";
            level++;
        }
        if (level ==2 && count > 350)
        {
            winText.text = "Level 2 complete! Proceed to level 2...";
            level++;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ghost"))
        {
            if(ghostbuster == true)
            {
                count += 100;
                ghostController ghost = collision.gameObject.GetComponent<ghostController>();
                ghost.reSpawn();
                SetScore();
            }
            else
            {
                count -= 100;
                collision.gameObject.SetActive(false);
                SetScore();
            }
        }
        //rotate the cube world
        if (collision.collider.CompareTag("up"))
        {
            Physics.gravity = new Vector3(0, -10, 0);
        }
        if (collision.collider.CompareTag("down"))
        {
            Physics.gravity = new Vector3(0, 10, 0);
        }
        /*if (collision.collider.CompareTag("left"))
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
        }*/

    }

    void SetScore()
    {
        score.text = "Score: " + count.ToString();
    }
    void SetCountDown()
    {
        cd.text = "Countdown: " + countdown.ToString();
    }
}
