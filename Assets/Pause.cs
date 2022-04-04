// TODO: Get the true number of saves (up to ten of them)
// TODO: Figure out how to load the save and unpause from the buttons that are generated.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Button buttonPrefab;
    bool isPaused = false;
    UIController ui;
    public MultiSaveAndLoad multiSave;

    void Start() {
        ui = GetComponent<UIController>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            TogglePause();
        }
    }

    public void TogglePause() {
        isPaused = !isPaused;
        
        if(isPaused) {
            Time.timeScale = 0;
            // show UI
            ui.pauseMenu.SetActive(true);
            GetSaves();
        }
        else {
            Time.timeScale = 1;
            // hide UI
            ui.pauseMenu.SetActive(false);
        }
    }

    // this should probably go in the UIController script.
    void GetSaves() {
        int saves = multiSave.saveIndex;    // I cannot use this because once it begins overwriting the oldest saves, it only counts the newest saves.

        // destroy previous buttons
        foreach(Transform child in ui.pauseMenu.transform.GetChild(0)) {
            Destroy(child.gameObject);
        }

        for(int i = 0; i < saves; i++) {
            // create a new button
            Button newButton = Instantiate(buttonPrefab);
            Debug.Log(newButton);
            newButton.transform.SetParent(ui.pauseMenu.transform.GetChild(0));
            // populate the text with the index, the hp, and the time.
            newButton.transform.GetChild(0).GetComponent<Text>().text = multiSave.LoadSaveTextBy(i);
        }
    }
}
