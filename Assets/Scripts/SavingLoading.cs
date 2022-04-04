using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingLoading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // use SetInt() to give health a random value between 1 and 99
        PlayerPrefs.SetInt("Health", Random.Range(1, 99));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("health = " + health);

        if(Input.GetKeyDown(KeyCode.Space)) {
            GetHealth();
        }
        if(Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("my x position is " + transform.position.x);
            // add a debug.log for y and z
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            // saving the location
            SetPosition();
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)) {
            // moving back to the saved location
            GetPosition();
        }
    }

    int health = 0;

    void GetHealth() {
        health = PlayerPrefs.GetInt("Health", 100);
    }

    void GetPosition() {
        Vector3 newPosition;

        // assign the saved X, Y, and Z positions to newPosition
        newPosition.x = PlayerPrefs.GetFloat("posX", 0);
        newPosition.y = PlayerPrefs.GetFloat("posY", 0);
        newPosition.z = PlayerPrefs.GetFloat("posZ", 0);

        this.transform.position = newPosition;
    }

    // saving the position of this gameObject as three floats
    void SetPosition() {
        PlayerPrefs.SetFloat("posX", transform.position.x);
        PlayerPrefs.SetFloat("posY", transform.position.y);
        PlayerPrefs.SetFloat("posZ", transform.position.z);
    }

    /*
        everything in between a comment block 
        is a comment!

        so you can have a lot of text without all those 
        double slashes.

        pseudocode is plain english laid out like code.
        Q: how do we get the xyz of a vector3 player position into floats?
            A: transform.position.x
        Q: What do I do with the floats then, to save them?
        Q: How do I load those floats back into the player position?
    */

}
