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

	public GameObject Win_Window;

	public GameObject WinRed;
	public GameObject WinBlue;
	public GameObject WinYellow;
	public GameObject WinGreen;

    public int P1S = 0; // red
    public int P2S = 0; // yellow
    public int P3S = 0; // green
    public int P4S = 0; // blue

	void Start()
	{/*
		WinRed.color= new Color (Red.color.r, Red.color.b, Red.color.g, 0);
		WinBlue.color= new Color (Blue.color.r, Blue.color.b, Blue.color.g, 0);
		WinGreen.color= new Color (Green.color.r, Green.color.b, Green.color.g, 0);
		WinYellow.color= new Color (Yellow.color.r, Yellow.color.b, Yellow.color.g, 0);
	*/
	}

	void Update()
	{
		RemaningTime -= Time.deltaTime;
		int showing = (int) Mathf.Round (RemaningTime);
		TimeRemaining.text = showing.ToString();
		if (RemaningTime < 0.0f) {
			if (RemaningTime >= -1.0) {
				Show_Winner ();


			}
			if (RemaningTime < -5.0) {
				P1S = 0; // red
				P2S = 0; // yellow
				P3S = 0; // green
				P4S = 0; // blue
				SceneManager.LoadScene ("levelblueprint");
			}
		}
	}

	private void Show_Winner ()
	{
		int w = 0;
		float f = Mathf.Max (P1S, Mathf.Max (P2S, Mathf.Max (P3S, P4S)));
		if (f == P1S)
//			Red.color= new Color (Red.color.r, Red.color.b, Red.color.g, 1);
			w = 1;
		if (f == P2S)
////			Yellow.color= new Color (Yellow.color.r, Yellow.color.b, Yellow.color.g, 1);
			w = 2;
		if (f == P3S)
///Green.color= new Color (Green.color.r, Green.color.b, Green.color.g, 1);
			w = 3;
		if (f == P4S)
//			Blue.color= new Color (Blue.color.r, Blue.color.b, Blue.color.g, 1);
			w = 4;

		Color c = EndGame.color;
		c.a = Mathf.Lerp (0.0f, 1.0f, -RemaningTime);
		EndGame.color = c;

		if (w == 1)
			WinRed.SetActive (true);
		if (w == 2)
			WinYellow.SetActive (true);
		if (w == 3)
			WinGreen.SetActive (true);
		if (w == 4)
			WinBlue.SetActive (true);
	}
}
