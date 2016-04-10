using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField, Range(1,4)]
    public int ControllerID = 1;
    [SerializeField]
    private Vector3[] SpawnPoints = new Vector3[4];
    [SerializeField]
    private GameObject Projectile;
    [SerializeField]
    private GameObject NeutrualWisp;
    [SerializeField]
    private GameObject Souls;
    [SerializeField]
    private GameObject EmptyObject;
    [SerializeField]
    private GameObject Graphics;
    [SerializeField]
    private GameObject Kabbuuum;
    [SerializeField]
    private float ProjectileSpeed;
    [SerializeField]
    private float speedHor;
    [SerializeField]
    private float JumpForce;
    private Rigidbody body;
    private bool grounded = false;
    [SerializeField]
    private int StartAmmo = 3;
    [SerializeField]
    public AudioClip[] AudioClips = new AudioClip[3];
    [SerializeField]
    public Animator Anim = new Animator();
    [SerializeField]
    private List<GameObject> ammoShow = new List<GameObject>();
    private int ammo = 3;
    private Vector3 lastAim;


    void Start () {
        ammo = StartAmmo;
        body = gameObject.GetComponent<Rigidbody>();
        gameObject.tag = "player" + ControllerID;
        UpdateAmmoCount();
        lastAim = new Vector3(1,0,0);
        Wisp.RandomAudioClips = AudioClips;

    }
	
	void Update () {

        grounded = isGrounded();

        RaycastHit asd;

        if(Mathf.Abs(Input.GetAxisRaw("Horizontal" + ControllerID)) > 0.3f && !Physics.SphereCast(transform.position, 0.2f, new Vector3(Input.GetAxisRaw("Horizontal" + ControllerID), 0, 0).normalized, out asd, 0.2f))
            body.MovePosition(new Vector3(Input.GetAxisRaw("Horizontal" + ControllerID) * speedHor * Time.deltaTime, 0) + transform.position);

        if (Input.GetAxisRaw("Horizontal" + ControllerID) > 0.3f) {
            Graphics.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetAxisRaw("Horizontal" + ControllerID) < -0.3f)
        {
            Graphics.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        bool InputX = false;
        bool InputE = false;

        if (ControllerID == 1) {
            InputX = Input.GetKeyDown(KeyCode.Joystick1Button0);
            InputE = Input.GetKeyDown(KeyCode.Joystick1Button5);
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
                InputE = true;
        }
        if (ControllerID == 2)
        {
            InputX = Input.GetKeyDown(KeyCode.Joystick2Button0);
            InputE = Input.GetKeyDown(KeyCode.Joystick2Button5);
            if (Input.GetKeyDown(KeyCode.Joystick2Button3))
                InputE = true;
        }
        if (ControllerID == 3)
        {
            InputX = Input.GetKeyDown(KeyCode.Joystick3Button0);
            InputE = Input.GetKeyDown(KeyCode.Joystick3Button5);
            if (Input.GetKeyDown(KeyCode.Joystick3Button3))
                InputE = true;
        }
        if (ControllerID == 4)
        {
            InputX = Input.GetKeyDown(KeyCode.Joystick4Button0);
            InputE = Input.GetKeyDown(KeyCode.Joystick4Button5);
            if (Input.GetKeyDown(KeyCode.Joystick4Button3))
                InputE = true;
        }

        Anim.SetBool("Attack", false);

        if ((Input.GetKeyDown(KeyCode.W) || InputX) && grounded) {
            body.velocity = new Vector3(body.velocity.x, JumpForce, body.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) || InputE)
        {
            Shoot();
        }

        if (Input.GetAxisRaw("Hor" + ControllerID) != 0 && -Input.GetAxisRaw("Ver" + ControllerID) != 0)
            lastAim = new Vector3(Input.GetAxisRaw("Hor" + ControllerID), -Input.GetAxisRaw("Ver" + ControllerID), 0).normalized;

    }

    void UpdateAmmoCount() {

        EmptyObject.transform.rotation = Quaternion.identity;

        for (int i = 0; i < ammoShow.Count; i++)
        {
            Destroy(ammoShow[i]);
        }

        ammoShow.Clear();

        for (int i = ammoShow.Count; i < ammo; i++) {
            GameObject g = Instantiate(Souls, transform.position, Quaternion.identity) as GameObject;
            ammoShow.Add(g);
        }

        for (int i = 0; i < ammoShow.Count; i++) {

            float angle = 360 / ammo;

            ammoShow[i].transform.position = transform.position + EmptyObject.transform.up + new Vector3(0,0,-5);
            ammoShow[i].transform.SetParent(transform);
            EmptyObject.transform.Rotate(0,0, angle);
            RotateAround other = (RotateAround)ammoShow[i].GetComponent(typeof(RotateAround));
            other.init(transform);
        }

    }

    void OnTriggerEnter(Collider collision)
     {
         if ((collision.gameObject.tag != "wisp" + ControllerID) && collision.gameObject.tag.Substring(0,4) == "wisp" && collision.gameObject.tag != "wisp0") {

            if (collision.gameObject.tag == "wisp1")
                PlayerStats.P1S++;

            if (collision.gameObject.tag == "wisp2")
                PlayerStats.P2S++;

            if (collision.gameObject.tag == "wisp3")
                PlayerStats.P3S++;

            if (collision.gameObject.tag == "wisp4")
                PlayerStats.P4S++;

            Die();

            UpdateAmmoCount();

        }
    }

    void OnCollisionEnter(Collision collision)
    {

       if (collision.gameObject.tag == "wisp0")
        {
            PickUp(collision.gameObject);
            body.velocity = Vector3.zero;
            UpdateAmmoCount();
        }
    }

    public void Die() {
        transform.position = SpawnPoints[Random.Range(0,SpawnPoints.Length)];
        ammo = StartAmmo;
        UpdateAmmoCount();
    }

    public void PickUp(GameObject g) {
        Destroy(g);
        ammo++;
        UpdateAmmoCount();
    }

    void Shoot() {
        if (ammo <= 0)
            return;

        Anim.SetBool("Attack", true);

        GameObject g = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z) + new Vector3(Input.GetAxisRaw("Hor" + ControllerID), -Input.GetAxisRaw("Ver" + ControllerID), 0).normalized * .9f, Quaternion.identity) as GameObject;

        if (Input.GetAxisRaw("Hor" + ControllerID) != 0 && -Input.GetAxisRaw("Ver" + ControllerID) != 0)
            g.GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxisRaw("Hor" + ControllerID), -Input.GetAxisRaw("Ver" + ControllerID), 0).normalized * ProjectileSpeed;
        else {
            g.GetComponent<Rigidbody>().velocity = lastAim * ProjectileSpeed;
        }

        EmptyObject.transform.LookAt( new Vector3(transform.position.x, transform.position.y, transform.position.z) + new Vector3(Input.GetAxisRaw("Hor" + ControllerID), -Input.GetAxisRaw("Ver" + ControllerID), 0).normalized * 2f);

        g.transform.rotation.Set(EmptyObject.transform.rotation.x, EmptyObject.transform.rotation.y, EmptyObject.transform.rotation.z, EmptyObject.transform.rotation.w);

        //g.transform.LookAt(transform.position + transform.forward * 5);
        Wisp other = (Wisp)g.GetComponent(typeof(Wisp));
        other.setColor(ControllerID);
        other.setNW(NeutrualWisp, Kabbuuum);
        ammo--;
        UpdateAmmoCount();
    }

    bool isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
}
