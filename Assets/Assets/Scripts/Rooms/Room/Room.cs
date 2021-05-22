using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Room : MonoBehaviour
{
    RoomSpawner the_RS;
    NavMeshSurface the_NMS;

    public bool door_Lock;
    public bool room_Completed;

    bool next_Room_Spawn;
    //public Transform t_Spawner;*In Tunnel now

    private void Start()
    {
        the_RS = FindObjectOfType<RoomSpawner>();
        the_NMS = FindObjectOfType<NavMeshSurface>();
        //the_NMS.BuildNavMesh();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !next_Room_Spawn && room_Completed)
        {
            next_Room_Spawn = true;
            //the_RS.SpawnTunnel();
            //the_RS.SpawnRoom();
            //the_RS.CheckTotalRoom();
            /*//For test only//
            if (FindObjectOfType<RoomSpawner>() != null)
            {
                FindObjectOfType<RoomSpawner>().room_Currently_Spawn.Add(this);
                FindObjectOfType<RoomSpawner>().CheckTotalRoom();
            }*/
        }
    }

    /*void SpawnRoom()
    {
        if (room_Completed)
        {
            int r = Random.Range(0, the_RP.room_Pool.Count);
            if (!the_RP.room_Pool[r].activeInHierarchy)
            {
                the_RP.room_Pool[r].transform.position = 
            }
        }
        else
        {
            print("Objective not completed");
        }
    }*/

}
