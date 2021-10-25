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
    }

    public void Load() {
        // use playerPrefs to load health
        hp.health = PlayerPrefs.GetInt("Health", 100);
    }
}
