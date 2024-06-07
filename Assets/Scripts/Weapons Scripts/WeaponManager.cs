using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponsList;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] weapons;

    private int current_Weapon_Index;


    // Start is called before the first frame update
    void Start()
    {
        current_Weapon_Index = 0;
        weapons[current_Weapon_Index].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            TurnOnSelectedWeapon(0);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            TurnOnSelectedWeapon(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            TurnOnSelectedWeapon(2);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            TurnOnSelectedWeapon(3);
        }
    } // update

    void TurnOnSelectedWeapon(int weaponsIndex) {
        // turn off the current weapon
        weapons[current_Weapon_Index].gameObject.SetActive(false);

        // turn on the selected weapon
        weapons[weaponsIndex].gameObject.SetActive(true);

        // store the current selected weapon index
        current_Weapon_Index = weaponsIndex;
    }

    public WeaponHandler GetCurrentSelectedWeapon() {
        return weapons[current_Weapon_Index];
    }

} // class
