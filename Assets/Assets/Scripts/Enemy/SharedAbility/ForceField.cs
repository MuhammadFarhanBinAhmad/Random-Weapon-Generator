using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HurtEnemy")
        {
            other.GetComponent<BulletStats>().Destroy();
            print("hit");
        }

    }
}
