using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public List<GameObject> Room = new List<GameObject>();
    public List<Room> room_Currently_Spawn = new List<Room>();

    public void CheckTotalRoom()
    {
        //check how many room are present
        if (room_Currently_Spawn.Count >= 3)
        {
            Room r;
            r = room_Currently_Spawn[0];
            room_Currently_Spawn.Remove(room_Currently_Spawn[0]);
            Destroy(r.gameObject);
            r = null;
        }
    }
}
