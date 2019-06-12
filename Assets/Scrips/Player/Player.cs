using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera mainCamera;

    Rigidbody rb;
    GameController gc;

    public GameObject bullet;
    public Gun arma;
    //public Transform front;
    //public Transform right;
    public float speed;
    public float health = 100;

    private Animator anim;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        anim = GetComponentInChildren<Animator>();
        mainCamera = FindObjectOfType<Camera>();
	}

    void Update()
    {
        /*float step = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, front.position, step);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.MoveTowards(transform.position, front.position, -step);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = Vector3.MoveTowards(transform.position, right.position, step);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = Vector3.MoveTowards(transform.position, right.position, -step);
        }*/

        //Movimiento
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speed;
            anim.SetFloat("Run", rb.velocity.magnitude);

        //Acciones
        if (Input.GetMouseButtonDown(0))
        {
            arma.isFiring = true;
            //anim.SetBool("isFiring", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            arma.isFiring = false;
            //anim.SetBool("isFiring", false);
        }

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Granada");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Ni idea");

        //Vista del jugador sigue cursor
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, 0f, pointToLook.z));
        }

        /*
        Vector3 pos = transform.position;
        pos.z = Mathf.Clamp(pos.z, 10, -10);
        pos.x = Mathf.Clamp(pos.x, 10, -10);
        transform.position = pos;
        */
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isFiring", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isFiring", false);
        }
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
