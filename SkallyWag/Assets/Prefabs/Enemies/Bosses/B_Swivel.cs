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
        bulletSpeed = 1f;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.AddForce(player.transform.position - transform.position, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -8.48f)
        {
            Destroy(gameObject);
        }
    }

    //when the bullet hits an enemy or barrier; destroy the bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
