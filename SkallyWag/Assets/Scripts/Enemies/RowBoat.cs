using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowBoat : MonoBehaviour
{
    int health = 1;

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    //killing enemy when hit by bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }

}
