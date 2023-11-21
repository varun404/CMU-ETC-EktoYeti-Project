using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSound : MonoBehaviour
{
    AudioSource groupPenguinAudioSource;

    float loopDelay;


    private void Awake()
    {
        groupPenguinAudioSource = GetComponent<AudioSource>();
        loopDelay = groupPenguinAudioSource.clip.length;
        StartCoroutine(LoopGroupSound());
    }


    IEnumerator LoopGroupSound()
    {
        while(true)
        {
            yield return new WaitForSeconds(loopDelay + Random.Range(5.0f, 8.0f));
            groupPenguinAudioSource.Play();
        }

        yield break;
        
    }
}
