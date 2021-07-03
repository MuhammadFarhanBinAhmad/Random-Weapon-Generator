using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPool : MonoBehaviour
{

    public List<GameObject> Rooms = new List<GameObject>();
    internal List<GameObject> room_Pool = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int r = 0; r < Rooms.Count; r++)
        {
            for (int i = 0; i <= 1; i++)
            {
                GameObject R = Instantiate(Rooms[r]);
                room_Pool.Add(R);
                R.SetActive(false);
                //GameObject.DontDestroyOnLoad(R);
            }
        }
    }
}
