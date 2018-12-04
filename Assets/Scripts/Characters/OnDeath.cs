using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnDeath : MonoBehaviour {

    [SerializeField]
    public bool Melee = false;//character type
    [SerializeField]
    public bool Ranged = false;//character type
    [SerializeField]
    public bool RockThrower = false;//character type
    [SerializeField]
    public bool MagicUser = false;//character type

    Animator m_Animator;//Gets the animations for this AI

    // Use this for initialization
    void Start () {
        m_Animator = GetComponent<Animator>();
        Destroy(gameObject, 5);

        if (MagicUser)
        {
            setAnimation("death");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setAnimation(string anim)
    {
        m_Animator.Play(anim);
    }
}
