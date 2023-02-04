using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Controls : MonoBehaviour
{
    //for accessing the GameManager script
    public GameManager gm;

    //for screen bounds
    public GameObject player;
    private Vector2 screenBounds;
    public Camera mainCam;
    private float shipWidth;
    private float shipHeight;

    //for health
    
    
    //firing canons
    public float fireRate = 0f;
    float timer = 10f;
    public GameObject bp1;
    public GameObject bp2;
    bool active = false;

    //for when player gets damaged
    float recoverTime = 2f;
    public bool hit;

    public P_BP bp;


    void Start()
    {
        //Set PlayerHealth to 5 lives
        gm.playerHealth = 8;

        //Getting Height and Width of screenPos and W/H of Player.
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
        shipWidth = transform.GetComponent<BoxCollider2D>().bounds.extents.x;
        shipHeight = transform.GetComponent<BoxCollider2D>().bounds.extents.y;

        hit = false;
    }
    

    void Update()
    {
        //Setting Bounds for the screen, relative to the player.
        Vector3 cameraPos = transform.position;
        cameraPos.x = Mathf.Clamp(cameraPos.x, screenBounds.x * -1 + shipWidth, screenBounds.x - shipWidth);
        cameraPos.y = Mathf.Clamp(cameraPos.y, screenBounds.y * -1 + shipHeight, screenBounds.y - shipHeight);

        //this is controlling the life counters on the top left corner of the screen
        transform.position = cameraPos;
       

        if(gm.playerHealth >= 8)
        {
            gm.playerHealth = 8;
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
        
        //if you are damaged, you become immune for 2 seconds
        if(hit == true)
        {
            RecoveryPeriod();
            recoverTime -= 1 * Time.deltaTime;
        }
        if(recoverTime <= 0f)
        {
            hit = false;
            recoverTime = 2f;
            player.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    //Controls for Movement on keyboard
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

    //This is for when the player is hit, they get a brief moment on invincibility.
    public void RecoveryPeriod()
    {
        if (hit == true)
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //Damage to player from enemies
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RowB" || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Manowar")
        {
            gm.playerHealth -= 1;
            hit = true;
            Debug.Log(gm.playerHealth);
        }
        else if(collision.gameObject.tag == "Brig")
        {
            gm.playerHealth -= 2;
            hit = true;
            Debug.Log(gm.playerHealth);
        }
        else if(collision.gameObject.tag == "Gal")
        {
            gm.playerHealth -= 3;
            hit = true;
            Debug.Log(gm.playerHealth);
        }
        //collision for power-ups
        if(collision.gameObject.tag == "Life")
        {
            gm.playerHealth += 1;
            Debug.Log(gm.playerHealth);
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
