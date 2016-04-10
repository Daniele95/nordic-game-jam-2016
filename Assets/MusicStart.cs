using UnityEngine;
using System.Collections;

public class MusicStart : MonoBehaviour {

    [SerializeField]
    AudioSource start;
    [SerializeField]
    AudioSource loop;
	
	void Update () {
        if (!start.isPlaying && !loop.isPlaying) {
            loop.Play();
        }
	}
}
