using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private UIController ui;

    private int health = 100, mana = 100, xp = 0;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetHealthSlider(health);
        ui.SetManaSlider(mana);
        ui.SetXPSlider(xp);
    }

    // void Update() {
    //     // regen mana at 1 per second.
    //     if(mana < 100) {
    //         mana += Time.deltaTime;
    //         ui.SetManaSlider(mana);
    //     }
    // }

    public void ChangeHealth(int byAmount) {
        health += byAmount;

        if(health <= 0) {
            // replace this with something better later.
            Application.LoadLevel(0);
        }

        if(health > 100) {
            health = 100;
        }

        ui.SetHealthSlider(health);
    }

    public void ChangeXP(int byAmount) {
        xp += byAmount;

        ui.SetXPSlider(xp);
    }
}


