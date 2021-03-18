using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIHUD : MonoBehaviour
{
    //PLAYER HUG//
    public TextMeshProUGUI ui_Weapon_Ammo,ui_Weapon_Name, ui_Total_Ammo;
    public BaseGun current_Weapon;
    //PLAYER/GAME UI//
    public GameObject PauseMenu;
    bool menu_Open;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menu_Open)
            {
                Cursor.lockState = CursorLockMode.None;
                menu_Open = true;
                PauseMenu.SetActive(true);
                Time.timeScale = 0;

            }
            else if (menu_Open)
            {
                Cursor.lockState = CursorLockMode.Locked;
                menu_Open = false;
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    internal void AmmoUpdate(int i)
    {
        ui_Weapon_Ammo.text = current_Weapon.gun_current_Mag_Capacity.ToString();//Mag
        ui_Total_Ammo.text = current_Weapon.gun_Total_Ammo.ToString();//Ammo
    }
    internal void WeaponNameUpdate(int i)
    {
        //ui_Weapon_Name.text = current_Weapon.the_Weapon_States.weapon_Name.ToString();//Weapon Name
    }
}
