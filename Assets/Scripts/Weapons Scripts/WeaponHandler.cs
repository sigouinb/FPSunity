using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TagHolders;
using EnemyCtrl;


namespace WeaponsList 
{
public enum WeaponAim {
    NONE,
    SELF_AIM,
    AIM
}

public enum WeaponFireType {
    SINGLE,
    MULTIPLE
}

public enum WeaponBulletType {
    BULLET,
    ARROW,
}

public class WeaponHandler : MonoBehaviour
{

    private Animator anim;
    public WeaponAim weapon_Aim;

    [SerializeField]
    private GameObject muzzleFlash;

    public WeaponFireType fireType;
    public WeaponBulletType bulletType;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation() {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }



 


    // void Turn_On_AttackPoint() {
        // attack_Point.SetActive(true);
    // }

    // void Turn_Off_AttackPoint() {
        // if(attack_Point.activeInHierarchy) {
            // attack_Point.SetActive(false);
        // }
    // }

    

} // class
}
















