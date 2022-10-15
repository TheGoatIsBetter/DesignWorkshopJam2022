using UnityEngine;

class GameManager : MonoBehaviour
{
    public int firesPutOut = 0;
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
