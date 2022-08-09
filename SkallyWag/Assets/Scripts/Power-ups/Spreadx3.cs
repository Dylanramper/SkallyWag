using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spreadx3 : MonoBehaviour
{
    public GameObject bp1;
    public GameObject bp2;
    public GameObject bp3;
    bool active = true;

    private void Update()
    {
        if(active == false)
        {
            bp3.SetActive(false);
            active = true;
        }
        else if(active == true)
        {
            bp3.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            active = false;
            bp1.SetActive(true);
            bp2.SetActive(true);            
            Destroy(gameObject);
        }
    }
}
