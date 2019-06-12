using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.transform.Rotate(90f,0f,0f);
        Destroy(gameObject, 2);
	}
	
	void Update ()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<IAZombie>().Hurt(1);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
        }
    }
}
