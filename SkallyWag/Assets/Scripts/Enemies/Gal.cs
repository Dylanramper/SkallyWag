using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gal : MonoBehaviour
{
    int health = 3;

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }
}
