using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBattery : MonoBehaviour
{

    public GameObject explosion_Effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletStats>() != null)
        {
            Instantiate(explosion_Effect, transform.position, transform.rotation);
            FindObjectOfType<Room>().enemy_Left.Remove(this.transform.parent.gameObject);
            FindObjectOfType<Room>().CheckEnemy();
            Destroy(transform.parent.gameObject);
        }
    }
}
