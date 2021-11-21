using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip idleClip;
    public AudioClip bridgeClip;
    public AudioClip battleClip;
    public AudioClip loseClip;
    public AudioClip winClip;
    // Start is called before the first frame update
    
    public float lastPlayed;
    public void PlayIdle()
    {
        audioSource.clip = idleClip;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void PlayBridge()
    {
        lastPlayed = Time.timeSinceLevelLoad;
        audioSource.clip = bridgeClip;
        audioSource.loop = false;
        audioSource.Play();
    }
    public void PlayBattle()
    {
        audioSource.clip = battleClip;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void PlayLose()
    {
        audioSource.clip = loseClip;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlayWin()
    {
        audioSource.clip = winClip;
        audioSource.loop = false;
        audioSource.Play();
    }



    // Update is called once per frame
    void Update()
    {
        if(audioSource.clip == bridgeClip)
        {
            //if(Time.timeSinceLevelLoad-lastPlayed)

        }
    }
}
