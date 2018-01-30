using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpSpeed = 5f;
    Rigidbody rb;

	void Start () {

        rb = GetComponent<Rigidbody>();

	}
	
	void Update () {

        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.up * jumpSpeed;
        }
		
	}
}
