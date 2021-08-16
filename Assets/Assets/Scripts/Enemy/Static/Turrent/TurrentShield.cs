using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HurtEnemy")
        {
            other.GetComponent<BulletStats>().Destroy();
        }
    }
}
