using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanonBall : MonoBehaviour
{
    float bulletSpeed = 7.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving the bullet
        transform.Translate(new Vector2(0, -bulletSpeed * Time.deltaTime));

        if (transform.position.y <= -8.4f)
        {
            Destroy(gameObject);
        }
    }
}
