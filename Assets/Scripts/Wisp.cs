using UnityEngine;
using System.Collections;

public class Wisp : MonoBehaviour {

    private GameObject NeutrualWisp;
    private int color = 0;
    Material newMaterial;
    AudioSource audio;

    public static AudioClip[] RandomAudioClips = new AudioClip[3];

    void Awake () {
        MeshRenderer gameObjectRenderer = gameObject.GetComponent<MeshRenderer>();

    }

	void Update () {

        if(color == 1)
        {
            gameObject.tag = "wisp1";
        }
        else if (color == 2)
        {
            gameObject.tag = "wisp2";
        }
        else if (color == 3)
        {
            gameObject.tag = "wisp3";
        }
        else if (color == 4)
        {
            gameObject.tag = "wisp4";
        }

    }

    public void setColor(int c) {
        color = c;

        if (color == 1)
        {
            gameObject.tag = "wisp1";
        }
        else if (color == 2)
        {
            gameObject.tag = "wisp2";
        }
        else if (color == 3)
        {
            gameObject.tag = "wisp3";
        }
        else if (color == 4)
        {
            gameObject.tag = "wisp4";
        }
    }

    public void setNW(GameObject g)
    {
        NeutrualWisp = g;

    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "player" + color)
            return;

        AudioClip[] sounds = new AudioClip[3];
        RandomAudioClips.CopyTo(sounds, 0);

        SoundManager_01 asd = new SoundManager_01();
        //asd.PlayRandomSound(0.85f, 1.15f, 0.7f, 1.3f, RandomAudioClips);

        GameObject g = Instantiate(NeutrualWisp, transform.position, Quaternion.identity) as GameObject;
        g.transform.rotation.SetEulerAngles(-90,0,0);
        Destroy(gameObject);
    }
}
