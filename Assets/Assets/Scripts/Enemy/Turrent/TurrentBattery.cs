using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentBattery : EnemyBasicStats
{

    public GameObject explosion_Effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletStats>() != null && other.GetComponent<BulletStats>().tag == "HurtEnemy")
        {
            //Instantiate(explosion_Effect, transform.position, transform.rotation);
            FindObjectOfType<Room>().enemy_Left.Remove(this.transform.parent.gameObject);
            FindObjectOfType<Room>().CheckEnemy();
            TakingDamage(other.GetComponent<BulletStats>().bullet_Damage);
            if (unit_Health <= 0)
            {
                Instantiate(explosion_Effect, transform.position, transform.rotation);
            }
            /*GetComponent<DropCollectables>().SpawnCollectables();
            Destroy(transform.parent.gameObject);*/
        }
    }
}
