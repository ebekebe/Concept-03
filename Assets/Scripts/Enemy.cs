using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public float secondsPerAttack;

    public float moveSpeed;

    float timer;
    Rigidbody rb;
    GameObject player;

    [SerializeField]
    LayerMask playerMask;

    public float attackRange;


    void Start ()
    {
        timer = 0;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        Move();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.left, out hit, attackRange, playerMask))
        {
            Debug.Log("playerInRange");
            if (timer >= secondsPerAttack)
            {
                hit.transform.GetComponent<PlayerHealth>().TakeDamage(10);
                timer = 0;
            }
        }
    }

    void Move()
    {
        if ((transform.position.x - player.transform.position.x) >= attackRange - 1)
        {
            transform.position += -Vector3.right * moveSpeed * Time.deltaTime;
        }

    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}