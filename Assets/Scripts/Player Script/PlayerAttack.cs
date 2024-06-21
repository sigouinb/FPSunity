using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponsList;
using Health_Script;
using TagHolders;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Camera mainCam;

    public float normalizedTime;

    
    void Awake() {
        weapon_Manager = GetComponent<WeaponManager>();

        mainCam = Camera.main;
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
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire) {
                nextTimeToFire = Time.time + 1f / fireRate;
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                BulletFired();
            }
            // if we have a single shot weapon
        } else {

            if(Input.GetMouseButtonDown(0 )) {
                // handle shoot
                if(weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET) {
                    IEnumerator SingleShoot() {
                        yield return new WaitForSeconds(3f);
                        StartCoroutine(SingleShoot());
                    }
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    BulletFired();
                    
                    
                }
            }
        } // if input get mouse button 0
    } // else

    void BulletFired() {
        RaycastHit hit;

        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit)) {
            if(hit.transform.tag == Tags.ENEMY_TAG) {
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }
        }
    } // bullet fired
} // class
