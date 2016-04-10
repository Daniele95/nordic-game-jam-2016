using UnityEngine;
using System.Collections;

public class PlayerStats {
	public static PlayerStats Statistics = new PlayerStats();

    public float RemaningTime;
	public Canvas UsedCanv;

    public int P1S = 0;
    public int P2S = 0;
    public int P3S = 0;
    public int P4S = 0;


	void Update()
	{
		RemaningTime -= Time.deltaTime;
		if (RemaningTime <= 0.0f) {
		}
	}

}
