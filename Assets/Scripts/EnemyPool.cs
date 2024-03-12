using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefabMelee;
    public GameObject enemyPrefabRange;
    public GameObject boss;
    public int poolSize = 5;

    public List<GameObject> pool;
    public Vector3[] spawnPositions;
    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj;
            Vector3 spawnPosition = spawnPositions[i];
            Debug.Log(spawnPosition);

            if (boss != null && i == poolSize - 1)
            {
                obj = Instantiate(boss, spawnPosition, Quaternion.identity);
            }
            else
            {
                int randomIndex = Random.Range(0, 2);
                obj = Instantiate(randomIndex == 0 ? enemyPrefabMelee : enemyPrefabRange, spawnPosition, Quaternion.identity);
            }
            
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return null;
    }

    public bool AnyActiveEnemies()
    {
        foreach (GameObject enemy in pool)
        {
            if (enemy.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }
    public void SpawnEnemies()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemyObject = GetPooledObject();
            if (enemyObject != null)
            {
                // Activate the enemyObject
                enemyObject.SetActive(true);
            }
        }
    }
}
