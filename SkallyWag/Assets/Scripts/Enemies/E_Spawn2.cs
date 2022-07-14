using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Spawn2 : MonoBehaviour
{
    //Variables for enemies and spawn points
    public GameObject RowB, Brig, Gal;
    public int spawnNum;
    float spawnPointX;
    float spawnPointY = 9.5f;

    //Variables for timers
    public float timer = 3.0f;
    public float secondTimer;
    public float gameTimer = 0f;

    //Variables for setting screen bounds
    private Vector2 screenBounds;
    public Camera mainCam;

    private void Start()
    {
        secondTimer = 3.0f;

        //Set screen bounds to the main camera
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
    }


    void Update()
    {
        //Spawning an enemy whenever 'timer' == 0
        //Selecting which enemy to spawn
        //Spawning selected enemy at a random point at the top of the screen
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemies();
            timer = secondTimer;
            spawnNum = Random.Range(0, 3);
            spawnPointX = Random.Range(-3.44f, 3.48f);
        }

        Timers();
    }

    //Function for selecting an enemy and spawning them at a certain point on the screen
    void SpawnEnemies()
    {
        if(spawnNum == 0)
        {
            Instantiate(RowB, new Vector2(spawnPointX, spawnPointY), Quaternion.identity);
            if(gameTimer >= 40)
            {
                Instantiate(RowB, new Vector2(Random.Range(-3.44f, 3.48f), spawnPointY), Quaternion.identity);
            }
        }
        else if(spawnNum == 1)
        {
            Instantiate(Brig, new Vector2(spawnPointX, spawnPointY), Quaternion.identity);
            if (gameTimer >= 40)
            {
                Instantiate(RowB, new Vector2(Random.Range(-3.44f, 3.48f), spawnPointY), Quaternion.identity);
            }
        }
        else if(spawnNum == 2)
        {
            Instantiate(Gal, new Vector2(spawnPointX, spawnPointY), Quaternion.identity);
            if (gameTimer >= 40)
            {
                Instantiate(RowB, new Vector2(Random.Range(-3.44f, 3.48f), spawnPointY), Quaternion.identity);
            }
        }
    }

    //These are the timers used to spawning enemies and speeding up the spawn rate
    void Timers()
    {
        gameTimer += Time.deltaTime;
        if (gameTimer >= 10.0f)
        {
            secondTimer = 2.5f;
        }
        if (gameTimer >= 20.0f)
        {
            secondTimer = 2.0f;
        }
        if (gameTimer >= 30.0f)
        {
            secondTimer = 1.0f;
        }
    }
}
