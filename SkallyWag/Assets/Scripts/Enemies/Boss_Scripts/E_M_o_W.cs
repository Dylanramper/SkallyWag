using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_M_o_W : MonoBehaviour
{
    int health = 100;
    public GameObject life, spreadx3, fireRate;
    public GameObject pointA, pointB, PointC;
    public float moveTimer;
    int randomPoint;
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveTimer = 10;
        moveSpeed = 100;
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
            Movement();
            randomPoint = Random.Range(0, 2);
            moveTimer = 10;
            Debug.Log(randomPoint);
        }
    }
    
    void killBoss()
    {
        Destroy(gameObject);
    }

    void Movement()
    {
        if(randomPoint == 0)
        {
            transform.position = new Vector3(0, 12 * Time.deltaTime, 0);
            //transform.Translate(0, 12 * Time.deltaTime, 0);
        }
        if(randomPoint == 1)
        {
            transform.position = new Vector3(-2 * Time.deltaTime, 10 * Time.deltaTime, 0);
            //transform.Translate(-2 * Time.deltaTime, 10 * Time.deltaTime, 0);
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
