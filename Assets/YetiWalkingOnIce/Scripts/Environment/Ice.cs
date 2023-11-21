using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public bool meltOnAreaTrigger;
    private bool isMelting = false;
    private PlayerController player;
    private bool playerOnThisIce = false;



    IceRoad.IceTypes iceType;

    private void Awake()
    {
        SetIceType();
    }


    public void StartIceBehaviour()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnThisIce = true;
            PlayerController.SetIceUnderPlayer(iceType);
            Debug.Log("I'm entered melting ice");                             //detect when the player walks on it
        }

        if (other.gameObject.CompareTag("ActivationArea"))
        {
            if (meltOnAreaTrigger)
                StartMelting();
        }
    }


    public void StartMelting()
    {
        isMelting = true;                //called by player's WalkOnIceController. set the melting status
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
