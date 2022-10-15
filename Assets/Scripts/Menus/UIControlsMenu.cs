using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlsMenu : MonoBehaviour
{
    //goes to main menu
    public void MainMenuButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateMainMenuState();
    }
}
