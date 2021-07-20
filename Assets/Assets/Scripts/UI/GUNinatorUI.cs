using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GUNinatorUI : MonoBehaviour
{

    GUNINATORGunCreation the_GGC;
    public TextMeshProUGUI total_Weapon_Cost;

    [Header("Weapon Lock Buttons")]
    public List<bool> weapon_Unlock = new List<bool>();
    public List<bool> rarity_Unlock = new List<bool>();
    public List<bool> round_Unlock = new List<bool>();
    public List<bool> element_Unlock = new List<bool>();

    private void Start()
    {
        the_GGC = GetComponent<GUNINATORGunCreation>();
    }

    public void UpdateWeaponCost()
    {
        total_Weapon_Cost.text = "Total Cost: " + the_GGC.w_Total_Cost.ToString();
    }
}
