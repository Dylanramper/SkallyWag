using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_o_W_Canons : MonoBehaviour
{
    public GameObject bullet;
    float fireRate;
    public float fireRateID;

    public GameObject bp1;
    public GameObject bp2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //firerate counting down to next cannon ball spawn
        fireRate -= Time.deltaTime;
        Fire();
    }

    public void Fire()
    {
        //Spawn the cannon ball when the firerate timer hits 0
        //then set the firerate to 1.25f
        if(fireRate <= 0)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.EulerRotation(new Vector3(0, 0, transform.rotation.z)));
#pragma warning restore CS0618 // Type or member is obsolete
            fireRate = fireRateID;
        }
    }
}
