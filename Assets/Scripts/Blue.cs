﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blue : MonoBehaviour {

    Text tekst;

	// Use this for initialization
	void Awake () {
        tekst = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        tekst.text = "Score : " + PlayerStats.Statistics.P4S;
    }


}