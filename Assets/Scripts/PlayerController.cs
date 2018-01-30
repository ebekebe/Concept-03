using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    Rigidbody rb;

    SwipeBehaviour swipeControls;

    public float attackRange;
    public float jumpSpeed = 5f;

    int enemyMask;

    bool grounded;

    void Start () {

        rb = GetComponent<Rigidbody>();
        swipeControls = GetComponent<SwipeBehaviour>();
        enemyMask = LayerMask.GetMask("Enemy");
	}
	
	void Update () {

        if (swipeControls.tap)
        {
            rb.velocity = Vector3.up * jumpSpeed;
            swipeControls.tap = false;
        }

        if (Physics.Raycast(transform.position, Vector3.right, attackRange, enemyMask))
        {
            Debug.Log("enemyInRange");
        }
    }

}
