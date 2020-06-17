using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static GameManager thisManager = null;
    private Animation thisAnimation;
    public float Flapflap;
    public Rigidbody rb;
    public Text Score;
    public float points;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = (transform.up * Flapflap);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Death")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GG");
        }
        if(other.gameObject.tag == "BlockBlank")
        {
            points += 10;
            Score.text = "SCORE : " + points;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GG");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
