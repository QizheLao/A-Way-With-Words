using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomAI : MonoBehaviour
{
    public GameObject enterDoor;
    public GameObject exitDoor;
    public GameObject exitDoor2;
    public bool doors;

    private bool playerExited = false;
    private int enemyAlive;
    private void OnTriggerEnter(Collider other)
    {
        playerExited = false;
        //ebug.Log("object:" + other.tag);
        enemyAlive = EnemyAi.totalEnemies;
        if (other.CompareTag("player") && !playerExited)
        {

           enemyAlive = EnemyAi.totalEnemies - 5;

         //Debug.Log("enemyAlive: " + enemyAlive);
            playerExited = true;
            CloseEnterDoor();
        }
    }
    private void Update()
    {
        UpdateEnemyCount();
    }
    private void CloseEnterDoor()
    {
        enterDoor.SetActive(true);
    }

    private void UpdateEnemyCount()
    {
        //Debug.Log("enemyAlive: " + enemyAlive);
      //Debug.Log("totalEnemies: " + EnemyAi.totalEnemies);
        if (EnemyAi.totalEnemies <= enemyAlive && playerExited)
        {
            OpenExitDoor();
        }
    }
    private void OpenExitDoor()
    {
        enemyAlive = EnemyAi.totalEnemies - 5;
      //Debug.Log("enemyAlive next: " + enemyAlive);
      //Debug.Log("Cleared Room");
        if (doors)
        {
            exitDoor2.SetActive(false);

        }
        exitDoor.SetActive(false);
    }
}
