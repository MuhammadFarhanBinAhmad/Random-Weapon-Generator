using UnityEngine;

[CreateAssetMenu(fileName = "WeaponName", menuName = "BasicStats/BasicWeaponValue", order = 1)]
public class WeaponData : ScriptableObject
{
    public string weapon_Name;
    public float fire_Rate;
    public float reload_Time;
    public float damage;
    public int total_Ammo;
    public int mag_Capacity;
}
