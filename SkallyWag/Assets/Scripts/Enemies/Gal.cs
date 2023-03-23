using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gal : MonoBehaviour
{
    int health = 3;
    public GameObject life;
    public GameObject spreadx3;
    public GameObject firerate;
    int spawnrate;
    SpriteRenderer spriteRenderer;
    Color origColor;
    float hitTime = .25f;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        origColor = spriteRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            spawnrate = Random.Range(1, 100);
            Destroy(gameObject);
            if(spawnrate > 1 && spawnrate < 2)
            {
                Instantiate(life, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
            if (spawnrate > 3 && spawnrate < 30)
            {
                Instantiate(spreadx3, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
            if (spawnrate > 31 && spawnrate < 60)
            {
                Instantiate(firerate, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }
        }
    }
    void HitStart()
    {
        spriteRenderer.material.color = Color.red;
        Invoke("HitStop", hitTime);
    }
    void HitStop()
    {
        spriteRenderer.material.color = origColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            HitStart();
        }
    }
}
