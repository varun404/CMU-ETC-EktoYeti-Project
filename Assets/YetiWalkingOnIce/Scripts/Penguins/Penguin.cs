using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{

    public PenguinSounds penguinSounds;
    
    [SerializeField]
    AudioSource penguinAudioSource;
    AudioClip clipToPlay;

    Animator penguinAnimator;


    private void Awake()
    {
        penguinAnimator = GetComponentInChildren<Animator>();
    }

    public void StartPenguinAnim()
    {
        StartCoroutine(PenguinAnim());
    }


    IEnumerator PenguinAnim()
    {
        yield return new WaitForSeconds(Random.Range(9f, 13f));
        penguinAnimator.SetTrigger("PenguinAnim");
        yield break;
    }


    public void PenguinLeavesWater()
    {
        clipToPlay = penguinSounds.GetPenguinLeavesWaterSound();
        penguinAudioSource.clip = clipToPlay;
        penguinAudioSource.Play();
    }


    public void PenguinWaterSplash()
    {
        clipToPlay = penguinSounds.GetPenguinWaterSplashSound();
        penguinAudioSource.clip = clipToPlay;
        penguinAudioSource.Play();

    }


    public void PenguinHitYeti()
    {
        clipToPlay = penguinSounds.GetPenguinHitYetiSound();
        penguinAudioSource.clip = clipToPlay;
        penguinAudioSource.Play();
    }


}


[System.Serializable]
public class PenguinSounds
{
    public AudioClip[] penguinLeavesWater;
    public AudioClip[] penguinWaterSplash;
    public AudioClip[] penguinHitYeti;



    public AudioClip GetPenguinLeavesWaterSound()
    {
        return penguinLeavesWater.Length > 1 ? penguinLeavesWater[Random.Range(0, penguinLeavesWater.Length - 1)] : penguinLeavesWater[0];
    }


    public AudioClip GetPenguinWaterSplashSound()
    {
        return penguinWaterSplash.Length > 1 ? penguinWaterSplash[Random.Range(0, penguinWaterSplash.Length - 1)] : penguinWaterSplash[0];
    }


    public AudioClip GetPenguinHitYetiSound()
    {
        return penguinHitYeti.Length > 1 ? penguinHitYeti[Random.Range(0, penguinHitYeti.Length - 1)] : penguinHitYeti[0];
    }
}
