using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int min_Value,max_Value;
    int value_To_Give;

    int multiplier = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerManager>() != null)
        {
            value_To_Give = Random.Range(min_Value, max_Value);
            other.GetComponent<PlayerManager>().money_Total += value_To_Give * multiplier;
            Destroy(gameObject);
        }
    }
}
