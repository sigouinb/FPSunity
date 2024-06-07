using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponsList;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;

    public float fireRate = 15;
    private float nextTimeToFire;
    public float damage = 20f;

    void Awake() {
        weapon_Manager = GetComponent<WeaponManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        WeaponShoot();
    }

    void WeaponShoot() {
        // if we have assault rifle
        if(weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE) {

            // if we press and hold left mouse click AND
            // if Time is greater than nextTimeToFire
            if(Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire) {
                nextTimeToFire = Time.time + 1f / fireRate;
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                // BulletFired();
            }
            // if we have a single shot weapon
        } else {
           if(Input.GetMouseButtonDown(0)) {
            // handle shoot
            if(weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET) {
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                // BulletFired();
            } else {
                // we have an arrow

            } // else
           }
        } // if input get mouse button 0
    } // else
} // class
