using UnityEngine;
using System.Collections;

public class AngelKontrol : MonoBehaviour {

	public static AngelKontrol kontrol_Angels;
	public GameObject[] Spawns;
	public int Number_Of_Rays_Before_Respawn = 2;
	public GameObject Angel_One;
	public GameObject Angel_Two;

	private AngelBehavior One_Behav;
	private AngelBehavior Two_Behav;

	private int pos_1;
	private int pos_2;

	// Use this for initialization
	void Awake () {
		if (kontrol_Angels == null) {
			DontDestroyOnLoad (gameObject);
			kontrol_Angels = this;
		} else if (kontrol_Angels != this) {
			Destroy (gameObject);
		}
	}

	void Start (){

		One_Behav = (AngelBehavior)Angel_One.transform.gameObject.GetComponent (typeof(AngelBehavior));
		Two_Behav = (AngelBehavior)Angel_One.transform.gameObject.GetComponent (typeof(AngelBehavior));

		Angel_One_Respawn ();
		Angel_Two_Respawn ();
/*
		pos_1 = Random.Range (0, ( Spawns.Length - 1) );
		pos_2 = Random.Range (0, ( Spawns.Length - 1) );
		while (pos_2 == pos_1) {
			pos_2 = Random.Range (0, ( Spawns.Length - 1) );
		}

		Angel_One.transform.rotation = Spawns [pos_1].transform.rotation;
		Angel_One.transform.position = Spawns [pos_1].transform.position;

		Angel_Two.transform.rotation = Spawns [pos_2].transform.rotation;
		Angel_Two.transform.position = Spawns [pos_2].transform.position;
*/
	}
	
	// Update is called once per frame
	void Update () {
		if ( ( One_Behav.Get_Ray_Shooted() == Number_Of_Rays_Before_Respawn) ||
			 ( One_Behav.Get_Ray_Shooted() > Number_Of_Rays_Before_Respawn )    )
		{
			Angel_One_Respawn ();
		}

		Debug.Log (Two_Behav.Get_Ray_Shooted( ));
		if ( ( Two_Behav.Get_Ray_Shooted() == Number_Of_Rays_Before_Respawn) ||
			 ( Two_Behav.Get_Ray_Shooted() > Number_Of_Rays_Before_Respawn)     )
		{
			Angel_Two_Respawn ();
		}
	}

	public void Angel_One_Respawn()
	{
		pos_1 = Random.Range (0, ( Spawns.Length - 1) );
		while (pos_1 == pos_2) {
			pos_1 = Random.Range (0, ( Spawns.Length - 1) );
		}
		Angel_One.transform.rotation = Spawns [pos_1].transform.rotation;
		Angel_One.transform.position = Spawns [pos_1].transform.position;

		One_Behav.Reset_Rays ();
	}

	public void Angel_Two_Respawn()
	{
		pos_2 = Random.Range (0, ( Spawns.Length - 1) );
		while (pos_2 == pos_1) {
			pos_2 = Random.Range (0, ( Spawns.Length - 1) );
		}
		Angel_Two.transform.rotation = Spawns [pos_2].transform.rotation;
		Angel_Two.transform.position = Spawns [pos_2].transform.position;

		Two_Behav.Reset_Rays ();
	}
}
