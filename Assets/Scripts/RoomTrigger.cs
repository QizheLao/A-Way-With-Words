using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public RoomAI room;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.CompareTag("player"))
        {
            //Debug.Log(other.tag);
            Destroy(gameObject, 0f);
            room.CloseDoor();
        }
    }
}
