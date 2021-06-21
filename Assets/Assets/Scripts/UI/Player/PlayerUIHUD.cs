using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIHUD : MonoBehaviour
{

    PlayerManager the_PM;
    //PLAYER HUD//
    public TextMeshProUGUI ui_Weapon_Ammo,ui_Weapon_Name, ui_Total_Ammo,ui_Total_Coins;
    public BaseGun current_Weapon;
    //PLAYER GAME UI//
    public GameObject PauseMenu;
    public GameObject GameOverScreen;
    bool menu_Open;
    public TextMeshProUGUI pickable_Weapon_Name_GUI;
    public Image p_HealthBar;

    private void Start()
    {
        the_PM = FindObjectOfType<PlayerManager>();
    }

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
        ui_Total_Coins.text = "X" + the_PM.money_Total.ToString();
    }

    internal void AmmoUpdate(int i)
    {
        ui_Weapon_Ammo.text = current_Weapon.gun_current_Mag_Capacity.ToString();//Mag
        ui_Total_Ammo.text = current_Weapon.gun_Total_Ammo.ToString();//Ammo
    }
    internal void WeaponNameUpdate(int i)
    {
        ui_Weapon_Name.text = current_Weapon.weapon_Name.ToString();//Weapon Name
    }
    internal void PickableWeaponDetails(string WN)
    {
        pickable_Weapon_Name_GUI.text = WN;
    }
    internal void HealthUpdate()
    {
        p_HealthBar.fillAmount = the_PM.health_Player_Current / the_PM.health_Player;
    }
    internal void GameOver()
    {
        GameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}
