using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    public int ControllerID = 1;
    [SerializeField]
    private Vector3[] SpawnPoints = new Vector3[4];
    [SerializeField]
    private GameObject Projectile;
    [SerializeField]
    private float ProjectileSpeed;
    [SerializeField]
    private float speedVer;
    [SerializeField]
    private float speedHor;
    [SerializeField]
    private float JumpForce;
    private Rigidbody body;
    private bool grounded = false;


    void Start () {
        body = gameObject.GetComponent<Rigidbody>();
    }
	
	void Update () {

        grounded = isGrounded();

        body.MovePosition(new Vector3(Input.GetAxis("Horizontal" + ControllerID) * speedHor * Time.deltaTime, 0) + transform.position);

        bool InputX = false;
        bool InputE = false;

        if (ControllerID == 1) {
            InputX = Input.GetKeyDown(KeyCode.Joystick1Button0);
            InputE = Input.GetKeyDown(KeyCode.Joystick1Button1);
        }
        if (ControllerID == 2)
        {
            InputX = Input.GetKeyDown(KeyCode.Joystick2Button0);
            InputE = Input.GetKeyDown(KeyCode.Joystick1Button1);
        }
        if (ControllerID == 3)
        {
            InputX = Input.GetKeyDown(KeyCode.Joystick3Button0);
            InputE = Input.GetKeyDown(KeyCode.Joystick1Button1);
        }
        if (ControllerID == 4)
        {
            InputX = Input.GetKeyDown(KeyCode.Joystick4Button0);
            InputE = Input.GetKeyDown(KeyCode.Joystick1Button1);
        }

        if ((Input.GetKeyDown(KeyCode.W) || InputX) && grounded) {
            body.velocity = new Vector3(body.velocity.x, JumpForce, body.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) || InputE)
        {
            Shoot();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wisp") {
            Die();
        }
    }

    void Die() {
        transform.position = SpawnPoints[Random.Range(0,4)];
    }

    void Shoot() {
        GameObject g = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z) + transform.forward * 1.1f, Quaternion.identity) as GameObject;
        g.GetComponent<Rigidbody>().velocity = transform.forward * ProjectileSpeed;
        g.transform.LookAt(transform.position + transform.forward * 5);
    }

    bool isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
}
