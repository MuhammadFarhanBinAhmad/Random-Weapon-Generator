﻿using System.Collections;
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
    internal int current_Weapon = 0;
    //WeaponPickup
    public BaseGun pickable_Weapon;
    //Flash Light//
    /*public GameObject the_Flash_Light;
    bool fl_On;*/

    PlayerUIHUD the_Player_UI_HUD;

    private void Start()
    {
        the_Player_UI_HUD = FindObjectOfType<PlayerUIHUD>();
        the_CC = GetComponent<CharacterController>();
        //set up character stats
        health_Player = the_Basic_Stats.health;
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
        /*//RUNNING// 
        if (Input.GetKey(KeyCode.LeftAlt) && current_Stamina >= 0)
        {
            Running();
        }
        else
        {
            StopRunning();
        }*/
        /*//FLASHLIGHT//
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!fl_On)
            {
                the_Flash_Light.SetActive(true);
                fl_On = true;
            }
            else if (fl_On)
            {
                the_Flash_Light.SetActive(false);
                fl_On = false;
            }
        }*/
        //PICK UP WEAPON
        if (Input.GetKeyDown(KeyCode.E) && pickable_Weapon != null)
        {
            //add weapon to inventory
            weapon_Inventory.Add(pickable_Weapon);
            pickable_Weapon.GetComponent<BaseGun>().weapon_Eqip = true;
            //Set up position
            pickable_Weapon.transform.parent = GameObject.Find("Weapons").transform;
            pickable_Weapon.transform.position = GameObject.Find("Weapons").transform.position;
            pickable_Weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            //Set up weapon physics
            pickable_Weapon.GetComponent<Rigidbody>().isKinematic = true;
            //Set up UI value
            pickable_Weapon.GetComponent<BaseGun>().SetValue();
            pickable_Weapon.GetComponent<BoxCollider>().enabled =false;
            //Reset picking up values
            WeaponPickedUpOrLeft();
        }
    }

    void MovePlayer()
    {

        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");
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
        if (weapon_Inventory[current_Weapon].the_Round_Type == 8)//Flyer Round
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
    /*void Running()
    {
        //multiply speed value
        if (!speed_Multiply)
        {
            speed_Multiply = true;
            speed_Movement *= speed_Multiplier;
        }
        current_Stamina -= Time.fixedDeltaTime;
        currently_Running = true;
    }
    void StopRunning()
    {
        speed_Multiply = false;
        speed_Movement = the_Basic_Stats.speed;//reset the original movement value
        currently_Running = false;
        //Start regaining back stamina
        if (current_Stamina < total_Stamina && !currently_Running)
        {
            StartCoroutine("RefillingStamina");
        }
    }
    IEnumerator RefillingStamina()
    {
        yield return new WaitForSeconds(2);
        if (current_Stamina <= total_Stamina)
        {
            current_Stamina += Time.fixedDeltaTime;
        }
        else StopAllCoroutines();
    }*/

    internal void TakeDamage(float Dmg)
    {
        health_Player -= Dmg;
        if (health_Player <= 0)
        {
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
    //player able to pick up weapon
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<BaseGun>() != null)
        {
            WeaponDetected(other.GetComponent<BaseGun>());
            print("hit1");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        WeaponPickedUpOrLeft();
        print("hit2");
    }
}
