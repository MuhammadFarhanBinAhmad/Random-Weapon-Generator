using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalRocket : MonoBehaviour
{
    //public List<BaseEnemy> enemy_In_Smoke = new List<BaseEnemy>();

    public int element_Type;

    private void Start()
    {
        Invoke("Destroy", 1);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseEnemy>() != null)
        {
            other.GetComponent<BaseEnemy>().debuff_Timer = 10;//set timer
            other.GetComponent<BaseEnemy>().currently_Elemental_Damage_Type = element_Type;
        }
    }

}
