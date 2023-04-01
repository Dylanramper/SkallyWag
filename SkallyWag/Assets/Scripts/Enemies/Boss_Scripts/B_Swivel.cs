using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Swivel : MonoBehaviour
{
    public GameObject player;
    float bulletSpeed;
    Rigidbody2D rb;

    private void Awake()
    {
        //set the bulletspeed to 1
        //find the player in the scene and parent it to the variable 'player'
        //find the rigidbody2D component in this cannonball
        bulletSpeed = 1f;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        //Add a force to the cannon ball making it go forward
        rb.AddForce(player.transform.position - transform.position, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //if the ball goes too far off the screen destroy it
        if (transform.position.y <= -8.48f)
        {
            Destroy(gameObject);
        }
    }

    //when the bullet hits an enemy or barrier; destroy the bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if it hits one of the barriers outside the screen destroy the ball
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
