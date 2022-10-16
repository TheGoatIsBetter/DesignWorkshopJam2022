using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;

    [Header("Sounds")]
    public AudioClip menuButton;
    public AudioClip extinguish;
    public AudioClip fireCrackling;

    //Awake is called before Start
    private void Awake()
    {
        if (instance == null)
        {
            //this is THE game manager
            instance = this;
            //don't kill it in a new scene.
            DontDestroyOnLoad(gameObject);
        }
        else //this isn't THE audio manager
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void VolumeChange(AudioMixer audioMixer, string nameOfMixer, float newVolume)
    {
        if (newVolume <= 0)
        {
            newVolume = -80; //set to bottommost log value for db
        }
        else
        {
            //>0 so use log10 because decibals
            newVolume = Mathf.Log10(newVolume);

            //0-20db instead of 0-1
            newVolume = newVolume * 20;

        }

        audioMixer.SetFloat(nameOfMixer, newVolume);
    }
}
