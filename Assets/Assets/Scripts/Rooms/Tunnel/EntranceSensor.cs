﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceSensor : MonoBehaviour
{
    ///Script summary///
    //To despawn the previous room

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            FindObjectOfType<RoomSpawner>().DeSpawnRoom();
            //transform.parent.gameObject.SetActive(false);
        }
    }
}