using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    PlayerHealth hp;

    void Start() {
        hp = GetComponent<PlayerHealth>();
        Debug.Log("health = " + hp.health);
        // Debug.Log("health = " + hp.GetHealth());
    }

    public void Save() {
        // use playerPrefs to save health
        PlayerPrefs.SetInt("Health", hp.health);
        PlayerPrefs.SetInt("Mana", hp.mana);

        // use playerPrefs to save player location.
        PlayerPrefs.SetFloat("posX", this.transform.position.x);
        PlayerPrefs.SetFloat("posY", this.transform.position.y);
        PlayerPrefs.SetFloat("posZ", this.transform.position.z);
        Debug.Log("playerPosition = " + this.transform.position);

        Vector3 saveLocation = new Vector3(PlayerPrefs.GetFloat("posX"),
                                            PlayerPrefs.GetFloat("posY"),
                                            PlayerPrefs.GetFloat("posZ"));

        Debug.DrawLine(saveLocation, saveLocation + Vector3.up * 50, Color.white, 1000);
    }

    public void Load() {
        // use playerPrefs to load health & mana
        hp.health = PlayerPrefs.GetInt("Health", 100);
        hp.health = PlayerPrefs.GetInt("Mana", 100);

        // use playerPrefs to load playerPosition
        Vector3 pos;

        pos.x = PlayerPrefs.GetFloat("posX");
        pos.y = PlayerPrefs.GetFloat("posY");
        pos.z = PlayerPrefs.GetFloat("posZ");

        this.transform.position = pos;
    }
}
