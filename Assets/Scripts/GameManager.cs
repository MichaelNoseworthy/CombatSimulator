using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool PauseGame = false;

	// Use this for initialization
	void Start () {
        PauseGame = false;
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("space"))
        {
            PauseGame = !PauseGame;
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            else Time.timeScale = 0;
        }
    }
}
