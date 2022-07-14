using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Controls : MonoBehaviour
{
    public GameManager gm;

    public GameObject player;
    private Vector2 screenBounds;
    public Camera mainCam;

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    private float shipWidth;
    private float shipHeight;

    //Variables for object pooling bullets
    public Dictionary<string, Queue<GameObject>> bulletPool;
    public GameObject BulletPoint;

    public float fireRate = 0f;

    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int poolSize;
    }
    public List<Pool> pools;

    void Start()
    {
        //Set PlayerHealth to 3 lives
        gm.playerHealth = 3;

        //Getting Height and Width of screenPos and W/H of Player.
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
        shipWidth = transform.GetComponent<BoxCollider2D>().bounds.extents.x;
        shipHeight = transform.GetComponent<BoxCollider2D>().bounds.extents.y;

        //instancing bulletpool
        bulletPool = new Dictionary<string, Queue<GameObject>>();

        //store a certain amount of bullets in pool
        foreach (Pool bullet in pools)
        {
            Queue<GameObject> B_Pool = new Queue<GameObject>();

            for (int i = 0; i < bullet.poolSize; i++)
            {
                GameObject objPool = Instantiate(bullet.prefab);
                objPool.SetActive(false);
                B_Pool.Enqueue(objPool);
            }

            bulletPool.Add(bullet.name, B_Pool);
        }
    }
    

    void Update()
    {
        //Setting Bounds for the screen, relative to the player.
        Vector3 cameraPos = transform.position;
        cameraPos.x = Mathf.Clamp(cameraPos.x, screenBounds.x * -1 + shipWidth, screenBounds.x - shipWidth);
        cameraPos.y = Mathf.Clamp(cameraPos.y, screenBounds.y * -1 + shipHeight, screenBounds.y - shipHeight);

        transform.position = cameraPos;

        if(gm.playerHealth == 2)
        {
            health3.SetActive(false);
        }
        else if(gm.playerHealth == 1)
        {
            health2.SetActive(false);
        }

        //If playerHealth is <= 0 Run Death() function
        if(gm.playerHealth <= 0)
        {
            gm.Death();
        }
        Controls();
        fireRate -= Time.deltaTime;
        if(fireRate <= 0)
        {
            fireRate = 0;
        }
    }

    //Controls for Movement
    public void Controls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(new Vector2(0, 6 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(new Vector2(0, -6 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(new Vector2(-6 * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(new Vector2(6 * Time.deltaTime, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space) && fireRate == 0f)
        {
            fireRate = 0.5f;
            Fire();
        }
    }

    //Calling from the object pool
    public void Fire()
    {
        if(fireRate == 0)
        {
            fireRate = 0.5f;
            SpawnBullets("CannonBall", BulletPoint.transform.position);
        }
    }

    //Sete Bullet location to the player's point where it will spawn
    public GameObject SpawnBullets(string name, Vector2 position)
    {
        GameObject Objects = bulletPool[name].Dequeue();

        Objects.SetActive(true);
        Objects.transform.position = position;

        bulletPool[name].Enqueue(Objects);
        return Objects;
    }

    //Damage to player from enemies
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gm.playerHealth -= 1;
        }
    }
}
