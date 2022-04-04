/*
    DONE - alright, so I can just start appending a number to the properties that I save, and then choose that
    save to load via a menu.

    I'll need a menu to display all of the saves and then load the save that is requested. I can just use an index

    DONE - How do I check to see the value of the index? I suppose I could just save it lol.
    I will need some sort of for loop that looks through each of the ten possible indices
    and displays them if they exist while ignoring them if they don't.

    DONE - start saving the current time of the save as well as the index.
*/


using System;
using UnityEngine;

public class MultiSaveAndLoad : MonoBehaviour
{
    [SerializeField] bool debug = false;

    int saveIndex = 0;
    PlayerHealth hp;

    void Start() {
        hp = GetComponent<PlayerHealth>();
    }

    public void Save() {
        // use playerPrefs to save health
        PlayerPrefs.SetInt("Health" + saveIndex, hp.health);
        PlayerPrefs.SetInt("Mana" + saveIndex, hp.mana);

        PlayerPrefs.SetInt("Index" + saveIndex, saveIndex);

        var time = DateTime.Now;
        string saveTime = time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString();
        PlayerPrefs.SetString("SaveTime", saveTime);

        if(debug) Debug.Log("<color=red>" + saveTime + "</color>");

        // use playerPrefs to save player location.
        PlayerPrefs.SetFloat("posX" + saveIndex, this.transform.position.x);
        PlayerPrefs.SetFloat("posY" + saveIndex, this.transform.position.y);
        PlayerPrefs.SetFloat("posZ" + saveIndex, this.transform.position.z);
        if(debug) Debug.Log("playerPosition = " + this.transform.position);

        Vector3 saveLocation = new Vector3(PlayerPrefs.GetFloat("posX"),
                                            PlayerPrefs.GetFloat("posY"),
                                            PlayerPrefs.GetFloat("posZ"));

        if(debug) Debug.DrawLine(saveLocation, saveLocation + Vector3.up * 50, Color.white, 1000);
    }

    public void LoadSaveBy(int index = -1) {
        // if the default index is selected, load the most recent save.
        if(index == -1) index = saveIndex;
        hp.health = PlayerPrefs.GetInt("Health" + index, 100);
        hp.health = PlayerPrefs.GetInt("Mana" + index, 100);

        // use playerPrefs to load playerPosition
        Vector3 pos;

        pos.x = PlayerPrefs.GetFloat("posX" + index);
        pos.y = PlayerPrefs.GetFloat("posY" + index);
        pos.z = PlayerPrefs.GetFloat("posZ" + index);

        this.transform.position = pos;
    }
}
