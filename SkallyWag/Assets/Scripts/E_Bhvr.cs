using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bhvr : MonoBehaviour
{
    float moveSpeed = 5.0f;
    float killZ = -7.48f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving the enemy downward
        gameObject.transform.Translate(0, -moveSpeed * Time.deltaTime, 0);

        if(gameObject.transform.position.y <= killZ) 
        {
            gameObject.SetActive(false);
        }
    }
    //killing enemy when hit by bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    }
}
