using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    //Resets and starts game
    public void StartGameButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateGameplayState();
    }

    //goes to main menu
    public void MainMenuButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateMainMenuState();
    }

    //quits the game
    public void QuitGameButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        Application.Quit();
    }
}
