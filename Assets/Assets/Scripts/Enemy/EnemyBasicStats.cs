using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicStats : MonoBehaviour
{


    public EnemyBasicStatsSO EBSSO;

    public int unit_Speed, unit_Health, unit_Damage;

    public bool destroy_Parent;

    private void Start()
    {
        unit_Speed = EBSSO.speed;
        unit_Health = EBSSO.health;
        unit_Damage = EBSSO.damage;

    }

    internal void TakingDamage(int dmg)
    {
        unit_Health -= dmg;
        if (unit_Health <= 0)
        {
            GetComponent<DropCollectables>().SpawnCollectables();
            if(!destroy_Parent)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
