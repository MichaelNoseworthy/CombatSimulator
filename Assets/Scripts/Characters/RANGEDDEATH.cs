using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RANGEDDEATH : MonoBehaviour {

    Animation m_Animator;

    // Use this for initialization
    void Start () {
        m_Animator = GetComponent<Animation>();
        m_Animator.Play("sleep");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
