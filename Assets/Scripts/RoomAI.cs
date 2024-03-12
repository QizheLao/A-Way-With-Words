using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomAI : MonoBehaviour
{
    public EnemyPool pool;
    public List<GameObject> doors;
    public bool cleared = false;
    public bool spawned = false;

    private void Update()
    {
        if(!pool.AnyActiveEnemies())
        {
            OpenDoor();
        }
    }
    public void CloseDoor()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }

        pool.SpawnEnemies();
    }

    private void OpenDoor()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
        cleared = true;
    }
}
