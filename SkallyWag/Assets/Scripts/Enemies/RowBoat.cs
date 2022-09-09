using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowBoat : MonoBehaviour
{
    public GameObject life;
    int health = 1;
    int spawnrate;

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            spawnrate = Random.Range(1, 100);
            Destroy(gameObject);
            if (spawnrate > 1 && spawnrate < 20)
            {
                Instantiate(life, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
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
