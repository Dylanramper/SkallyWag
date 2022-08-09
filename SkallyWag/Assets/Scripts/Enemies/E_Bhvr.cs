using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bhvr : MonoBehaviour
{
    float moveSpeed = 5.0f;
    float killZ = -8.48f;
    int spawnRate;

    // Update is called once per frame
    void Update()
    {
        //moving the enemy downward
        gameObject.transform.Translate(0, -moveSpeed * Time.deltaTime, 0);

        if(gameObject.transform.position.y <= killZ) 
        {
            Destroy(gameObject);
        }
    }
}
