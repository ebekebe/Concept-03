using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    Slider healthSlider;

	void Start () {

        currentHealth = maxHealth;
        healthSlider = GameObject.Find("Canvas/Slider").GetComponent<Slider>();
        healthSlider.value = currentHealth;

    }
	
	void Update () {

        healthSlider.value = currentHealth;
        if(currentHealth<=0)
        {

            Death();
        }
		
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void Death()
    {
        gameObject.SetActive(false);
    }
}
