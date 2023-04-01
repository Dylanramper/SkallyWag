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
    SpriteRenderer spriteRenderer;
    Color origColor;
    float hitTime = .25f;

    void Start()
    {
        //get the sprite renderer component from this enemy
        //set origcolor to the original colour
        spriteRenderer = GetComponent<SpriteRenderer>();
        origColor = spriteRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        //when destroyed pick a power up to drop at random
        if(health == 0)
        {
            spawnrate = Random.Range(1, 100);
            if (spawnrate > 1 && spawnrate < 5)
            {
                Instantiate(life, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
            if (spawnrate > 6 && spawnrate < 20)
            {
                Instantiate(spreadx3, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
            if (spawnrate > 21 && spawnrate < 35)
            {
                Instantiate(fireRate, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    //---------------------------------------------------------------
    //changing colour when hit
    void HitStart()
    {
        spriteRenderer.material.color = Color.red;
        Invoke("HitStop", hitTime);
    }
    void HitStop()
    {
        spriteRenderer.material.color = origColor;
    }
    //---------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            HitStart();
        }
    }
}
