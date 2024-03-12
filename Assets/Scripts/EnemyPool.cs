using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 5;

    private List<GameObject> pooledEnemies = new List<GameObject>();

    private void Start()
    {
        // Populate the enemy pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.SetActive(false);
            pooledEnemies.Add(enemy);
        }
    }

    // Method to get an inactive enemy from the pool
    public GameObject GetPooledEnemy()
    {
        foreach (GameObject enemy in pooledEnemies)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null; // No inactive enemy found
    }
}
