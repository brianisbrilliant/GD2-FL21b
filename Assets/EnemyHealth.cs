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
            }
        }
    }
}
