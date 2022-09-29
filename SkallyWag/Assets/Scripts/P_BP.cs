using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_BP : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 0f;

    public GameObject bp1;
    public GameObject bp2;

    public P_JoyStk joystick;

    /// <summary>
    /// ////
    /// </summary>
    public bool fireRateActive = false;
    public float fireRateTimer;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        Fire();
        
        /////////////
        if (fireRateActive == true)
        {
            fireRateTimer -= Time.deltaTime;
        }
        if (fireRateTimer <= 0)
        {
            fireRateActive = false;
            fireRateTimer = 10.0f;
        }
    }

    public void Fire()
    {
        if (fireRate <= 0)
        {
            if (fireRateActive == true)
            {
                fireRate = 0.2f;
            }
            else { fireRate = 0.5f; }

            
#pragma warning disable CS0618 // Type or member is obsolete
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.EulerRotation(new Vector3(0,0, transform.rotation.z)));
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
