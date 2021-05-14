using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceSensor : MonoBehaviour
{

    public Room the_Room;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() != null && the_Room.room_Completed)
        {

        }
    }
}
