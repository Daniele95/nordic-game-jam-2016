using UnityEngine;
using System.Collections;

public class Animatorqwe : MonoBehaviour {

    int ControllerID = 1;
    Animator animator;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal" + ControllerID)) > 0.3f)
        {
            animator.SetBool("Moveing", true);
        }
        else {
            animator.SetBool("Moveing", false);
        }

        bool InputE = false;

        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
            InputE = true;
        if (Input.GetKeyDown(KeyCode.Joystick2Button5))
            InputE = true;
        if (Input.GetKeyDown(KeyCode.Joystick3Button5))
            InputE = true;
        if (Input.GetKeyDown(KeyCode.Joystick4Button5))
            InputE = true;
    }
}
