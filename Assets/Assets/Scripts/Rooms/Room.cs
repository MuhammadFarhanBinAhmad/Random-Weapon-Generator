using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    RoomSpawner the_RM;

    public bool door_Lock;
    public bool room_Completed;

    bool next_Room_Spawn;
    public Transform t_Spawner;
    private void Start()
    {
        the_RM = FindObjectOfType<RoomSpawner>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !next_Room_Spawn)
        {
            SpawnRoom();
            next_Room_Spawn = true;
        }
    }

    void SpawnRoom()
    {
        if (room_Completed)
        {
            GameObject R = the_RM.Room[Random.Range(0, the_RM.Room.Count)];
            Instantiate(R, t_Spawner.position, t_Spawner.rotation);
        }
        else
        {
            print("Objective not completed");
        }
    }

}
