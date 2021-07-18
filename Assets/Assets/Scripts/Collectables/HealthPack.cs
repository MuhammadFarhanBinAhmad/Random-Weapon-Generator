using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{

    public float health_To_Give;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            PlayerManager PM = other.GetComponent<PlayerManager>();
            if (PM.health_Player_Current <= PM.health_Player)
            {
                PM.health_Player_Current += health_To_Give;
                FindObjectOfType<PlayerUIHUD>().HealthUpdate();
            }
            Destroy(gameObject);
        }
    }
}
