using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Timers : MonoBehaviour
{
    public P_JoyStk pjoy;

    public GameObject enemySpawner, boss;

    public bool bossFight = false;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if the boss fight isn't triggered yet, the timer will countdown from 1 minute and enemies will spawn like normal
         if(bossFight == false)
         {
             timer = timer -= 1 * Time.deltaTime;
             enemySpawner.SetActive(true);
         }

         //if boss fight is triggered the timer will reset back to 60 and the enemies will stop spawning like normal
         if (bossFight == true)
         {
             timer = 60f;
             enemySpawner.SetActive(false);
         }
         //if the timer reaches 0 spawn the boss and set 'bossfight' to true
         if(timer <= 0)
         {
             StartBoss();
            boss.SetActive(true);
         }
     }

    //function for triggering the boss fight
     void StartBoss()
     {
             bossFight = true;
     }
    }
