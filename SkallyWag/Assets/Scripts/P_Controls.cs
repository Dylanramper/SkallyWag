using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Controls : MonoBehaviour
{
    //for accessing the GameManager script
    public GameManager gm;
    public Slider healthBar;

    //for screen bounds
    public GameObject player;
    private Vector2 screenBounds;
    public Camera mainCam;
    private float shipWidth;
    private float shipHeight;
    
    //firing canons
    public float fireRate = 0f;
    float timer = 10f;
    public GameObject bp1;
    public GameObject bp2;
    bool active = false;

    //for when player gets damaged
    float recoverTime = 2f;
    public bool hit;
    bool onFire;

    public P_BP bp;

    //Variables for Hit indicators
    SpriteRenderer spriteRenderer;
    Color origColor;
    float hitTime = 1f;
    public AudioSource audioSource;
    public AudioClip hit1, hit2, dead;
    int hitsound;


    void Start()
    {
        //Set PlayerHealth to 5 lives
        gm.playerHealth = 8;

        //Getting Height and Width of screenPos and W/H of Player.
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
        shipWidth = transform.GetComponent<BoxCollider2D>().bounds.extents.x;
        shipHeight = transform.GetComponent<BoxCollider2D>().bounds.extents.y;

        hit = false;
        onFire = false;

        //get sprite renderer from player
        //set origcolor to original colour
        spriteRenderer = GetComponent<SpriteRenderer>();
        origColor = spriteRenderer.material.color;
    }
    

    void Update()
    {
        //Setting Bounds for the screen, relative to the player.
        Vector3 cameraPos = transform.position;
        cameraPos.x = Mathf.Clamp(cameraPos.x, screenBounds.x * -1 + shipWidth, screenBounds.x - shipWidth);
        cameraPos.y = Mathf.Clamp(cameraPos.y, screenBounds.y * -1 + shipHeight, screenBounds.y - shipHeight);

        //this is controlling the life counters on the top left corner of the screen
        transform.position = cameraPos;
       
        //player health cannot go above 8hp
        if(gm.playerHealth >= 8)
        {
            gm.playerHealth = 8;
        }

        //If playerHealth is <= 0 Run Death() function
        if(gm.playerHealth <= 0)
        {
            audioSource.clip = dead;
            audioSource.Play();
            gm.Death();
        }

        healthBar.GetComponent<Slider>().value = gm.playerHealth;

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
            onFire = false;
        }

        //when hit with fireball player will be on fire and get delt .5 damage
        if (onFire == true)
        {
            gm.playerHealth -= .50f * Time.deltaTime;
        }

        Controls();
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
            hitFlashStart();
        }
    }
    //---------------------------------------------------------------
    //change colour when hit
    void hitFlashStart()
    {
        spriteRenderer.material.color = Color.red;
        Invoke("hitFlashStop", hitTime);
    }

    void hitFlashStop()
    {
        spriteRenderer.material.color = origColor;
    }
    //---------------------------------------------------------------

    //Damage to player from enemies
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitsound = Random.Range(1, 2);
        if(hitsound == 1)
        {
            audioSource.clip = hit1;
        }
        if (hitsound == 2)
        {
            audioSource.clip = hit2;
        }

        if (collision.gameObject.tag == "RowB" || collision.gameObject.tag == "EnemyBull" || collision.gameObject.tag == "Manowar" || collision.gameObject.tag == "SwivelBull")
        {
            gm.playerHealth -= 1;
            hit = true;
            audioSource.Play();
        }
        else if(collision.gameObject.tag == "Brig")
        {
            gm.playerHealth -= 2;
            hit = true;
            audioSource.Play();
        }
        else if(collision.gameObject.tag == "Gal")
        {
            gm.playerHealth -= 3;
            hit = true;
            audioSource.Play();
        }
        if (collision.gameObject.tag == "Flame")
        {
            hit = true;
            onFire = true;
            audioSource.Play();
        }
        //collision for power-ups
        if (collision.gameObject.tag == "Life")
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
