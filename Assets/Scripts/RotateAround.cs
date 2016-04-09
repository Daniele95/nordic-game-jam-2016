using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    Transform point;

    void Awake() {
    }
	
	void Update () {
        transform.RotateAround(point.position, Vector3.forward, 20 * Time.deltaTime);
    }

    public void init(Transform p) {
        point = p;
    }
}
