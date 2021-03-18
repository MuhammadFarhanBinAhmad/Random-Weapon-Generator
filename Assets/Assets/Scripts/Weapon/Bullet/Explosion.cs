using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseEnemy>())
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(75, transform.position,1);
        }
    }
}
