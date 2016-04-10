using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
	public static PlayerStats Statistics = new PlayerStats();

    public float RemaningTime;
	public Text TimeRemaining;

    public int P1S = 0;
    public int P2S = 0;
    public int P3S = 0;
    public int P4S = 0;


	void Update()
	{
		RemaningTime -= Time.deltaTime;
		int showing = (int) Mathf.Round (RemaningTime);
		TimeRemaining.text = showing.ToString();
		if (RemaningTime < 0.0f) {
			SceneManager.LoadScene ( "levelblueprint" );
			
		}
	}

}
