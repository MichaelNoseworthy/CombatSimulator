using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour {

    public float speed = 3.0f;
    public float rotateSpeed = 3.0f;

    //private CharacterController controller;

	// Use this for initialization
	void Start () {
        //controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        /*
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float ourSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * ourSpeed);
        */
	}
}
