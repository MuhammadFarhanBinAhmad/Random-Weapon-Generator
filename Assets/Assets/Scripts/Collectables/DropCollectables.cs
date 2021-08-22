using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollectables : MonoBehaviour
{
    /// <summary>
    /// 0 - health pack
    /// 1 - ammo pack
    /// 2 - money
    /// </summary>
    public List<GameObject> droppable_Collectables = new List<GameObject>();
    public List<int> amount_Of_Drop = new List<int>();


    internal void SpawnCollectables()
    {
        Vector3 v = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

        //drop the collectable items
        for (int i = 0; i < droppable_Collectables.Count; i++)
        {
            for (int I = 0; I < amount_Of_Drop[i]; I++)
            {
                GameObject DC = Instantiate(droppable_Collectables[i], v, transform.parent.rotation);
                DC.GetComponent<Rigidbody>().AddForce(transform.up * 50);
            }
        }
    }
}
