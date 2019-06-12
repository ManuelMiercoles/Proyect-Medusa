using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public AudioClip shotSound;

    public bool isFiring;

    public Bullet bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                transform.GetComponent<AudioSource>().PlayOneShot(shotSound);
                Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Bullet;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
	}
}
