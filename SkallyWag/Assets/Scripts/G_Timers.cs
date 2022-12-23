using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Timers : MonoBehaviour
{
    public P_B_Joystk bJoy;
    public P_JoyStk pjoy;

    public GameObject enemySpawner, boss;

    public bool bossFight = false;
    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossFight == false)
        {
            timer = timer -= 1 * Time.deltaTime;
            pjoy.enabled = true;
            bJoy.enabled = false;
            enemySpawner.SetActive(true);
        }

        if (bossFight == true)
        {
            pjoy.enabled = false;
            bJoy.enabled = true;
            enemySpawner.SetActive(false);
        }

        if(timer <= 0)
        {
            StartBoss();
        }
    }

    void StartBoss()
    {
            bossFight = true;
    }
}
