using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIOptions : MonoBehaviour
{
    public AudioMixer mainAudioMixer;

    [Header("Volume Sliders")]
    public Slider mainVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;

    private void Start()
    {
        //defaults for slider position
        mainVolumeSlider.value = 1.0f;
        musicVolumeSlider.value = 1.0f;
        soundVolumeSlider.value = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
            GameManager.instance.ActivateMainMenuState();
        }
    }

    //opens main menu
    public void MainMenuButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateMainMenuState();
    }

    public void OnMainVolumeChange()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        AudioManager.instance.VolumeChange(mainAudioMixer, "MasterVolume", mainVolumeSlider.value);
    }

    public void OnMusicVolumeChange()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        AudioManager.instance.VolumeChange(mainAudioMixer, "MusicVolume", musicVolumeSlider.value);
    }

    public void OnSoundVolumeChange()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        AudioManager.instance.VolumeChange(mainAudioMixer, "SoundVolume", soundVolumeSlider.value);
    }
}
