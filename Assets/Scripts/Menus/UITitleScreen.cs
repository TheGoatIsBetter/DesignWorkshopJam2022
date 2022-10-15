using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitleScreen : MonoBehaviour
{
    //goes to main menu
    public void StartGameButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateMainMenuState();
    }
}
