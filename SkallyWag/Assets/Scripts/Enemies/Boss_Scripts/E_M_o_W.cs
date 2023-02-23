using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_M_o_W : MonoBehaviour
{
    //health
    int health = 100;

    //Gameobjects
    public GameObject life, spreadx3, fireRate;
    public GameObject pointA, pointB, pointC;
    public GameObject RowB;
    public GameObject RowBSpawnPoint1;
    public GameObject RowBSpawnPoint2;

    //Movement
    public float moveTimer;
    int randomPoint;
    float moveSpeed;

    //variables to spawn RowB
    int spawnRate;
    float spawnRowBTime;

    // Start is called before the first frame update
    void Start()
    {
        moveTimer = 8;
        moveSpeed = 2.5f;
        randomPoint = 0;
        spawnRowBTime = 5f;
        spawnRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if Boss hp is 0 kill the boss
        if(health <= 0)
        {
            killBoss();
        }

        //countdown until the boss moves to the next position(random position)
        moveTimer -= 1 * Time.deltaTime;

        if(moveTimer <= 0)
        {
            randomPoint = Random.Range(1, 4);
            moveTimer = 8;
        }

        if (randomPoint == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.transform.position, moveSpeed * Time.deltaTime);
        }
        if (randomPoint == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.transform.position, moveSpeed * Time.deltaTime);
        }
        if (randomPoint == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointC.transform.position, moveSpeed * Time.deltaTime);
        }

        //sending RowB towards player
        spawnRowBTime = spawnRowBTime -= 1 * Time.deltaTime;

        if(spawnRowBTime <= 0)
        {
            spawnRate = Random.Range(0, 6);
            spawnRowBTime = 5f;
            spawnRowB();
        }
    }

    void spawnRowB()
    {
        Instantiate(RowB, new Vector2(RowBSpawnPoint1.transform.position.x, RowBSpawnPoint1.transform.position.y), Quaternion.identity);
        Instantiate(RowB, new Vector2(RowBSpawnPoint2.transform.position.x, RowBSpawnPoint2.transform.position.y), Quaternion.identity);
    }
    
    void killBoss()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //taking damage
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }
}
