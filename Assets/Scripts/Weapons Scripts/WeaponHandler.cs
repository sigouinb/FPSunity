using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TagHolders;

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

    public void Aim(bool canAim) {
        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }

    void Turn_On_MuzzleFlash() {
        muzzleFlash.SetActive(true);
    }

    void Turn_Off_MuzzleFlash() {
        muzzleFlash.SetActive(false);
    }

    

} // class
}
















