using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        this.gameObject.AddComponent<Rigidbody>();  // make the enemy fall to the ground
        Destroy(this.gameObject, 2);        // destroy the enemy in two seconds
        Destroy(this);                      // destroy this script immediately
        
        
    }
}
