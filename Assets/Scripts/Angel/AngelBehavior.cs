using UnityEngine;
using System.Collections;

public class AngelBehavior : MonoBehaviour {

	public Vector2 Aiming_Spot = new Vector2 (0.0f, 0.0f);

	public float Light_Warning_Start = 1.0f;
	public float Light_Death_Start = 2.0f;
	public float Light_Death_Finish = 3.0f;

	public float Light_Warning_Intensity = 1000;
	public float Light_Death_Intensity = 5000;

	public float Light_Warning_Start_speed = 1;
	public float Light_Death_Start_speed = 1;
	public float Light_Death_Finish_speed = 1;

	public double Light_Radial_Speed = 1.0f;
	public float Light_ConeRadius = 1.0f;
	public float Light_Start_angle = 45.0f;
	public GameObject Cone_Light;
	public GameObject Light_Angle_Adjust;


	//Privates for control of rotation during update
	private float time_delta;
	private double time_time = 0;
	private int phase = 2;
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
	}


	// Update is called once per frame
	void Update () 
	{
		
		time_delta += Time.deltaTime;


		if (time_time + 1 < Time.time) {
			time_time = Time.time;
		}

		if (time_delta < Light_Warning_Start) {
			if (phase != 0)
				Cone_Light.SetActive (false);
				killing_time = false;
				phase = 0;

		} else if (time_delta < Light_Death_Start) {
			if (phase != 1) {
				Cone_Light.SetActive (true);
				lt_comp.intensity = Light_Warning_Intensity;
			}
			phase = 1;

		} else if (time_delta < Light_Death_Finish) {
			if (phase != 2) {
				killing_time = true;
				lt_comp.intensity = Light_Death_Intensity;
			}
			phase = 2;
		} else {
			rays++;
			time_delta = 0.0f;
		}
			
/*
		if (switch_light_movement) {
			angle = Sinerp ( Cone_Light.transform.rotation.eulerAngles.y, Light_Start_angle + Light_Oscillation_Degrees, time_delta);
		} else {
			angle = Sinerp ( Cone_Light.transform.rotation.eulerAngles.y, Light_Start_angle - Light_Oscillation_Degrees, time_delta);
		}

		angle = angle - Cone_Light.transform.rotation.eulerAngles.y;

*/

		float angle;
		angle = Mathf.Sin ( (float) time_time * (float) Light_Radial_Speed);
		Cone_Light.transform.Rotate (0.0f, angle, 0.0f);

		// After this check it will return IF it's not KILLING TIME
		if (!killing_time) {
			return;
		}

		Ray light_cast = new Ray();
		light_cast.direction = Cone_Light.transform.forward;
		Debug.DrawLine (transform.position, transform.position + Cone_Light.transform.forward);
	//	Debug.Log ("Kill Time:", );
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
		rays = 0;
	}
}
