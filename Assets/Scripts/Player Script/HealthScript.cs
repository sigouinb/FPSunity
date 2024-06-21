using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using EnemyCtrl;
using TagHolders;
using stats;
using spawns;

namespace Health_Script
{
public class HealthScript : MonoBehaviour
{
    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;
    private AttackScript enemy_Damage; 

    public float health = 100f;

    public bool is_Player, is_Cannibal;

    private bool is_Dead;

    private PlayerStats player_Stats;

    void Awake()
    {
        if(is_Cannibal) {
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();
        }

        if(is_Player) {
            player_Stats = GetComponent<PlayerStats>();
        }
    }

    public void ApplyDamage(float damage) {

        // if we died don't execute the rest of the code
        if(is_Dead) {
            return;
        }
            

        health -= damage;

        if(is_Player) {
            player_Stats.Display_HealthStats(health);
        }

        if(is_Cannibal) {
            if(enemy_Controller.Enemy_State == EnemyState.PATROL) {
                enemy_Controller.chase_Distance = 50f;
            }
        }

        if(health <= 0f) {
            PlayerDied();

            is_Dead = true;
        }
    } // apply damage

    void PlayerDied() {
        if(is_Cannibal) {
            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 5000f);

            enemy_Controller.enabled = false;
            navAgent.enabled = false;
            enemy_Anim.enabled = false;
            

            // EnemyManager spawn more enemies
            //EnemyManager.instance.EnemyDied(true);
        }

        if(is_Player) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for (int i = 0; i < enemies.Length; i++) {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            // call enemy manager to stop spawning enemies
            //EnemyManager.instance.StopSpawning();

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }

        if(tag == Tags.PLAYER_TAG) {
            Invoke("RestartGame", 3f);
        } else {
            Invoke("TurnOffGameObject", 3f);
        }
    } // player died

    void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void TurnOffGameObject() {
        gameObject.SetActive(false);
    }

} // class
}