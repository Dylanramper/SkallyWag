using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_CanonBall : MonoBehaviour
{
    float bulletSpeed;

    private void Start()
    {
        bulletSpeed = 7.5f;
    }


    // Update is called once per frame
    void Update()
    {
        //moving the bullet
        transform.Translate(new Vector2(0, -bulletSpeed * Time.deltaTime));

        if(transform.position.y <= -8.48f)
        {
            Destroy(gameObject);
        }
    }
    //when the bullet hits an enemy; destroy the bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}