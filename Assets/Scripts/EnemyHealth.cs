using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 30, xpValue = 50;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bullet")) {
            health -= 10;

            if(health <= 0) {
                other.GetComponent<BulletController>().owner.ChangeXP(xpValue);
                Death();
            }
        }
    }

    void Death() {
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();  // make the enemy fall to the ground
        rb.angularDrag = 1;
        // Destroy(this.gameObject, 2);        // destroy the enemy in two seconds
        Destroy(this);                      // destroy this script immediately
        Destroy(this.GetComponent<NavMeshAgent>());
        Destroy(this.GetComponent<MoveTo>());
        this.gameObject.tag = "Untagged";
        
        
    }
}
