using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthImage;
    public Health health;


    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health != null)
        {
            healthImage.fillAmount = health.currentHealth / health.maxHealth;
        }

        //should be called in the playerSpawner with a ref to GameManager... but we're close on time
        if (GameManager.instance.players.Count > 0)
        {
            health = GameManager.instance.players[0].GetComponent<Health>();
        }
    }
}
