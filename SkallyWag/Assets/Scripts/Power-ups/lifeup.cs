using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeup : MonoBehaviour
{
    float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, -moveSpeed * Time.deltaTime, 0);

        if (gameObject.transform.position.y <= -8.48f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
