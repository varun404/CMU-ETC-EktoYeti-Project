using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeltController : MonoBehaviour
{
    public bool meltOnAreaTrigger;

    public float canStayOnBeforeMelting = 8f;

    private bool isMelting = false;
    private bool playerOnThisIce= false;
    IceRoad.IceTypes iceType;

    public UnityEvent OnStepOnMeltingIce;
    AudioClip clipToPlay;

    Material newIceMat;

    private void Awake()
    {
        SetIceType();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMelting)
        {
            transform.position -= new Vector3(0, 0.005f, 0);
        }
    }

    public void StartMelting()
    {
        isMelting = true;
        if (GetComponent<AudioSource>() != null)
        {
            //If this block can melt on its own then play audio
            clipToPlay = AudioManager.currentAudio.PlayIceMeltingAudio();
            GetComponent<AudioSource>().clip = clipToPlay;
            GetComponent<AudioSource>().Play();//called by player's WalkOnIceController. set the melting status

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            playerOnThisIce = true;
            newIceMat = new Material(GetComponent<Renderer>().sharedMaterial);
            GetComponent<Renderer>().sharedMaterial = newIceMat;
            newIceMat.SetFloat("_RefractStrength", 0.03f);

            PlayerController.SetIceUnderPlayer(iceType);
            StartCoroutine(PlayerOnIceCountDown());
            //Debug.Log("I'm entered melting ice");                             //detect when the player walks on it
        }

        if(other.gameObject.CompareTag("ActivationArea"))
        {
            if (meltOnAreaTrigger)
                StartCoroutine(IceMeltBehaviour()); 
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnThisIce = false;

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnThisIce = true;
            Debug.Log("I'm staying on melting ice");                             //detect when the player walks on it

        }
    }

    IEnumerator PlayerOnIceCountDown()
    {
        if (iceType == IceRoad.IceTypes.Unmelting)
            yield break;


        newIceMat.SetFloat("_CrackStrength", 2.0f);
        yield return new WaitForSeconds(canStayOnBeforeMelting / 3.0f);
        newIceMat.SetFloat("_CrackStrength", 4.0f);
        yield return new WaitForSeconds(canStayOnBeforeMelting / 3.0f);
        newIceMat.SetFloat("_CrackStrength", 8.5f);
        yield return new WaitForSeconds(canStayOnBeforeMelting / 3.0f);


        StartMelting();

        yield return new WaitForSeconds(3f);

        if (playerOnThisIce)
        {
            GameObject.FindGameObjectWithTag("Finish").SetActive(false);
            Debug.Log("OOF, I STOOD ON MELTING ICE");

            if (!PlayerController.isPlayedDead)
            {
                PlayerController.isPlayedDead = true;
                GameOverStatus.SetLosingReason(GameOverStatus.LosingReason.WalkOffPath);
                PlayerController.PlayerDead();             //if the player is still on it when it sinks then player dies
            }

        }

        Destroy(gameObject);
        yield break;
    }


    IEnumerator IceMeltBehaviour()
    {


        StartMelting();
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
        yield break;

    }

    void SetIceType()
    {

        switch (gameObject.tag)
        {
            case "Melt1":
                iceType = IceRoad.IceTypes.Melting1;
                break;
            case "Melt2":
                iceType = IceRoad.IceTypes.Melting2;
                break;
            case "Crack":
                iceType = IceRoad.IceTypes.Cracked;
                break;
            case "Unmelting":
                iceType = IceRoad.IceTypes.Unmelting;
                break;
        }
    }
}
