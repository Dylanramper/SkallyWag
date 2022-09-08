using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_JoyStick : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public float moveSpeed = 7.0f;
    
    public bool fireRateActive = false;
    public float fireRateTimer;

    // Update is called once per frame
    void Update()
    {
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector2 dir = new Vector2(hoz, ver).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);

        if (fireRateActive == true)
        {
            fireRateTimer -= Time.deltaTime;
        }
        if(fireRateTimer <= 0)
        {
            fireRateActive = false;
            fireRateTimer = 10.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "rateoffire")
        {
            fireRateActive = true;
        }
    }
}
