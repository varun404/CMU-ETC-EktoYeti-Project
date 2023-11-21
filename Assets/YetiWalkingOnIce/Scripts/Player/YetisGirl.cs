using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetisGirl : MonoBehaviour
{
    [Tooltip("Let Camera initialize position first and then do height adjustment. First frame camera height is always 1 so multiplier has no effect if applied immediately")]
    [SerializeField]
    float heightAdjustmentStartDelay = 1f;

    [SerializeField]
    float dynamicHeightMultiplier = 20;

    public static YetisGirl yetisGirlInstance;


    static Animator yetisGirlAnimator;
    static AudioSource yetisGirlAudioSource;


    //Delayed start to ensure camera posision is initialized
    IEnumerator Start()
    {
        yield return new WaitForSeconds(heightAdjustmentStartDelay);
        DynamicHeightAdjustment();
        yield break;
    }

    private void Awake()
    {

        if (yetisGirlInstance == null)
            yetisGirlInstance = this;


        yetisGirlAnimator = GetComponent<Animator>();
        yetisGirlAudioSource = GetComponent<AudioSource>();
    }

    public void DoWave(AudioClip clipToPlay)
    {
        yetisGirlAnimator.SetTrigger("Wave");
        yetisGirlAudioSource.clip = clipToPlay;
        yetisGirlAudioSource.Play();
    }


    public void DoJump(AudioClip clipToPlay)
    {
        yetisGirlAnimator.SetTrigger("Jump");
        yetisGirlAudioSource.clip = clipToPlay;
        yetisGirlAudioSource.Play();
    }


    public void DoHug(AudioClip clipToPlay)
    {
        yetisGirlAnimator.SetTrigger("Hug");
        yetisGirlAudioSource.clip = clipToPlay;
        yetisGirlAudioSource.Play();
    }



    public void DoAudioOnly(AudioClip clipToPlay)
    {
        yetisGirlAudioSource.clip = clipToPlay;
        yetisGirlAudioSource.Play();
    }


    static float newHeight;
    void DynamicHeightAdjustment()
    {        
        dynamicHeightMultiplier *= Camera.main.transform.localPosition.y;
        transform.localScale *= dynamicHeightMultiplier;
    }

}
