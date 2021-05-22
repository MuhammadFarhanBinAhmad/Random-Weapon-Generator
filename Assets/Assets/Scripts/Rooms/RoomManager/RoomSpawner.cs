using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    ///Script summary///
    ///Control the spawning and despawning of rooms

    public GameObject current_Room,cleared_Room;
    public GameObject room_Spawn_Point;

    RoomPool the_RP;

    public int total_Room_Spawn;

    private void Start()
    {
        the_RP = FindObjectOfType<RoomPool>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SpawnRoom();
        }
    }

    ///Function Job///
    ///Spawn new room
    public void SpawnRoom()
    {
        int r = Random.Range(0, the_RP.room_Pool.Count);
        if (!the_RP.room_Pool[r].activeInHierarchy)
        {

            the_RP.room_Pool[r].SetActive(true);
            the_RP.room_Pool[r].transform.position = room_Spawn_Point.transform.position;
            if (current_Room !=null)
            {
                cleared_Room = current_Room;//Move current room to cleared room when room is cleared
            }
            current_Room = the_RP.room_Pool[r];
            room_Spawn_Point = current_Room.transform.Find("RoomSpawnPoint").gameObject;
            total_Room_Spawn++;
        }
        else
        {
            SpawnRoom();
        }
    }

    ///Script summary///
    ///Despawn cleared room
    public void DeSpawnRoom()
    {
        {
            //Remove the previous room
            if (cleared_Room != null)
            {
                cleared_Room.SetActive(false);
                cleared_Room = null;
            }
        }
    }
}
