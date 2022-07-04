using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet : MonoBehaviour
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
        transform.Translate(new Vector2(0, bulletSpeed * Time.deltaTime));

        if(transform.position.y >= 8.4f)
        {
            gameObject.SetActive(false);
        }
    }
    //when the bullet hits an enemy; destroy the bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}