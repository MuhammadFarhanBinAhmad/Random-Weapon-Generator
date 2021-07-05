using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPool : MonoBehaviour
{

    public List<GameObject> Rooms = new List<GameObject>();
    internal List<GameObject> room_Pool = new List<GameObject>();


    /*public List<int> room_To_Spawn = new List<int>();
    public int number_Of_Rooms_To_Spawned;//number of room to spawn in this level
    int rooms_Spawned;*/
    // Start is called before the first frame update
    void Start()
    {
        for (int r = 0; r < Rooms.Count; r++)
        {
            //spawn multiple room of same type
            /*for (int i = 0; i <= 1; i++)
            {
                GameObject R = Instantiate(Rooms[r]);
                room_Pool.Add(R);
                R.SetActive(false);
                //GameObject.DontDestroyOnLoad(R);
            }*/
            GameObject R = Instantiate(Rooms[r]);
            room_Pool.Add(R);
            R.SetActive(false);
        }
    }
        /*SpawnRoom();

    }
    void SpawnRoom()
    {
        room_To_Spawn.Add(Random.Range(0, Rooms.Count - 1));

        for (rooms_Spawned = 0; rooms_Spawned <= number_Of_Rooms_To_Spawned; rooms_Spawned++)
        {
            int RR = Random.Range(0, Rooms.Count);
            for (int i =0; i <= room_To_Spawn.Count;  i++)
            {
                if (RR == room_To_Spawn[i])
                {
                    SpawnRoom();
                    break;
                }
            }
            room_To_Spawn.Add(RR);
            rooms_Spawned++;

        }
    }*/
}
