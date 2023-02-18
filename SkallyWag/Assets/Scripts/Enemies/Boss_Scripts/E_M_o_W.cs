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
            randomPoint = Random.Range(0, 3);
            moveTimer = 10;
            Debug.Log(randomPoint);
        }

        if (randomPoint == 0)
        {
            transform.position = (new Vector3(pointA.transform.position.x, pointA.transform.position.y));
            //transform.position = pointA.transform.position;
        }
        if (randomPoint == 1)
        {
            transform.position = (new Vector3(pointB.transform.position.x, pointB.transform.position.y));
            //transform.position = pointB.transform.position;
        }
        if (randomPoint == 2)
        {
            transform.position = (new Vector3(pointC.transform.position.x, pointC.transform.position.y));
            //transform.position = PointC.transform.position;
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
