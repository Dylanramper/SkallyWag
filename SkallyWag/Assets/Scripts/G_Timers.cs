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
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
         if(bossFight == false)
         {
             timer = timer -= 1 * Time.deltaTime;
             enemySpawner.SetActive(true);
         }

         if (bossFight == true)
         {
             timer = 60f;
             enemySpawner.SetActive(false);
         }

         if(timer <= 0)
         {
             StartBoss();
             Instantiate(boss, new Vector2(0, 12f), Quaternion.identity);
         }
     }

     void StartBoss()
     {
             bossFight = true;
     }
    }
