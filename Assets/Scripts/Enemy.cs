using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    public float moveSpeed;

    Rigidbody rb;
    GameObject player;

    public float attackRange;
    

	void Start () {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
	}
	
	void Update () {
        Move();
    }

    void Move()
    {
        if((transform.position.x -player.transform.position.x) >= attackRange)
        {
            transform.position += -Vector3.right * moveSpeed * Time.deltaTime;
        }
        
    }
}
