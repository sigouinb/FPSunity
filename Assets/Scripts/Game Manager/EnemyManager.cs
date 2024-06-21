using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace spawns
{
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField]
    private GameObject cannibal_Prefab;

    public Transform[] cannibal_SpawnPoints;

    [SerializeField]
    private int cannibal_Ememy_Count;

    private int initial_Cannibal_Count;

    public float wait_Before_Spawn_Enemies_Time = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }
    
    void Start() {
        initial_Cannibal_Count = cannibal_Ememy_Count;
        
        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");
    }

    void MakeInstance() {
        if(instance = null) {
            instance = this;
        }
    }

    void SpawnEnemies() {
        int index = 0;

        for(int i = 0; i < cannibal_Ememy_Count; i++) {
            if(index >= cannibal_SpawnPoints.Length) {
                index = 0;
            }

            Instantiate(cannibal_Prefab, cannibal_SpawnPoints[index].position, Quaternion.identity);

            index++;
        }

        cannibal_Ememy_Count = 0;
    }

    IEnumerator CheckToSpawnEnemies() {
        yield return new WaitForSeconds(wait_Before_Spawn_Enemies_Time);

        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");
    }

    public void EnemyDied(bool cannibal) {
        if(cannibal) {
            cannibal_Ememy_Count++;

            if(cannibal_Ememy_Count > initial_Cannibal_Count) {
                cannibal_Ememy_Count = initial_Cannibal_Count;
            }
        }
    }

    public void StopSpawning() {
        StopCoroutine("CheckToSpawnEnemies");
    }

} // class
}