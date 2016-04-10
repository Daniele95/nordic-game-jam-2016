using UnityEngine;
using System.Collections;

public class AngelKontrol2 : MonoBehaviour {

	public static AngelKontrol2 kontrol_Angels2;
	public GameObject[] Angels;
	public int Maximum_Rays_Cycles = 2;

	public AngelBehavior[] Scripts = new AngelBehavior[6];

	private AngelBehavior Behav_1;
	private AngelBehavior Behav_2;

	private int rays_1 = 0;
	private int rays_2 = 0;


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



	private int Active_1 = 0;
	private int Active_2 = 0;
	private float delta_time_1 = 0.0f;
	private float delta_time_2 = 0.0f;

	// Use this for initialization
	void Start () {
		
		//for (int i = 0; i < Scripts.Length; ++i) {
		//	Scripts[i] = (AngelBehavior)Angels[i].transform.gameObject.GetComponent (typeof(AngelBehavior));
		//}

		Sel_Active_1 ();
		Sel_Active_2 ();
		Activate ();
	}
	
	// Update is called once per frame
	void Update () {
		delta_time_1 += Time.deltaTime;
		delta_time_2 += Time.deltaTime;

		if ((delta_time_1 > 0.0) &&
		   (delta_time_1 < Light_Warning_Start)) {
//			Scripts [Active_1].phase = 0;
			AngelBehavior Comodo = (AngelBehavior)Angels[Active_1].transform.gameObject.GetComponent (typeof(AngelBehavior));
			Comodo.phase = 0;
		}

		if ((delta_time_2 > 0.0) &&
			(delta_time_2 < Light_Warning_Start)) {
//			Scripts [Active_2].phase = 0;
			AngelBehavior Comodo = (AngelBehavior)Angels[Active_2].transform.gameObject.GetComponent (typeof(AngelBehavior));
			Comodo.phase = 0;
		}

		if ((delta_time_1 <= Light_Death_Start) &&
			(delta_time_1 > Light_Warning_Start)) {
			AngelBehavior Comodo = (AngelBehavior)Angels[Active_1].transform.gameObject.GetComponent (typeof(AngelBehavior));
			Comodo.phase = 1;
		}

		if ((delta_time_2 <= Light_Death_Start) &&
			(delta_time_2 > Light_Warning_Start)) {
			AngelBehavior Comodo = (AngelBehavior)Angels[Active_2].transform.gameObject.GetComponent (typeof(AngelBehavior));
			Comodo.phase = 1;
		}
			
		if ((delta_time_1 <= Light_Death_Finish) &&
			(delta_time_1 > Light_Death_Start)) {
			AngelBehavior Comodo = (AngelBehavior)Angels[Active_1].transform.gameObject.GetComponent (typeof(AngelBehavior));
			Comodo.phase = 2;
		}

		if ((delta_time_2 <= Light_Death_Finish) &&
			(delta_time_2 > Light_Death_Start)) {
			AngelBehavior Comodo = (AngelBehavior)Angels[Active_2].transform.gameObject.GetComponent (typeof(AngelBehavior));
			Comodo.phase = 2;
		}

		if (delta_time_1 > Light_Death_Finish) {
			delta_time_1 = 0.0f;
			rays_1++;
		}

		if (delta_time_2 > Light_Death_Finish) {
			delta_time_2 = 0.0f;
			rays_2++;
		}

		if (rays_1 == Maximum_Rays_Cycles)
		{
			rays_1 = 0;
			Sel_Active_1 ();
			Activate ();
		}
		
		if ( rays_2 == Maximum_Rays_Cycles)
		{
			rays_2 = 0;
			Sel_Active_2 ();
			Activate ();
		}
			
	}

	public void Sel_Active_1()
	{
		Active_1 = Random.Range (0, Angels.Length - 1);
		while (Active_1 == Active_2) {
			Active_1 = Random.Range (0, Angels.Length - 1);
		}
	}

	public void Sel_Active_2()
	{
		Active_2 = Random.Range (0, Angels.Length - 1);
		while (Active_1 == Active_2) {
			Active_2 = Random.Range (0, Angels.Length - 1);
		}
	}

	public void Activate ()
	{
		for (int i = 0; i < Angels.Length; ++i) 
		{
			if (i == Active_1) {
				Angels [i].SetActive (true);
				continue;
			}

			if (i == Active_2) {
				Angels [i].SetActive (true);
				continue;
			}

			Angels [i].SetActive (false);
		}
	}
}
