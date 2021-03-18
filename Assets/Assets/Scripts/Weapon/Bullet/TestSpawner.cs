using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{

    public GameObject item_To_Spawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject ITS = Instantiate(item_To_Spawn, transform.position, transform.rotation);
        }
    }
}
