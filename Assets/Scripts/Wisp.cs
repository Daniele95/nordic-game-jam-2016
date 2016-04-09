using UnityEngine;
using System.Collections;

public class Wisp : MonoBehaviour {

    private int color = 1;
    Material newMaterial;

    void Start () {
        MeshRenderer gameObjectRenderer = gameObject.GetComponent<MeshRenderer>();

        newMaterial = new Material("my mat");

        newMaterial.color = Color.white;
        gameObjectRenderer.material = newMaterial;
    }

	void Update () {

        if (color == 0)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().drag = 5;
            newMaterial.color = Color.white;
            gameObject.tag = "Untagged";
        }
        else {
            gameObject.tag = "wisp";
            newMaterial.color = Color.white;
        }

	}

    void OnCollisionEnter(Collision collision)
    {
        color = 0;
    }
}
