using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour {

    public Text enemyMessageDisplay;
    private GameObject player;

    // Use this for initialization
    void Start () {
        /*
        player = GameObject.FindWithTag("Player");
        enemyMessageDisplay.text = player.GetComponent<Sense>().getNearest().ToString();
        */
    }
	
	// Update is called once per frame
	void Update () {
        //if (GameObject.FindWithTag("Player").GetComponent<Sense>().nearestEntity.transform != null)
        //    enemyMessageDisplay.text = GameObject.FindWithTag("Player").GetComponent<Sense>().nearestEntity.transform.ToString();
    }
}
