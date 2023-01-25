using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_o_W_Canons : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 0.2f;

    public GameObject bp1;
    public GameObject bp2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        Fire();
    }

    public void Fire()
    {
        if(fireRate <= 0)
        {
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            fireRate = 0.2f;
        }
    }
}
