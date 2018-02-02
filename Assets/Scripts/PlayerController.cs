using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {


    Rigidbody rb;

    TouchControls touchControls;

    public float attackRange;
    public float jumpSpeed = 5f;

    int enemyMask;

    [SerializeField] LayerMask Ground;
    Transform groundCheck;
    float groundedRadius;
    bool grounded;

    void Start ()
    {

        rb = GetComponent<Rigidbody>();
        touchControls = GetComponent<TouchControls>();
        enemyMask = LayerMask.GetMask("Enemy");
        groundCheck = transform.Find("groundCheck");
    }

    void FixedUpdate()
    {
        grounded = false;
        Collider[] colliders = Physics.OverlapSphere(groundCheck.position, groundedRadius, Ground);
        for (int i = 0; i<colliders.Length; i++)
        {
            if (colliders[i].gameObject!=gameObject)
            {
                grounded = true;
            }
        }
    }

    void Update ()
    {
        //Debug.Log(grounded);
        if (touchControls.tap && !grounded)
        {
            touchControls.tap = false;
        }
        if (touchControls.tap && grounded)
        {
            Jump();
        }
        if (touchControls.swipeRight)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.right, out hit, attackRange, enemyMask))
            {
                Debug.Log("meleeAttack " + hit.transform.name);
                hit.transform.GetComponent<Enemy>().TakeDamage(20);

            }
            else
            {
                Debug.Log("rangedAttack");
            }
            touchControls.swipeRight = false;
        }

    }

    void Jump()
    {
        rb.velocity = Vector3.up * jumpSpeed;
        touchControls.tap = false;
    }

}