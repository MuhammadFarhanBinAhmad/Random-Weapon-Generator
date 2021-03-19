using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSmoke : MonoBehaviour
{

    public List<BaseEnemy> enemy_In_Smoke = new List<BaseEnemy>();

    private void Start()
    {
        enemy_In_Smoke.Add(transform.parent.GetComponent<BaseEnemy>());
        InvokeRepeating("TakingDamage", 0, 1);
        Invoke("Destroy", 10);//delete itself after a certain time has pass
    }

    void TakingDamage()
    {
        for (int i = 0; i <= enemy_In_Smoke.Count-1; i++)
        {
            enemy_In_Smoke[i].TakingDamage(5);
            print("TakingDamage");
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseEnemy>() !=null)
        {
            enemy_In_Smoke.Add(other.GetComponent<BaseEnemy>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BaseEnemy>() != null)
        {
            enemy_In_Smoke.Remove(other.GetComponent<BaseEnemy>());
        }
    }
}
