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

    private PlayerSaveAndLoad save;

    void Start() {
        if(hp == null) {
            hp = this.GetComponent<PlayerHealth>();
        }

        save = GetComponent<PlayerSaveAndLoad>();
    }

    // this should go in the input manager script.
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Fire();
        }
    }

    void Fire() {
        if(hp.GetMana() > 5) {
            hp.ChangeMana(-5);
            Rigidbody copy = Instantiate(magicBullet, hand.position, hand.rotation);
            copy.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse); // shoot bullet forward
            copy.GetComponent<BulletController>().owner = hp;
            Destroy(copy.gameObject, 2);
        }
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log("I've hit " + other.gameObject.tag);
        if(other.gameObject.CompareTag("Enemy")) {
            // Debug.Log("I've hit an enemy!");
            hp.ChangeHealth(-10);
        }
        else if(other.gameObject.CompareTag("HealthPotion")) {
            hp.ChangeHealth(25);
            Destroy(other.gameObject);
            // play drink audio clip
        }
        else if(other.gameObject.CompareTag("ManaPotion")) {
            hp.ChangeMana(25);
            Destroy(other.gameObject);
            // play drink audio clip
        }
        else if(other.gameObject.CompareTag("Checkpoint")) {
            // call the Save() function.
            save.Save();
        }
    }
}
