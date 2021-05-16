using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Room : MonoBehaviour
{

    RoomSpawner the_RM;
    NavMeshSurface the_NMS;

    public bool door_Lock;
    public bool room_Completed;

    bool next_Room_Spawn;
    public Transform t_Spawner;
    private void Start()
    {
        the_RM = FindObjectOfType<RoomSpawner>();
        the_NMS = FindObjectOfType<NavMeshSurface>();


        the_NMS.BuildNavMesh();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !next_Room_Spawn)
        {
            SpawnRoom();
            next_Room_Spawn = true;
            //For test only//
            if (FindObjectOfType<RoomSpawner>() != null)
            {
                FindObjectOfType<RoomSpawner>().room_Currently_Spawn.Add(this);
                FindObjectOfType<RoomSpawner>().CheckTotalRoom();
            }
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
