using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
	public static PlayerStats Statistics = new PlayerStats();

    public GameObject RedWin;
    public GameObject BlueWin;
    public GameObject GreenWin;
    public GameObject YellowWin;

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
		int showing = Mathf.Max((int) Mathf.Round (RemaningTime), 0);
		TimeRemaining.text = showing.ToString();

		if (RemaningTime < 0.0f) {
			if (RemaningTime >= -1.0) {
                Statistics = new PlayerStats();

                float f = Mathf.Max(P1S, Mathf.Max(P2S, Mathf.Max(P3S, P4S)));
                int w = 0;

                if (f == P1S)
                    w = 1;

                if (f == P2S)
                    w = 2;

                if (f == P3S)
                    w = 3;

                if (f == P4S)
                    w = 4;

                if (w == 1)
                    RedWin.SetActive(true);

                if (w == 2)
                    YellowWin.SetActive(true);

                if (w == 3)
                    GreenWin.SetActive(true);

                if (w == 4)
                    BlueWin.SetActive(true);
            }
            if (RemaningTime < -5.0)
            {

                Statistics = new PlayerStats();
                P1S = 0;
                P2S = 0;
                P3S = 0;
                P4S = 0;
                SceneManager.LoadScene("levelblueprint");
            }
		}
	}

}
