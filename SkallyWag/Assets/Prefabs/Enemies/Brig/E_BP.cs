using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_BP : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 1.5f;

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        Fire();
    }

    public void Fire()
    {
        if (fireRate <= 0)
        {
            fireRate = 1.5f;

            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(new Vector3(0, 0, transform.rotation.z)));

            //Time.timeScale = 0f;
        }
    }
}
