// handles collision with enemies and firing magic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth hp;

    [SerializeField]
    private Rigidbody magicBullet;

    [SerializeField]
    private Transform hand;

    void Start() {
        if(hp == null) {
            hp = this.GetComponent<PlayerHealth>();
        }
    }

    // this should go in the input manager script.
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Fire();
        }
    }

    void Fire() {
        Rigidbody copy = Instantiate(magicBullet, hand.position, hand.rotation);
        copy.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse); // shoot bullet forward
        copy.GetComponent<BulletController>().owner = hp;
        
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log("I've hit " + other.gameObject.tag);
        if(other.gameObject.CompareTag("Enemy")) {
            // Debug.Log("I've hit an enemy!");
            hp.ChangeHealth(-10);
        }
    }
}
