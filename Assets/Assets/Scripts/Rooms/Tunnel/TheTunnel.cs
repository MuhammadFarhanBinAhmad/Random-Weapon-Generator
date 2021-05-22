using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheTunnel : MonoBehaviour
{
    public Transform t_Spawner;

    public EntranceSensor the_EntranceSensor;


    public void SpawnNextRoom()
    {
        FindObjectOfType<RoomSpawner>().SpawnRoom();
    }
    public void DeSpawnPreviousRoom()
    {

    }
}
