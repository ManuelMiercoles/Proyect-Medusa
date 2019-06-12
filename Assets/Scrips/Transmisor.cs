using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmisor : MonoBehaviour
{

    public Rigidbody rb;
    GameController gc;

    public float health;
    float currentHealth;

	void Start ()
    {
        rb.GetComponent<Rigidbody>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        currentHealth = health;
	}
	
	void Update ()
    {
		
	}

    public void Hurt(float damange)
    {
        health -= damange * Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
            gc.gameOver();
        }
    }
}
