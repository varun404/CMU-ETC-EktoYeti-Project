using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CrackController : MonoBehaviour
{
    [Range(0.0f, 2.7f)]
    float damagedAmount = 0.0f;

    public float canStayOnBeforeCracking = 8f;

    private bool playerOnThisIce = false;
    IceRoad.IceTypes iceType;

    public UnityEvent OnStepOnCrackingIce;

    AudioClip clipToPlay;
    Material newIceMat;

    bool newMaterialCreated;

    private void Awake()
    {
        SetIceType();        
    }

    public void DamageCrackIce(float damageAmount)
    {
        if(damageAmount >= 2.7f)
        {
            Destroy(gameObject);
            return;
        }

        if(damagedAmount + damageAmount >= 2.7f)
        {
            Destroy(gameObject);
            return;
        }

        damagedAmount += damageAmount;

        if(newMaterialCreated)
        {
            newIceMat.SetFloat("_CrackStrength", damagedAmount);
        }
        else
        {
            newIceMat = new Material(GetComponent<Renderer>().sharedMaterial);
            GetComponent<Renderer>().sharedMaterial = newIceMat;
            newIceMat.SetFloat("_CrackStrength", damagedAmount);
            newMaterialCreated = true;
        }
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
