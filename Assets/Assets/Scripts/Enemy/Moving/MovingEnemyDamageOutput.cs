using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyDamageOutput : MonoBehaviour
{
    public EnemyBasicStats the_EBS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            other.GetComponent<PlayerManager>().TakeDamage(the_EBS.unit_Damage);
        }
    }
}
