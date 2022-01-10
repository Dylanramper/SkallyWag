using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Spawn : MonoBehaviour
{
    //Variables for object pooling enemies
    public Dictionary<string, Queue<GameObject>> enemyPool;
    public GameObject EnemySpawn;

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
        StartCoroutine(ExecuteAfterTime(10));
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

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        SpawnEnemies("Enemy", EnemySpawn.transform.position = new Vector2(Random.Range(-8.67f, 8.01f), 5.75f));
    }
}
