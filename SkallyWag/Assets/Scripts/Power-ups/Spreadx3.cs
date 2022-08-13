using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spreadx3 : MonoBehaviour
{
    public GameObject bp1;
    public GameObject bp2;

    private void Update()
    {
        gameObject.transform.Translate(0, -5.0f * Time.deltaTime, 0);

        if (gameObject.transform.position.y <= -8.48f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bp1.SetActive(true);
            bp2.SetActive(true);            
            Destroy(gameObject);
        }
    }
}
