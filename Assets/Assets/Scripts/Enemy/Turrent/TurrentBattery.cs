using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBattery : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletStats>() != null)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
