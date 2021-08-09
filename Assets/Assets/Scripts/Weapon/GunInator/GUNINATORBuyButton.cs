using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUNINATORBuyButton : MonoBehaviour
{
    RandomWeaponGenerator the_RWG;
    PlayerManager the_PM;

    public GameObject lock_Button;

    public int item_Cost;
    /// <summary>
    /// 0 - Weapon
    /// 1 - Rarity
    /// 2 - Element
    /// 3 - Round
    /// </summary>
    [Header("Weapon/Rarity/Element/Round")]
    public int item;//choose between Weapon,Rarity,Element,Rounds
    private void Start()
    {
        the_RWG = FindObjectOfType<RandomWeaponGenerator>();
        the_PM = FindObjectOfType<PlayerManager>();
    }
    
    public void AttemptToBuy(int type)
    {
        if (PlayerManager.money_Total >= item_Cost)
        {
            BuyingItem(type);
        }
    }

    void BuyingItem(int type)
    {
        switch (item)
        {
            case 0:
                {
                    the_RWG.weapon_Unlock[type] = true;
                    break;
                }
            case 1:
                {
                    the_RWG.rarity_Unlock[type] = true;
                    break;
                }
            case 2:
                {
                    the_RWG.element_Unlock[type] = true;
                    break;
                }
            case 3:
                {
                    the_RWG.round_Unlock[type] = true;
                    break;
                }
        }
        lock_Button.SetActive(false);
        PlayerManager.money_Total -= item_Cost;
    }
}
