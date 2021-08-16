using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Rigidbody the_RB;
    CharacterController the_CC;
    //Basic
    public BasicCharacterDataStats the_Basic_Stats;
    public float speed_Movement;
    public float health_Player;
    public float health_Player_Current;
    public static int money_Total = 5;
    //Runnning
    float total_Stamina = 10;
    float speed_Multiplier = 1.5f;
    float current_Stamina;
    bool currently_Running;
    bool speed_Multiply;
    //Jumping
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jump_Force = 9.81f;
    public Transform check_Ground;
    public float ground_Distance = 0.5f;
    public LayerMask ground_Layer;
    bool is_Grounded;
    //Weapon Change
    public List<BaseGun> weapon_Inventory = new List<BaseGun>();
    public int current_Weapon = 0;
    public List<GameObject> weapon_Transform = new List<GameObject>();
    //WeaponPickup
    public BaseGun pickable_Weapon;

    //PlayerUI
    PlayerUIHUD the_Player_UI_HUD;
    public GameObject press_E;

    public GUNINATORGunCreation the_GUNINATOR;
    public ATM the_ATM;

    private void Start()
    {
        the_Player_UI_HUD = FindObjectOfType<PlayerUIHUD>();
        the_CC = GetComponent<CharacterController>();
        //set up character stats
        health_Player = the_Basic_Stats.health;
        health_Player_Current = health_Player;
        speed_Movement = the_Basic_Stats.speed;
        current_Stamina = total_Stamina;

        //SwitchWeapon(current_Weapon);//equip 1st weapon at start
    }

    public void Update()
    {
        MovePlayer();
        //JUMP//
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            JumpPlayer();
        }
        //SWITCH WEAPON//
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            current_Weapon = 0;
            SwitchWeapon(current_Weapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            current_Weapon = 1;
            SwitchWeapon(current_Weapon);
        }

        //PICK UP WEAPON
        if (Input.GetKeyDown(KeyCode.E) && pickable_Weapon != null)
        {
            if (weapon_Inventory.Count != 2)
            {
                //add weapon to inventory
                weapon_Inventory.Add(pickable_Weapon);
                if (weapon_Inventory[0] !=null && weapon_Inventory.Count == 2)
                {
                    weapon_Inventory[0].gameObject.SetActive(false);
                    current_Weapon++;
                }
            }
            else
            {
                weapon_Inventory[current_Weapon].GetComponent<Rigidbody>().isKinematic = false;
                weapon_Inventory[current_Weapon].transform.parent = null;
                weapon_Inventory[current_Weapon].weapon_Eqip = false;
                weapon_Inventory[current_Weapon].GetComponent<BoxCollider>().enabled = true;
                weapon_Inventory[current_Weapon] = pickable_Weapon;
            }
            pickable_Weapon.GetComponent<BaseGun>().weapon_Eqip = true;
            //Set up position
            pickable_Weapon.transform.parent = weapon_Transform[pickable_Weapon.the_Weapon_Type_Int].transform;
            pickable_Weapon.transform.position = weapon_Transform[pickable_Weapon.the_Weapon_Type_Int].transform.position;
            pickable_Weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            //Set up weapon physics
            pickable_Weapon.GetComponent<Rigidbody>().isKinematic = true;
            //Set up UI value
            pickable_Weapon.GetComponent<BaseGun>().SetValue();//this also set up other references
            pickable_Weapon.GetComponent<BoxCollider>().enabled =false;
            //set anim
            pickable_Weapon.GetComponent<BaseGun>().SetAnimator();
            //Reset picking up values
            WeaponPickedUpOrLeft();
        }
        //ACCESS STORE//
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (the_ATM != null)
            {
                the_ATM.OpenATM();
            }
            if (the_GUNINATOR != null)
            {
                the_GUNINATOR.OpenStore();
            }

        }
    }

    void MovePlayer()
    {

        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical") ;
        //Movement
        Vector3 move = transform.right * H + transform.forward * V;
        the_CC.Move(move * speed_Movement * Time.deltaTime);
        //Gravity
        velocity.y += gravity * Time.deltaTime;
        the_CC.Move(velocity * Time.deltaTime);

        if (isGrounded() && velocity.y <0)
        {
            velocity.y = -2f;
        }
    }

    //check if player grounded
    internal bool isGrounded()
    {
        if (Physics.CheckSphere(check_Ground.position, ground_Distance,ground_Layer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void JumpPlayer()
    {
        //velocity.y = Mathf.Sqrt(jump_Force * -2 * gravity);

        if (weapon_Inventory.Count > 0 && weapon_Inventory[current_Weapon].the_Round_Type == 8)//Flyer Round
        {
            velocity.y = Mathf.Sqrt(jump_Force * 1.5f * -2 * gravity);
        }
        else
        {
            velocity.y = Mathf.Sqrt(jump_Force * -2 * gravity);
        }
    }

    void SwitchWeapon(int i)
    {
        if (weapon_Inventory[0] != null && weapon_Inventory[1] != null)
        //Switching Weapon
        switch (i)
        {
            case 0:
                {
                    weapon_Inventory[0].gameObject.SetActive(true);
                    weapon_Inventory[0].GetComponent<BaseGun>().weapon_Eqip = true;
                    weapon_Inventory[1].GetComponent<BaseGun>().weapon_Eqip = false;
                    weapon_Inventory[1].gameObject.SetActive(false);
                    break;
                }
            case 1:
                {
                    weapon_Inventory[0].gameObject.SetActive(false);
                    weapon_Inventory[0].GetComponent<BaseGun>().weapon_Eqip = false;
                    weapon_Inventory[1].gameObject.SetActive(true);
                    weapon_Inventory[1].GetComponent<BaseGun>().weapon_Eqip = true;
                    break;
                }
        }
        //Update player weapon UI
        the_Player_UI_HUD.current_Weapon = weapon_Inventory[i];
        the_Player_UI_HUD.AmmoUpdate(i);
        the_Player_UI_HUD.WeaponNameUpdate(i);
    }

    internal void TakeDamage(float Dmg)
    {
        health_Player_Current -= Dmg;
        the_Player_UI_HUD.HealthUpdate();
        if (health_Player_Current <= 0)
        {
            the_Player_UI_HUD.GameOver();
            print("Dead");
        }
    }
    void WeaponDetected(BaseGun BG)
    {
        pickable_Weapon = BG;
        the_Player_UI_HUD.pickable_Weapon_Name_GUI.gameObject.SetActive(true);
        the_Player_UI_HUD.PickableWeaponDetails(pickable_Weapon.weapon_Name);
    }
    //reset value if player decide to leave the weapon or pick it up
    void WeaponPickedUpOrLeft()
    {
        pickable_Weapon = null;
        the_Player_UI_HUD.PickableWeaponDetails(null);
        the_Player_UI_HUD.pickable_Weapon_Name_GUI.gameObject.SetActive(false);
    }
    public static void ResetPlayerData()
    {
        money_Total = 5;
    }
    //player able to pick up weapon
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<BaseGun>() != null)
        {
            WeaponDetected(other.GetComponent<BaseGun>());
        }
        //player enter GUN-inator premise
        if (other.GetComponent<GUNINATORGunCreation>() != null)
        {
            the_GUNINATOR = other.GetComponent<GUNINATORGunCreation>();
            press_E.SetActive(true);
        }
        //player enter ATM premise
        if (other.GetComponent<ATM>() != null)
        {
            the_ATM = other.GetComponent<ATM>();
            press_E.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        WeaponPickedUpOrLeft();

        //player leaves GUN-inator premise
        if (the_GUNINATOR !=null)
        {
            the_GUNINATOR = null;
            press_E.SetActive(false);
        }
        //player enter ATM premise
        if (the_ATM != null)
        {
            the_ATM = null;
            press_E.SetActive(false);
        }
    }
}
