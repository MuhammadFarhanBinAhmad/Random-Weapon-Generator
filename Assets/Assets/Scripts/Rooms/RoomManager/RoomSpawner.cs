using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    ///Script summary///
    ///Control the spawning and despawning of rooms

    public GameObject current_Room,cleared_Room;
    public GameObject room_Spawn_Point;
    public GameObject exit_Room;

    /// <summary>
    /// Element = current level
    /// Element value = room to complete
    /// </summary>
    public List<int> room_To_Complete = new List<int>();
    public static int current_Level;

    RoomPool the_RP;

    public int total_Room_Spawn;

    private void Start()
    {
        the_RP = FindObjectOfType<RoomPool>();
        SpawnRoom();

    }
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SpawnRoom();
        }
    }*/

    ///Function Job///
    ///Spawn new room
    public void SpawnRoom()
    {
        int r = Random.Range(0, the_RP.room_Pool.Count);
        if (total_Room_Spawn != room_To_Complete[current_Level])
        {
            //spawn room
            if (!the_RP.room_Pool[r].activeInHierarchy)
            {

                the_RP.room_Pool[r].SetActive(true);
                the_RP.room_Pool[r].transform.position = room_Spawn_Point.transform.position;
                if (current_Room != null)
                {
                    cleared_Room = current_Room;//Move current room to cleared room when room is cleared
                }
                current_Room = the_RP.room_Pool[r];
                room_Spawn_Point = current_Room.transform.Find("NextRoomSpawnPoint").gameObject;
                total_Room_Spawn++;
            }
            else
            {
                SpawnRoom();
            }
        }
        else
        {
            exit_Room.transform.position = room_Spawn_Point.transform.position;
            exit_Room.SetActive(true);
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
