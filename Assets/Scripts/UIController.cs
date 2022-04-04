// this should probably go on the canvas.
// this controls all of the ScreenSpace UI in the level.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           // for sliders

public class UIController : MonoBehaviour
{
    // instead of making this public, we can add it to the inspector with [SerializeField]
    [SerializeField]
    private Slider healthSlider, manaSlider, xpSlider;    // we can make multiple variables on the same line!

    [SerializeField]
    private Text xpLevelText;
    private int xpLevel = 1;

    public GameObject pauseMenu;       // this is turned on and off by the Pause.cs script.

    void Start() {
        // turn off the pauseMenu
        pauseMenu.SetActive(false);
    }

    // getters and setters

    //setter function
    public void SetHealthSlider(int amount) {
        // make sure no one is sending bad data...
        if(amount < 0) {
            healthSlider.value = 0;
        }
        if(amount > 100) {
            healthSlider.value = 100;
        }

        healthSlider.value = amount;
    }

    //setter function
    public void SetManaSlider(int amount) {
        // make sure no one is sending bad data...
        if(amount < 0) {
            manaSlider.value = 0;
        }
        if(amount > 100) {
            manaSlider.value = 100;
        }

        manaSlider.value = amount;
    }

    // when I go to save and reload this, I will have to re-calculate what the level is...
    public void SetXPSlider(int amount) {
        if(amount >= xpSlider.maxValue) {
            xpSlider.minValue = xpSlider.maxValue;
            xpSlider.maxValue *= 2;
            xpLevel += 1;
            xpLevelText.text = xpLevel.ToString();
        }
        xpSlider.value = amount;
    }

    public void SetXPLevelText(int level) {
        xpLevelText.text = level.ToString();
    }
}
