using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FireCrackler : MonoBehaviour
{
    public AudioSource fireCrackle;
    public AudioClip fireCrackling;
    public AudioMixer mainAudioMixer;
    public float nearestDistance;
    public float maxDistance = 10.0f;

    // Start is called before the first frame update
    void Awake()
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

            GameManager.instance.isWinning = true;

            GameManager.instance.ActivateGameOverState();
        }


        UpdateCrackleVolume();
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

    private void UpdateCrackleVolume()
    {
        nearestDistance = GetClosestFireDistance();
    
        AudioManager.instance.VolumeChange(mainAudioMixer, "FireCrackleVolume", maxDistance / nearestDistance);
    
    
    }
    
    public float GetClosestFireDistance()
    {
    
    
        float closestDist = fireCrackle.maxDistance;
        foreach (FireSpawner fireSpawner in GameManager.instance.fireManager.fireSpawnerList)
        {
            if(fireSpawner.isOccupied) {
                float dist = Vector3.Distance(fireSpawner.gameObject.transform.position, gameObject.transform.position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                }
            }
        }
    
        return closestDist;
    }
}
