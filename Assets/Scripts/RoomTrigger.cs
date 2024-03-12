using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public RoomAI room;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.CompareTag("player") && !room.cleared && !room.spawned)
        {
            Debug.Log(other.tag);
            room.CloseDoor();
        }
    }
}
