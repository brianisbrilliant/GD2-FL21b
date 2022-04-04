// handles collision with enemies and firing magic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth hp;

    [SerializeField]
    private Rigidbody magicBullet;

    [SerializeField]
    private Transform hand;

    private MultiSaveAndLoad save;

    void Start() {
        if(hp == null) {
            hp = this.GetComponent<PlayerHealth>();
        }

        save = GetComponent<MultiSaveAndLoad>();
    }

    // this should go in the input manager script.
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Fire();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            // health potion!
            if(hp.totalHealthPotions > 0) {
                hp.ChangeHealth(25);
                hp.totalHealthPotions -= 1;
                Debug.Log("We've used a health potion!");
            }
            else {
                Debug.Log("We have run out of health potions.");
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            // mana potion!
            if(hp.totalManaPotions > 0) {
                hp.ChangeMana(25);
                hp.totalManaPotions -= 1;
                Debug.Log("We've used a mana potion!");
            }
            else {
                Debug.Log("We have run out of mana potions.");
            }
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
            // hp.ChangeHealth(25);
            hp.totalHealthPotions += 1;     // add one to the the total number of health potions we have.
            Destroy(other.gameObject);
            // play drink audio clip
        }
        else if(other.gameObject.CompareTag("ManaPotion")) {
            hp.ChangeMana(25);
            hp.totalManaPotions += 1;       // add one to the total number of mana potions we have.
            Destroy(other.gameObject);
            // play drink audio clip
        }
        // else if(other.gameObject.CompareTag("MysteryPotion")) {
        //     hp.ChangeHealth(-5);
        //     Destroy(other.gameObject);
        //     // play drink audio clip
        // }
        else if(other.gameObject.CompareTag("Checkpoint")) {
            // call the Save() function.
            save.Save();
        }
        else if(other.gameObject.CompareTag("NextLevel")) {
            // if(has Key from this level) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }   // }
        else if(other.gameObject.CompareTag("LastLevel")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
