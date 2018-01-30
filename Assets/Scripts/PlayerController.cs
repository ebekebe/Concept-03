using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpSpeed = 5f;
    Rigidbody rb;

    Swipe swipeControls;

	void Start () {

        rb = GetComponent<Rigidbody>();
        swipeControls = GetComponent<Swipe>();

	}
	
	void Update () {

        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.up * jumpSpeed;
        }

        if (swipeControls.SwipeDown)
            Debug.Log("swipeDown");
        if (swipeControls.SwipeUp)
            Debug.Log("swipeUp");
        if (swipeControls.SwipeLeft)
            Debug.Log("swipeLeft");
        if (swipeControls.SwipeRight)
            Debug.Log("swipeRight");

    }
}
