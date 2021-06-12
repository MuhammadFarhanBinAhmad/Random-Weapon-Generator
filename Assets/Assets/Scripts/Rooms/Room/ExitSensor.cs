using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSensor : MonoBehaviour
{
    public Animator the_anim;

    Room the_Room;
    private void Start()
    {
        the_anim = GetComponent<Animator>();
        the_Room = FindObjectOfType<Room>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            if (the_Room.room_Completed)
            {
                FindObjectOfType<RoomSpawner>().SpawnRoom();
                the_anim.SetTrigger("OpenDoor");
            }
        }
    }
}
