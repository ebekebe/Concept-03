using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {

    
    Rigidbody rb;

    SwipeBehaviour swipeControls;

    public float attackRange;
    public float jumpSpeed = 5f;

    int enemyMask;

    [SerializeField]LayerMask Ground;
    Transform groundCheck;
    float groundedRadius;
    bool grounded;

    void Start () {

        rb = GetComponent<Rigidbody>();
        swipeControls = GetComponent<SwipeBehaviour>();
        enemyMask = LayerMask.GetMask("Enemy");
        groundCheck = transform.Find("groundCheck");
	}

    void FixedUpdate()
    {
        grounded = false;
        Collider[] colliders = Physics.OverlapSphere(groundCheck.position, groundedRadius, Ground);
        for(int i=0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }
    }
	
	void Update () {
        if(swipeControls.tap && !grounded)
        {
            swipeControls.tap = false;
        }
        if (swipeControls.tap && grounded)
        {
            Jump();
        }

        if (Physics.Raycast(transform.position, Vector3.right, attackRange, enemyMask))
        {
            Debug.Log("enemyInRange");
        }
    }

    void Jump()
    {
        rb.velocity = Vector3.up * jumpSpeed;
        swipeControls.tap = false;
    }

}
