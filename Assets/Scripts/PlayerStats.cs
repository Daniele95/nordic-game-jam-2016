using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
	public static PlayerStats Statistics = new PlayerStats();

    public float RemaningTime;
	public Text TimeRemaining;
	public Image EndGame;
	public float transition_time;
	public float end_game_time;

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
			if (RemaningTime >= -1.0) {
				Color c = EndGame.color;
				c.a = Mathf.Lerp (0.0f, 1.0f, -RemaningTime);
				EndGame.color = c;
			}
			if (RemaningTime < -5.0)
				SceneManager.LoadScene ("levelblueprint");
		}
	}

}
