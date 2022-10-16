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


    [Header("Screen State Objects")]
    [SerializeField] private GameObject titleScreenStateObject;
    [SerializeField] private GameObject gameOverStateObject;
    [SerializeField] private GameObject mainMenuStateObject;
    [SerializeField] private GameObject optionsStateObject;
    [SerializeField] private GameObject controlsStateObject;
    [SerializeField] private GameObject creditsStateObject;
    [SerializeField] private GameObject gameplayStateObject;


    #endregion variables

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
        gameplayStateObject.SetActive(true);
    }
}
