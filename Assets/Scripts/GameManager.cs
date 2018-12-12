using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

    public bool PauseGame = false;

    public GameObject AlliesMeleeGroupPrefab;
    public GameObject EnemiesMeleeGroupPrefab;

    GameObject AlliesSoldierSpawn1;
    GameObject AlliesSoldierSpawn2;
    GameObject AlliesSoldierSpawn3;
    GameObject AlliesSoldierSpawn4;
    GameObject AlliesSoldierSpawn5;
    GameObject AlliesSoldierSpawn6;

    GameObject EnemiesSoldierSpawn1;
    GameObject EnemiesSoldierSpawn2;
    GameObject EnemiesSoldierSpawn3;
    GameObject EnemiesSoldierSpawn4;
    GameObject EnemiesSoldierSpawn5;
    GameObject EnemiesSoldierSpawn6;

    // Use this for initialization
    void Start () {
        PauseGame = false;
        Time.timeScale = 0;

        AlliesSoldierSpawn1 = GameObject.Find("AlliesSoldier1");
        AlliesSoldierSpawn2 = GameObject.Find("AlliesSoldier2");
        AlliesSoldierSpawn3 = GameObject.Find("AlliesSoldier3");
        AlliesSoldierSpawn4 = GameObject.Find("AlliesSoldier4");
        AlliesSoldierSpawn5 = GameObject.Find("AlliesSoldier5");
        AlliesSoldierSpawn6 = GameObject.Find("AlliesSoldier6");

        Instantiate(AlliesMeleeGroupPrefab, AlliesSoldierSpawn1.transform.position, AlliesSoldierSpawn1.transform.rotation);
        Instantiate(AlliesMeleeGroupPrefab, AlliesSoldierSpawn2.transform.position, AlliesSoldierSpawn2.transform.rotation);
        Instantiate(AlliesMeleeGroupPrefab, AlliesSoldierSpawn3.transform.position, AlliesSoldierSpawn3.transform.rotation);
        Instantiate(AlliesMeleeGroupPrefab, AlliesSoldierSpawn4.transform.position, AlliesSoldierSpawn4.transform.rotation);
        Instantiate(AlliesMeleeGroupPrefab, AlliesSoldierSpawn5.transform.position, AlliesSoldierSpawn5.transform.rotation);
        Instantiate(AlliesMeleeGroupPrefab, AlliesSoldierSpawn6.transform.position, AlliesSoldierSpawn6.transform.rotation);

        EnemiesSoldierSpawn1 = GameObject.Find("EnemiesSoldier1");
        EnemiesSoldierSpawn2 = GameObject.Find("EnemiesSoldier2");
        EnemiesSoldierSpawn3 = GameObject.Find("EnemiesSoldier3");
        EnemiesSoldierSpawn4 = GameObject.Find("EnemiesSoldier4");
        EnemiesSoldierSpawn5 = GameObject.Find("EnemiesSoldier5");
        EnemiesSoldierSpawn6 = GameObject.Find("EnemiesSoldier6");

        Instantiate(EnemiesMeleeGroupPrefab, EnemiesSoldierSpawn1.transform.position, EnemiesSoldierSpawn1.transform.rotation);
        Instantiate(EnemiesMeleeGroupPrefab, EnemiesSoldierSpawn2.transform.position, EnemiesSoldierSpawn2.transform.rotation);
        Instantiate(EnemiesMeleeGroupPrefab, EnemiesSoldierSpawn3.transform.position, EnemiesSoldierSpawn3.transform.rotation);
        Instantiate(EnemiesMeleeGroupPrefab, EnemiesSoldierSpawn4.transform.position, EnemiesSoldierSpawn4.transform.rotation);
        Instantiate(EnemiesMeleeGroupPrefab, EnemiesSoldierSpawn5.transform.position, EnemiesSoldierSpawn5.transform.rotation);
        Instantiate(EnemiesMeleeGroupPrefab, EnemiesSoldierSpawn6.transform.position, EnemiesSoldierSpawn6.transform.rotation);
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
