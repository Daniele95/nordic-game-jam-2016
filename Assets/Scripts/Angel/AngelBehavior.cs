using UnityEngine;
using System.Collections;

public class AngelBehavior : MonoBehaviour {

	public Vector2 Aiming_Spot = new Vector2 (0.0f, 0.0f);

	public float Light_Warning_Start = 1.0f;
	public float Light_Death_Start = 2.0f;
	public float Light_Death_Finish = 3.0f;

	public float Light_Warning_Intensity = 2;
	public float Light_Death_Intensity = 8;

	public float Light_Warning_Start_speed = 1;
	public float Light_Death_Start_speed = 1;
	public float Light_Death_Finish_speed = 1;

	public double Light_Radial_Speed = 1.0f;
	public float Light_ConeRadius = 1.0f;
	public float Light_Start_angle = 45.0f;
	public GameObject Cone_Light;
	public GameObject Light_Angle_Adjust;

	public int phase = 0;

	public bool phase_switch_1 = false;
	public bool phase_switch_2 = false;
	public bool phase_switch_3 = false;

	//Privates for control of rotation during update
	private float time_delta;
	private double time_time = 0;
	private float rotation_angle = 0.0f;
	private Light lt_comp;
	private bool killing_time = false;
	private float delta_time_mult = 1.0f;
	private int rays = 0;

	// Use this for initialization
	void Start () 
	{
		lt_comp = Cone_Light.GetComponent<Light> ();
		Light_Angle_Adjust.transform.Rotate( 0.0f, 0.0f, Light_Start_angle, Space.World);
		time_time = Time.time;

		// randomize the delta_time so the different angels has desync
		time_delta = Random.value * Light_Death_Finish;
	//	time_delta = 0.0f;
	}


	// Update is called once per frame
	void Update () 
	{
		
		time_delta += Time.deltaTime;


		if (time_time + 1 < Time.time) {
			time_time = Time.time;
		}

		check_phase ();


		float angle;
		angle = Mathf.Sin ( (float) time_time * (float) Light_Radial_Speed);
		Cone_Light.transform.Rotate (0.0f, angle, 0.0f);

		// After this check it will return IF it's not KILLING TIME
		if (!killing_time) {
			return;
		}

		Ray light_cast = new Ray();
		light_cast.direction = Cone_Light.transform.forward;
		Debug.DrawLine (transform.position, transform.position + Cone_Light.transform.forward * 100);
		light_cast.origin = Light_Angle_Adjust.transform.position;

		// Checking for player inside the light cone
		RaycastHit Victim;
		if (!Physics.Raycast (light_cast, out Victim))
			return;

		PlayerMovement PlayerScript = (PlayerMovement)Victim.transform.gameObject.GetComponent (typeof(PlayerMovement));
		if( PlayerScript)
		{
			PlayerScript.Die ();
			return;
		}
	}
		
	public int Get_Ray_Shooted()
	{
		return rays;
	}

	public void Reset_Rays()
	{
	}

	private void check_phase()
	{
		if( ( phase     ==  0		  ) &&
			( phase_switch_1 != true)       )
		{
			Cone_Light.SetActive (false);
			lt_comp.intensity = 0;
			killing_time = false;

			phase_switch_1 = true;
			phase_switch_2 = false;
			phase_switch_3 = false;
		} 

		if( (phase 		==  1) &&
			(phase_switch_2 != true) )
		{
			Cone_Light.SetActive (true);
			lt_comp.intensity = Light_Warning_Intensity;


			phase_switch_1 = false;
			phase_switch_2 = true;
			phase_switch_3 = false;
		} 

		if( (  phase      == 2 ) &&
			(  phase_switch_3 != true ) )
		{
			killing_time = true;
			lt_comp.intensity = Light_Death_Intensity;


			phase_switch_1 = false;
			phase_switch_2 = false;
			phase_switch_3 = true;
		}


	}
}
