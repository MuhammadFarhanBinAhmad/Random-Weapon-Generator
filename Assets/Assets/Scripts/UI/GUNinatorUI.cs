using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GUNinatorUI : MonoBehaviour
{

    GUNINATORGunCreation the_GGC;
    public TextMeshProUGUI total_Weapon_Cost;

    private void Start()
    {
        the_GGC = GetComponent<GUNINATORGunCreation>();
    }

    public void UpdateWeaponCost()
    {
        total_Weapon_Cost.text = "Total Cost: " + the_GGC.w_Total_Cost.ToString();
    }
}
