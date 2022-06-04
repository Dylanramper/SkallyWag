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

    private void Start()
    {
        spawnPointX = Random.Range(-3.44f, 3.48f);
        secondTimer = 3.0f;
        RowB.SetActive(false);
        Brig.SetActive(false);
        Gal.SetActive(false);
    }


    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemies();
            timer = secondTimer;
            spawnNum = Random.Range(0, 3);
        }

        Timers();
    }


    void SpawnEnemies()
    {
        if(spawnNum == 0)
        {
            RowB.SetActive(true);
            RowB.transform.position = new Vector2(spawnPointX, spawnPointY);
            Debug.Log("Spawn");
        }
        else if(spawnNum == 1)
        {
            Brig.SetActive(true);
            Brig.transform.position = new Vector2(spawnPointX, spawnPointY);
        }
        else if(spawnNum == 2)
        {
            Gal.SetActive(true);
            Gal.transform.position = new Vector2(spawnPointX, spawnPointY);
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
