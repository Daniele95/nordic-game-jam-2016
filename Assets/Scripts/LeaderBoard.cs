using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderBoard : MonoBehaviour {

    Image leader;

	void Start () {
        leader = gameObject.GetComponent<Image>();
    }

	void Update () {

        leader.color = new Color(0,255,0);
	}
}
