using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bhvr : MonoBehaviour
{
    public E_Spawn2 eSpawn;

    public float moveSpeed = 3.0f;
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

        if(eSpawn.secondTimer >= 2.5f)
        {
            moveSpeed = 5.0f;
        }
    }
}
