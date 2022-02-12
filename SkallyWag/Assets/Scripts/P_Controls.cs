using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Controls : MonoBehaviour
{
    public GameObject player;
    private Vector2 screenBounds;
    public Camera mainCam;

    private float shipWidth;
    private float shipHeight;

    private int pHealth;
    public bool isAlive = true;

    //Variables for object pooling bullets
    public Dictionary<string, Queue<GameObject>> bulletPool;
    public GameObject BulletPoint;

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
        pHealth = 3;

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

        Controls();
        Fire();
        Death();
    }


    //Controls for Movement
    public void Controls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(new Vector2(0, 10 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(new Vector2(0, -10 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(new Vector2(-10 * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(new Vector2(10 * Time.deltaTime, 0));
        }
    }

    //Calling from the object pool
    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullets("CannonBall", BulletPoint.transform.position);
        }

    }

    void Death()
    {
        if (pHealth == 0)
        {
            isAlive = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            pHealth = pHealth - 1;


            Debug.Log(pHealth);
        }
    }
}
