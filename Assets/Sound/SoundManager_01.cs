using UnityEngine;
using System.Collections;

// This is a SoundManager. Everything audio in the project will be managed through here.
// Clips can be played calling the appropriate functions in the code and assigning the audio clips in the Unity Editor.
// For info on the various functions available please check the comments in this file or look in the documentation.

public class SoundManager_01 : MonoBehaviour
{

    public AudioSource sfxSound;                // Sound source for SFX
    public AudioSource msxSound;                // Sound source for Music
    public SoundManager_01 instance = null;     // instance of sound manager value, set to null

    // In the Awake function we check for multiple instances of the SoundManager.
    // For performance optimization and to avoid conflicts we will destroy all the SoundManager objects that are not this.

    void Awake()
    {
        // check if there are no instances of the sound manager
        if (instance == null)
            // in this case set it to this
            instance = this;

        // if there is already an instance of the sound manager, but it's not set to this
        else if (instance != this)
            // destroy it.
            Destroy(gameObject);
    }

    // From here on we will define the different functions needed...

    // The first function we need is the play function for a single sound.
    public void PlaySingleSound(AudioClip clip)
    {
        // assign the clip passed in to the sfx sound source
        sfxSound.clip = clip;

        // and play it.
        sfxSound.Play();
    }

    // The second function plays a random sound from an array of sounds, randomized for pitch and volume
    public void PlayRandomSound(float minPitch, float maxPitch, float minVolume, float maxVolume, AudioClip[] clips)
    {

        // generating a random number to use as index selector for play
        int randomNumber = Random.Range(0, clips.Length);

        // assign the clip to our sfx source
        sfxSound.clip = clips[randomNumber];

        // support for random pitch
        AudioPitchRandomizer(sfxSound, minPitch, maxPitch);

        // support for random volume
        AudioVolumeRandomizer(sfxSound, minVolume, maxVolume);

        // and play it
        sfxSound.Play();
    }

    // Function for pitch randomization functionalities
    private float AudioPitchRandomizer(AudioSource sfxSource, float minPitch, float maxPitch)
    {

        // generating a random multiplier for pitch, in the [minPitch, maxPitch] range.
        float randomPitch = Random.Range(minPitch, maxPitch);

        // scaling the pitch of the sound source by its multiplier
        sfxSource.pitch *= randomPitch;

        // return it to the caller
        return sfxSource.pitch;
    }

    // Function for volume randomization functionalities
    private float AudioVolumeRandomizer(AudioSource sfxSource, float minVol, float maxVol)
    {

        // generating a random multiplier for volume, in the [minVol, maxVol] range.
        float randomVolume = Random.Range(minVol, maxVol);

        // scaling the volume of the sound source by its multiplier
        sfxSource.volume *= randomVolume;

        // return it to the caller
        return sfxSource.volume;
    }
}