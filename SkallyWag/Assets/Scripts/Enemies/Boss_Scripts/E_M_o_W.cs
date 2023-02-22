using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_M_o_W : MonoBehaviour
{
    int health = 100;
    public GameObject life, spreadx3, fireRate;
    public GameObject pointA, pointB, pointC;
    public float moveTimer;
    int randomPoint;
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveTimer = 10;
        moveSpeed = 2.5f;
        randomPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            killBoss();
        }

        moveTimer -= 1 * Time.deltaTime;

        if(moveTimer <= 0)
        {
            randomPoint = Random.Range(1, 4);
            moveTimer = 10;
            Debug.Log(randomPoint);
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
    }
    
    void killBoss()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
    }
}
