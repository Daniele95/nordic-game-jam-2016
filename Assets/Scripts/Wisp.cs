using UnityEngine;
using System.Collections;

public class Wisp : MonoBehaviour {

    private GameObject NeutrualWisp;
    private int color = 0;
    Material newMaterial;

    void Start () {
        MeshRenderer gameObjectRenderer = gameObject.GetComponent<MeshRenderer>();

        newMaterial = new Material(Shader.Find(" Diffuse"));

        newMaterial.color = Color.white;
        gameObjectRenderer.material = newMaterial;
    }

	void Update () {

        if(color == 1)
        {
            gameObject.tag = "wisp1";
            newMaterial.color = Color.red;
        }
        else if (color == 2)
        {
            gameObject.tag = "wisp2";
            newMaterial.color = Color.blue;
        }
        else if (color == 3)
        {
            gameObject.tag = "wisp3";
            newMaterial.color = Color.green;
        }
        else if (color == 4)
        {
            gameObject.tag = "wisp4";
            newMaterial.color = Color.yellow;
        }

    }

    public void setColor(int c) {
        color = c;
    }

    public void setNW(GameObject g)
    {
        NeutrualWisp = g;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject g = Instantiate(NeutrualWisp, transform.position, Quaternion.identity) as GameObject;
        g.transform.rotation.SetEulerAngles(-90,0,0);
        Destroy(gameObject);
    }
}
