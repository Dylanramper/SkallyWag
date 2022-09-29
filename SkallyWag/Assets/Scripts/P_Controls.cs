using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Controls : MonoBehaviour
{
    public GameManager gm;

    public GameObject player;
    private Vector2 screenBounds;
    public Camera mainCam;

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;

    private float shipWidth;
    private float shipHeight;

    public float fireRate = 0f;
    float timer = 10f;
    public GameObject bp1;
    public GameObject bp2;
    bool active = false;

    public P_BP bp;

    

    void Start()
    {
        //Set PlayerHealth to 5 lives
        gm.playerHealth = 5;

        //Getting Height and Width of screenPos and W/H of Player.
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
        shipWidth = transform.GetComponent<BoxCollider2D>().bounds.extents.x;
        shipHeight = transform.GetComponent<BoxCollider2D>().bounds.extents.y;
    }
    

    void Update()
    {
        //Setting Bounds for the screen, relative to the player.
        Vector3 cameraPos = transform.position;
        cameraPos.x = Mathf.Clamp(cameraPos.x, screenBounds.x * -1 + shipWidth, screenBounds.x - shipWidth);
        cameraPos.y = Mathf.Clamp(cameraPos.y, screenBounds.y * -1 + shipHeight, screenBounds.y - shipHeight);

        transform.position = cameraPos;
        if(gm.playerHealth == 4)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(false);
        }
        else if(gm.playerHealth == 3)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health5.SetActive(false);
            health4.SetActive(false);
        }
        else if(gm.playerHealth == 2)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health5.SetActive(false);
            health4.SetActive(false);
            health3.SetActive(false);
        }
        else if(gm.playerHealth == 1)
        {
            health1.SetActive(true);
            health5.SetActive(false);
            health4.SetActive(false);
            health3.SetActive(false);
            health2.SetActive(false);
        }
        else if(gm.playerHealth == 5)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(true);
        }

        if(gm.playerHealth >= 5)
        {
            gm.playerHealth = 5;
        }

        //If playerHealth is <= 0 Run Death() function
        if(gm.playerHealth <= 0)
        {
            gm.Death();
        }
        Controls();

        //if active is true start countdown from 10 sec
        //if active is false deactivate extra cannons
        if(active == true)
        {
            bp1.SetActive(true);
            bp2.SetActive(true);
            timer -= 1f * Time.deltaTime;
            if(timer <= 0f)
            {
                active = false;
                bp1.SetActive(false);
                bp2.SetActive(false);
                timer = 10f;
            }
        }

    }

    //Controls for Movement
    public void Controls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(new Vector2(0, 6 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(new Vector2(0, -6 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(new Vector2(-6 * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(new Vector2(6 * Time.deltaTime, 0));
        }
    }

    //Damage to player from enemies
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RowB" || collision.gameObject.tag == "Bullet")
        {
            gm.playerHealth -= 1;
        }
        else if(collision.gameObject.tag == "Brig")
        {
            gm.playerHealth -= 2;
        }
        else if(collision.gameObject.tag == "Gal")
        {
            gm.playerHealth -= 3;
        }

        if(collision.gameObject.tag == "Life")
        {
            gm.playerHealth += 1;
        }
        if(collision.gameObject.tag == "spread")
        {
            active = true;
        }
        if(collision.gameObject.tag == "spread" && active == true)
        {
            timer = 10f;
        }
        if (collision.gameObject.tag == "rateoffire")
        {
            bp.fireRateActive = true;
        }
    }
}
