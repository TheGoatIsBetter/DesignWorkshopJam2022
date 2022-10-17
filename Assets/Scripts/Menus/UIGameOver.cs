using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    public TextMeshProUGUI winDesc;
    public TextMeshProUGUI loseDesc;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI youWin;



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


    public void Update()
    {
        

        if(GameManager.instance.isWinning == false)
        {
            gameOver.gameObject.SetActive(true);
            youWin.gameObject.SetActive(false);
            winDesc.gameObject.SetActive(false);
            loseDesc.gameObject.SetActive(true);
        }
        else
        {
            gameOver.gameObject.SetActive(false);
            youWin.gameObject.SetActive(true);
            winDesc.gameObject.SetActive(true);
            loseDesc.gameObject.SetActive(false);
        }
    }
}
