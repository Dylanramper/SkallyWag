using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gal : MonoBehaviour
{
    int health = 3;
    public GameObject life;
    int spawnrate;

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            spawnrate = Random.Range(1, 10);
            Destroy(gameObject);
            if(spawnrate >= 5)
            {
                Instantiate(life, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
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
