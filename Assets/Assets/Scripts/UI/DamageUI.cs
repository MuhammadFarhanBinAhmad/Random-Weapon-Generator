using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageUI : MonoBehaviour
{
    public TextMeshProUGUI damage_UI;

    private void Start()
    {
        Invoke("DestroySelf", 1);
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z);
    }
        
    void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void DamageText(float dmg)
    {
        float damage = dmg;
        print(damage);
        if (damage_UI !=null)
        {
            damage_UI.text = damage.ToString();
        }
        else
        {
            print("Text not found");
        }
    }
}
