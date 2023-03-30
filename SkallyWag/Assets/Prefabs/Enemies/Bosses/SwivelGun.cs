using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwivelGun : MonoBehaviour
{
    //Variables for rotating(Looking at player)
    public Transform player;
    private Rigidbody2D rb;

    public GameObject bullet;
    public GameObject bp;
    public float fireRate;
    public float pauseFire;
    public float firingTime;
    bool ableToShoot;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        fireRate = .5f;
        pauseFire = 2f;
        firingTime = 2f;
        ableToShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate switvelgun to player
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90f;

        //Firing at the player 
        if (ableToShoot == true)
        {
            fireRate = fireRate - 1 * Time.deltaTime;
            firingTime = firingTime - 1 * Time.deltaTime;
            if (fireRate <= 0)
            {
                Fire();
                fireRate = .5f;
            }
        }
        else if (ableToShoot == false)
        {
            pauseFire = pauseFire - 1 * Time.deltaTime;
            fireRate = .5f;
            firingTime = 2f;
        }
        if (pauseFire <= 0f)
        {
            ableToShoot = true;
        }
        if(firingTime <= 0)
        {
            ableToShoot = false;
            pauseFire = 2f;
        }
    }

    void Fire()
    {
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        
    }
}
