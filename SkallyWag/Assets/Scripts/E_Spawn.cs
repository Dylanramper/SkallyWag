using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Spawn : MonoBehaviour
{
    //Variables for object pooling enemies
    public Dictionary<string, Queue<GameObject>> enemyPool;
    public GameObject EnemySpawn;

    //Variables to spawn enemies at locations
    float spawnPointX;
    float spawnPointY = 9.5f;

    //Timer Variables
    public float timer = 3.0f;
    public float secondTimer;
    public float gameTimer = 0f;

    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int poolSize;
    }
    public List<Pool> pools;
    

    // Start is called before the first frame update
    void Start()
    {
        secondTimer = 3.0f;

        //instancing Enemypool
        enemyPool = new Dictionary<string, Queue<GameObject>>();

        //store a certain amount of enemies in pool
        foreach (Pool enemy in pools)
        {
            Queue<GameObject> E_Pool = new Queue<GameObject>();

            for (int i = 0; i < enemy.poolSize; i++)
            {
                GameObject objPool = Instantiate(enemy.prefab);
                objPool.SetActive(false);
                E_Pool.Enqueue(objPool);
            }

            enemyPool.Add(enemy.name, E_Pool);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnPointX = Random.Range(-3.44f, 3.48f);

        //countdown to next enemy spawn
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            EndTimer();
        }

        Timers();
    }

    //Calling from enemypool
    public GameObject SpawnEnemies(string name, Vector2 position)
    {
        GameObject Objects = enemyPool[name].Dequeue();

        Objects.SetActive(true);
        Objects.transform.position = position;

        enemyPool[name].Enqueue(Objects);
        return Objects;
    }

    //function for spawning enemies at random spawnpoints and reseting the timer
    void EndTimer()
    {
        SpawnEnemies("Enemy", EnemySpawn.transform.position = new Vector2 (spawnPointX, spawnPointY));
        timer = secondTimer;

        //spawn addition enemy after 40 seconds
        if(gameTimer >= 40.0f)
        {
            GameObject SpawnEnemies(string name, Vector2 position)
            {
                GameObject Objects = enemyPool[name].Dequeue();

                Objects.SetActive(true);
                Objects.transform.position = position;

                enemyPool[name].Enqueue(Objects);
                return Objects;
            }
            SpawnEnemies("Enemy", EnemySpawn.transform.position = new Vector2(spawnPointX, spawnPointY));
        }
    }

    //slowly speed up the timer every 10 seconds
    void Timers()
    {
        gameTimer += Time.deltaTime;
        if (gameTimer >= 10.0f)
        {
            secondTimer = 2.5f;
        }
        if (gameTimer >= 20.0f)
        {
            secondTimer = 2.0f;
        }
        if (gameTimer >= 30.0f)
        {
            secondTimer = 1.0f;
        }
    }
}
