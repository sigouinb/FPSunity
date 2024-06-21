using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Health_Script;

public class AttackScript : MonoBehaviour
{
    public float damage = 1f;
    public float radius = 1f;
    public LayerMask layerMask;

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        if(hits.Length > 0) {
            if(hits[0].gameObject.tag == "Player") {
                hits[0].gameObject.GetComponent<HealthScript>().ApplyDamage(damage);
                // hits[0].gameObject.SetActive(false);
            }

            // gameObject.SetActive(false);
        }
    }
} // class
