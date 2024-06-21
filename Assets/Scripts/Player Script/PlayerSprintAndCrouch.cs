using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stats;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public float sprint_Speed = 10f;
    public float move_Speed = 5f;
    public float crouch_Speed = 2f;

    private Transform look_Root;
    private float stand_Height = 1.6f;
    private float crouch_Height = 1f;

    private bool is_Crouching;

    private PlayerStats player_Stats;

    private float sprint_Value = 100f;
    private float sprint_Treshold = 10f;

    


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        look_Root = transform.GetChild(0);

        player_Stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint() {

        // if we have stamina we can sprint
        if(sprint_Value > 0f) {
            if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching) {
                playerMovement.speed = sprint_Speed;

            }
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching) {
            playerMovement.speed = move_Speed;
        }

        if(Input.GetKey(KeyCode.LeftShift) && !is_Crouching) {
            sprint_Value -= sprint_Treshold * Time.deltaTime;

            if(sprint_Value <= 0f) {
                sprint_Value = 0f;

                // reset the speed
                playerMovement.speed = move_Speed;
            }

            player_Stats.Display_StaminaStats(sprint_Value);

        } else {
            if(sprint_Value != 100f) {
                sprint_Value += (sprint_Treshold / 2f) * Time.deltaTime;

                player_Stats.Display_StaminaStats(sprint_Value);

                if(sprint_Value > 100f) {
                    sprint_Value = 100f;
                }
            }
        }
    } // sprint

    void Crouch() {
        if(Input.GetKeyDown(KeyCode.C)) {
            // if we are crouching - stand up
            if(is_Crouching) {
                look_Root.localPosition = new Vector3(0f, stand_Height, 0f);
                GetComponent<CapsuleCollider>().height = 1.6f;
                playerMovement.speed = move_Speed;

                is_Crouching = false;


            } else {
                // if we are not crouching - crouch
                look_Root.localPosition = new Vector3(0f, crouch_Height, 0f);
                GetComponent<CapsuleCollider>().height = 1f;
                playerMovement.speed = crouch_Speed;

                is_Crouching = true;
            }
        } // if we press C
    } // crouch
} // class
