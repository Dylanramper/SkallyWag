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
        transform.Translate(new Vector2(0, bulletSpeed * Time.deltaTime));

        if(transform.position.y >= 6.4f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}