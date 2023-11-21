using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager currentAudio;

    [Header("BACKGROUND MUSIC")]
    public AudioClip backgroundMusic;
    public AudioClip endingBackgroundMusic;


    [Header("ICE SOUNDS")]
    public AudioClip[] meltingClip;
    
    [Header("STEP ON ICE SOUNDS")]
    public AudioClip stepOnCrack;
    public AudioClip stepOnMelting1;
    public AudioClip stepOnUnmelting;


    AudioSource musicSource;


    private void Awake()
    {
        currentAudio = this;
        
        musicSource = currentAudio.gameObject.AddComponent<AudioSource>();
        //StartGameBackgroundMusic();
    }

    //public static void StartGameBackgroundMusic()
    //{
    //    currentAudio.musicSource.clip = currentAudio.backgroundMusic;
    //    currentAudio.musicSource.loop = true;
    //    currentAudio.musicSource.Play();
    //}
    public static void StartEndingMusic()
    {
        currentAudio.musicSource.clip = currentAudio.endingBackgroundMusic;
        currentAudio.musicSource.loop = true;
        currentAudio.musicSource.Play();
    }

    //ice related sounds that use ice source

    public AudioClip PlayIceMeltingAudio()
    {
        int index = Random.Range(0, currentAudio.meltingClip.Length);
        return currentAudio.meltingClip[index];
    }

    public AudioClip GetStepOnUnmeltingClip()
    {
        return currentAudio.stepOnUnmelting;
    }

    public AudioClip GetStepOnMelting1Clip()
    {
        return currentAudio.stepOnMelting1;
    }

    public AudioClip GetStepOnCrackedClip()
    {
        return currentAudio.stepOnCrack;
    }
}
