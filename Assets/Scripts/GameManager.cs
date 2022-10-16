using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region variables

    //static (stays same) game manager instance
    public static GameManager instance;
    public static AudioManager audioManager;
    public Level level;

    public int firesPutOut = 0;


    [Header("Lists")]
    public List<PlayerController> players;
    public List<GameObject> playerSpawnPoints;


    [Header("Screen State Objects")]
    [SerializeField] private GameObject titleScreenStateObject;
    [SerializeField] private GameObject gameOverStateObject;
    [SerializeField] private GameObject mainMenuStateObject;
    [SerializeField] private GameObject optionsStateObject;
    [SerializeField] private GameObject controlsStateObject;
    [SerializeField] private GameObject creditsStateObject;
    [SerializeField] private GameObject gameplayStateObject;
    public GameObject pausemenuStateObject;


    #endregion variables

    void Load(string savedData)
    {
        JsonUtility.FromJsonOverwrite(savedData, this);
    }

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
        else //this isn't THE game manager
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateTitleScreenState();

        //attach audiomanager to gamemanager
        audioManager = AudioManager.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("yee");
        }

    }

    public void PauseGame()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        //set timescale back to 1 and resume game
        Time.timeScale = 0;
        GameManager.instance.pausemenuStateObject.SetActive(true);
    }



    //deactivate all gamestates
    private void DeactivateAllStates()
    {
        titleScreenStateObject.SetActive(false);
        gameOverStateObject.SetActive(false);
        mainMenuStateObject.SetActive(false);
        optionsStateObject.SetActive(false);
        controlsStateObject.SetActive(false);
        creditsStateObject.SetActive(false);
        gameplayStateObject.SetActive(false);
        pausemenuStateObject.SetActive(false);
    }

    public void ActivateTitleScreenState()
    {
        DeactivateAllStates();
        titleScreenStateObject.SetActive(true);
    }

    public void ActivateGameOverState()
    {
        DeactivateAllStates();
        gameOverStateObject.SetActive(true);
    }

    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        mainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsState()
    {
        DeactivateAllStates();
        optionsStateObject.SetActive(true);
    }

    public void ActivateControlsState()
    {
        DeactivateAllStates();
        controlsStateObject.SetActive(true);
    }

    public void ActivateCreditsState()
    {
        DeactivateAllStates();
        creditsStateObject.SetActive(true);
    }

    public void ActivateGameplayState()
    {
        DeactivateAllStates();

        //kill the player if they exist
        if (players.Count > 0)
        {
            Destroy(players[0].gameObject);
        }

        //get a random spawner and spawn the player at it
        playerSpawnPoints[Random.Range(0, playerSpawnPoints.Count - 1)].GetComponent<PlayerSpawner>().SpawnPlayer();

        //reset fires extinguished
        firesPutOut = 0;

        gameplayStateObject.SetActive(true);

        
    }
}
