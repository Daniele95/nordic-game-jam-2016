using UnityEngine;
using System.Collections;

public class PlayerStats {
	public static PlayerStats Statistics;

    public float RemaningTime;
	public Canvas UsedCanv;

    public int P1S;
    public int P2S;
    public int P3S;
    public int P4S;

	void Update()
	{
		RemaningTime -= Time.deltaTime;
		if (RemaningTime <= 0.0f) {
		}
	}

}
