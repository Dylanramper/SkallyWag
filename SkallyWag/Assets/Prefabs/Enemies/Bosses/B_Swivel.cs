using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Swivel : MonoBehaviour
{
    public GameObject player;
    float bulletSpeed;
    float dirX;
    float dirY;
    Rigidbody2D rb;

    private void Awake()
    {
        bulletSpeed = .5f;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(player.transform.position - transform.position, ForceMode2D.Impulse);
        //transform.Translate(bp.transform.position * Time.deltaTime);

        if (transform.position.y <= -8.48f)
        {
            Destroy(gameObject);
        }
    }
    /*
    void moveToPlayer()
    {
        //moving the bullet
        bp = GameObject.Find("BP_Swivel");
        dirX = bp.transform.position.x;
        dirY = bp.transform.position.y;
        transform.Translate(new Vector2(dirX, dirY) * Time.deltaTime);
        //transform.Translate(new Vector2(player.transform.position.x, player.transform.position.y) * Time.deltaTime);
    }*/

    //when the bullet hits an enemy; destroy the bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
