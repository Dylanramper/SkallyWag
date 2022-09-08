using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brigs : MonoBehaviour
{
    public GameObject life;
    public GameObject spreadx3;
    public GameObject fireRate;
    int health = 2;
    int spawnrate;

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            spawnrate = Random.Range(1, 100);
            if (spawnrate > 1 && spawnrate < 10)
            {
                Instantiate(life, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
            if (spawnrate > 11 && spawnrate < 40)
            {
                Instantiate(spreadx3, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
            if (spawnrate > 41 && spawnrate < 60)
            {
                Instantiate(fireRate, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
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
