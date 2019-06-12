using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAZombie : MonoBehaviour
{
    public GameObject objTarget;
    Transmisor transmisor;
    Player playerTarget;
    GameController gc;
    public NavMeshAgent Agent;

    public float speed;
    public float distance;
    public int health = 10;
    public float damage = 10.0f;

    private int currentHealth;

	void Start ()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        transmisor = GameObject.FindGameObjectWithTag("Transmisor").GetComponent<Transmisor>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        currentHealth = health;
	}
	
	void Update ()
    {
        if (Vector3.Distance(objTarget.transform.position, transform.position) > Vector3.Distance(playerTarget.transform.position, transform.position))
        {
            if (Vector3.Distance(playerTarget.transform.position, transform.position) > distance)
            {
                Agent.speed = speed;
                Agent.SetDestination(playerTarget.transform.position);
            }
            else
            {
                Agent.speed = 0;
                playerTarget.Hurt(damage);
            }
        }
        else
        {
            if (Vector3.Distance(objTarget.transform.position, transform.position) > distance)
            {
                Agent.speed = speed;
                Agent.SetDestination(objTarget.transform.position);
            }
            else
            {
                Agent.speed = 0;
                transmisor.Hurt(damage);
            }
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            gc.IncrementScore();
        }
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
    }
}
