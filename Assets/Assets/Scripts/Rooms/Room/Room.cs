using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Room : MonoBehaviour
{
    RoomSpawner the_RS;
    public NavMeshSurface the_NMS;
    public EntranceSensor the_ES;

    public bool door_Lock;
    public bool room_Completed;

    bool next_Room_Spawn;

    public List<GameObject> enemy_Left = new List<GameObject>();
    private void Start()
    {
        the_RS = FindObjectOfType<RoomSpawner>();
        the_NMS = FindObjectOfType<NavMeshSurface>();
        //the_NMS.BuildNavMesh();

        foreach(GameObject GO in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (GO.tag == "Enemy")
            {
                enemy_Left.Add(GO);
            }
        }
    }
    public void CheckEnemy()
    {
        if (enemy_Left.Count == 0)
        {
            room_Completed = true;
        }
        else
        {
            print(enemy_Left.Count);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() !=null)
        {
            the_ES.the_anim.SetTrigger("CloseDoor");
        }
    }

}
