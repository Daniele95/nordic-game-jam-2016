using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    Transform point;
    Vector3 LastPos;

    void Awake() {
    }
	
	void Update () {
        transform.RotateAround(point.position, Vector3.forward, 60 * Time.deltaTime);
        //transform.Rotate((transform.position - LastPos) * Time.deltaTime * 600);

        LastPos = transform.position;
    }

    public void init(Transform p) {
        point = p;
    }
}
