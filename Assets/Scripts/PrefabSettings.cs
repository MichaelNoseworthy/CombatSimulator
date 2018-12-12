using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSettings : MonoBehaviour {
    

    public int Soldier1;
    public int Soldier2;
    public int Soldier3;
    public int Soldier4;
    public int Soldier5;
    public int Soldier6;

    public void setSoldiers(int sold1, int sold2, int sold3, int sold4, int sold5, int sold6)
    {
        Soldier1 = sold1;
        Soldier2 = sold2;
        Soldier3 = sold3;
        Soldier4 = sold4;
        Soldier5 = sold5;
        Soldier6 = sold6;
    }

    public void setSoldier1(int soldier)
    {
        Soldier1 = soldier;
    }
    public void setSoldier2(int soldier)
    {
        Soldier2 = soldier;
    }
    public void setSoldier3(int soldier)
    {
        Soldier3 = soldier;
    }
    public void setSoldier4(int soldier)
    {
        Soldier4 = soldier;
    }
    public void setSoldier5(int soldier)
    {
        Soldier5 = soldier;
    }
    public void setSoldier6(int soldier)
    {
        Soldier6 = soldier;
    }

    public int getSoldier1()
    {
        return Soldier1;
    }
    public int getSoldier2()
    {
        return Soldier2;
    }
    public int getSoldier3()
    {
        return Soldier3;
    }
    public int getSoldier4()
    {
        return Soldier4;
    }
    public int getSoldier5()
    {
        return Soldier5;
    }
    public int getSoldier6()
    {
        return Soldier6;
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Settings");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
