using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    Vector3 point;

    void Awake() {
        point = new Vector3();
    }
	
	void Update () {
        transform.RotateAround(point, Vector3.up, 20 * Time.deltaTime);
    }

    void init(Vector3 p) {
        point = p;
    }
}
