using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ATM : MonoBehaviour
{
    PlayerManager the_PM;

    static int ATM_Total_Money;
    public int money_To;

    //ATM/Player UI
    public TMP_InputField deposit_Text, withdraw_Text;
    public TextMeshProUGUI ATM_Total_Money_Text;
    public GameObject press_E;
    public GameObject ATM_Screen;
    bool ATM_Open;

    private void Start()
    {
        the_PM = FindObjectOfType<PlayerManager>();
        UpdateATMUI();
    }
    internal void OpenATM()
    {
        if (!ATM_Open)
        {
            Cursor.lockState = CursorLockMode.None;
            ATM_Open = true;
            ATM_Screen.SetActive(true);
            Time.timeScale = 0;
        }
        else if (ATM_Open)
        {
            Cursor.lockState = CursorLockMode.Locked;
            ATM_Open = false;
            ATM_Screen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Deposit()
    {
        money_To = int.Parse(deposit_Text.text);
        if (PlayerManager.money_Total >= money_To)
        {
            ATM_Total_Money += money_To;
            PlayerManager.money_Total -= money_To;

            UpdateATMUI();
            print("ATM total money:" + ATM_Total_Money);
            print("Player total money:" + PlayerManager.money_Total);
        }
        else
        {
            print("Not Enough Money");
        }
    }
    public void Withdraw()
    {
        money_To = int.Parse(deposit_Text.text);
        if (ATM_Total_Money >= money_To)
        {
            ATM_Total_Money -= money_To;
            PlayerManager.money_Total += money_To;

            UpdateATMUI();
            print("ATM total money:" + ATM_Total_Money);
            print("Player total money:" + PlayerManager.money_Total);
        }
        else
        {
            print("Not Enough Money");
        }
    }
    void UpdateATMUI()
    {
        ATM_Total_Money_Text.text = "Bank Amount: " + ATM_Total_Money.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        //player enter GUN-inator premise
        if (other.GetComponent<GUNINATORGunCreation>() != null)
        {
            press_E.SetActive(true);
        }
    }
}
