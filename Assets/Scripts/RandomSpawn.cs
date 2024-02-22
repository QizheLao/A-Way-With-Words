using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{    public List<Vector3> spawnLocations;
    public int numberOfObjects;
    public GameObject letter;

    private List<int> unusedIndices;

    void Start()
    {
        unusedIndices = new List<int>();
        for (int i = 0; i < spawnLocations.Count; i++)
        {
            unusedIndices.Add(i);
        }
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            if (unusedIndices.Count == 0)
            {
                Debug.LogWarning("No more unused spawn locations available!");
                break;
            }

            int randomIndex = Random.Range(0, unusedIndices.Count);
            int spawnLocationIndex = unusedIndices[randomIndex];
            Vector3 spawnLocation = spawnLocations[spawnLocationIndex];

            Instantiate(letter, spawnLocation, Quaternion.identity);

            // Remove the used index from the unused list
            unusedIndices.RemoveAt(randomIndex);
        }
    }
}
