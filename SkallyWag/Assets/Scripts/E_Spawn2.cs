using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Spawn2 : MonoBehaviour
{
    public GameObject RowB, Brig, Gal;
    public int spawnNum;
    float spawnPointX;
    float spawnPointY = 9.5f;


    public float timer = 3.0f;
    public float secondTimer;
    public float gameTimer = 0f;


    private Vector2 screenBounds;
    public Camera mainCam;

    private void Start()
    {
        secondTimer = 3.0f;

        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
    }


    void Update()
    {

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
