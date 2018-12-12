using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

    public bool PauseGame = false;

    public GameObject AlliesMeleeGroupPrefab;
    public GameObject EnemiesMeleeGroupPrefab;

    public GameObject AlliesRangedGroupPrefab;
    public GameObject EnemiesRangedGroupPrefab;

    public GameObject AlliesMagicUserGroupPrefab;
    public GameObject EnemiesMagicUserGroupPrefab;

    public GameObject AlliesRockThrowerGroupPrefab;
    public GameObject EnemiesRockThrowerGroupPrefab;

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

    PrefabSettings Settings;

    int soldier1 = 1;
    int soldier2 = 1;
    int soldier3 = 1;
    int soldier4 = 1;
    int soldier5 = 1;
    int soldier6 = 1;

    int troopNumber;

    private GameObject SpawnEnemiesGroupPrefab()
    {
        int number = Random.Range(1, 4);

        if (number == 1)
            return EnemiesMeleeGroupPrefab;

        if (number == 2)
            return EnemiesRangedGroupPrefab;
        if (number == 3)
            return EnemiesMagicUserGroupPrefab;
        if (number == 4)
            return EnemiesRockThrowerGroupPrefab;

        return EnemiesMeleeGroupPrefab; 
    }

    private GameObject SpawnAlliesGroupPrefab(int number)
    {

        if (number == 1)
            return AlliesMeleeGroupPrefab;
        if (number == 2)
            return AlliesRangedGroupPrefab;
        if (number == 3)
            return AlliesMagicUserGroupPrefab;
        if (number == 4)
            return AlliesRockThrowerGroupPrefab;

        return EnemiesMeleeGroupPrefab;
    }



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

        

        EnemiesSoldierSpawn1 = GameObject.Find("EnemiesSoldier1");
        EnemiesSoldierSpawn2 = GameObject.Find("EnemiesSoldier2");
        EnemiesSoldierSpawn3 = GameObject.Find("EnemiesSoldier3");
        EnemiesSoldierSpawn4 = GameObject.Find("EnemiesSoldier4");
        EnemiesSoldierSpawn5 = GameObject.Find("EnemiesSoldier5");
        EnemiesSoldierSpawn6 = GameObject.Find("EnemiesSoldier6");

        Instantiate(SpawnEnemiesGroupPrefab(), EnemiesSoldierSpawn1.transform.position, EnemiesSoldierSpawn1.transform.rotation);
        Instantiate(SpawnEnemiesGroupPrefab(), EnemiesSoldierSpawn2.transform.position, EnemiesSoldierSpawn2.transform.rotation);
        Instantiate(SpawnEnemiesGroupPrefab(), EnemiesSoldierSpawn3.transform.position, EnemiesSoldierSpawn3.transform.rotation);
        Instantiate(SpawnEnemiesGroupPrefab(), EnemiesSoldierSpawn4.transform.position, EnemiesSoldierSpawn4.transform.rotation);
        Instantiate(SpawnEnemiesGroupPrefab(), EnemiesSoldierSpawn5.transform.position, EnemiesSoldierSpawn5.transform.rotation);
        Instantiate(SpawnEnemiesGroupPrefab(), EnemiesSoldierSpawn6.transform.position, EnemiesSoldierSpawn6.transform.rotation);

        Settings = GameObject.Find("PrefabSettings").GetComponent<PrefabSettings>();

        soldier1 = Settings.getSoldier1();
        soldier2 = Settings.getSoldier2();
        soldier3 = Settings.getSoldier3();
        soldier4 = Settings.getSoldier4();
        soldier5 = Settings.getSoldier5();
        soldier6 = Settings.getSoldier6();

        Instantiate(SpawnAlliesGroupPrefab(soldier1), AlliesSoldierSpawn1.transform.position, AlliesSoldierSpawn1.transform.rotation);
        Instantiate(SpawnAlliesGroupPrefab(soldier2), AlliesSoldierSpawn2.transform.position, AlliesSoldierSpawn2.transform.rotation);
        Instantiate(SpawnAlliesGroupPrefab(soldier3), AlliesSoldierSpawn3.transform.position, AlliesSoldierSpawn3.transform.rotation);
        Instantiate(SpawnAlliesGroupPrefab(soldier4), AlliesSoldierSpawn4.transform.position, AlliesSoldierSpawn4.transform.rotation);
        Instantiate(SpawnAlliesGroupPrefab(soldier5), AlliesSoldierSpawn5.transform.position, AlliesSoldierSpawn5.transform.rotation);
        Instantiate(SpawnAlliesGroupPrefab(soldier6), AlliesSoldierSpawn6.transform.position, AlliesSoldierSpawn6.transform.rotation);
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
