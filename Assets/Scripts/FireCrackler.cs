using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCrackler : MonoBehaviour
{
    public AudioSource fireCrackle;
    public AudioClip fireCrackling;

    // Start is called before the first frame update
    void Start()
    {
        fireCrackle = GetComponent<AudioSource>();
        fireCrackling = AudioManager.instance.fireCrackling;

        fireCrackle.clip = fireCrackling;

        fireCrackle.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFireGone())
        {
            fireCrackle.Stop();
        }

    }

    private bool isFireGone()
    {
        foreach (FireSpawner spawner in GameManager.instance.fireManager.fireSpawnerList)
        {
            if (spawner.isOccupied == true)
                return false;
        }
        return true;
    }
}
