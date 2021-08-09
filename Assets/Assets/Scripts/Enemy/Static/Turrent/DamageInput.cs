using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInput : MonoBehaviour
{

    public GameObject explosion_Effect;

    internal EnemyBasicStats the_EBS;
    private void Start()
    {
        the_EBS = GetComponent<EnemyBasicStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletStats>() != null && other.GetComponent<BulletStats>().tag == "HurtEnemy")
        {
            //Instantiate(explosion_Effect, transform.position, transform.rotation);
            FindObjectOfType<Room>().enemy_Left.Remove(this.transform.parent.gameObject);
            FindObjectOfType<Room>().CheckEnemy();
            the_EBS.TakingDamage(other.GetComponent<BulletStats>().bullet_Damage);
            if (the_EBS.unit_Health <= 0)
            {
                Instantiate(explosion_Effect, transform.position, transform.rotation);
            }
            other.GetComponent<BulletStats>().Destroy();
            /*GetComponent<DropCollectables>().SpawnCollectables();
            Destroy(transform.parent.gameObject);*/
        }
    }
}
