using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoots : MonoBehaviour
{


    bool bootStay = false;


    AudioClip clipToPlay;

    public EKTO_Unity_Plugin.Handedness playerFoot;

    public float footImpactVelocityTriggerEnter { get; private set; }
    public float footImpactVelocityTriggerStay { get; private set; }


    //Just stepped on crack ice
    private void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Crack":
                //Debug.Log("On Crack");
                Debug.LogError(EktoVRManager.S.ekto.GetBootVelocity(playerFoot).magnitude);
                clipToPlay = AudioManager.currentAudio.GetStepOnCrackedClip();
                footImpactVelocityTriggerEnter = EktoVRManager.S.ekto.GetBootVelocity(playerFoot).magnitude;
                
                //Soft step
                if(footImpactVelocityTriggerEnter <= 0.3f)
                {
                    other.GetComponent<CrackController>().DamageCrackIce(0.3f);
                    break;
                }

                if(footImpactVelocityTriggerEnter > 0.3f && footImpactVelocityTriggerEnter <= 0.42)
                {
                    other.GetComponent<CrackController>().DamageCrackIce(0.5f);
                    break;
                }

                if(footImpactVelocityTriggerEnter > 0.42)
                {
                    other.GetComponent<CrackController>().DamageCrackIce(0.8f);
                    break;
                }

                break;
            case "Unmelting":
                clipToPlay = AudioManager.currentAudio.GetStepOnUnmeltingClip();
                //Debug.Log(playerFoot.ToString() + " " + EktoVRManager.S.ekto.GetBootVelocity(playerFoot).magnitude);
                break;            
        }

        GetComponent<AudioSource>().clip = clipToPlay;
        GetComponent<AudioSource>().Play();

    }


    bool coroutineRunning = false;
    //Foot stay on the crack ice
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Crack"))
        {
            bootStay = true;

            if (!coroutineRunning)
            {
                coroutineRunning = true;
                StartCoroutine(BootStay(other));
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crack"))
            bootStay = false;

    }


    IEnumerator BootStay(Collider other)
    {
        while(bootStay)
        {
            yield return new WaitForSeconds(0.6f);
            other.GetComponent<CrackController>().DamageCrackIce(0.3f);
        }
        
        coroutineRunning = false;
        yield break;
    }
}
