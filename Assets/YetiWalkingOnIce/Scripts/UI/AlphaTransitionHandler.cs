using System;
using System.Collections;
using UnityEngine;

public class AlphaTransitionHandler : MonoBehaviour
{

    static CanvasGroup targetCanvasGroup;


    [Range(1f, 3f), SerializeField]
    float transparencySpeed = 2.0f;


    bool coroutineRunning = false;
    


    public void MakeTransparent(CanvasGroup canvasGroup)
    {
        targetCanvasGroup = canvasGroup;
        targetCanvasGroup.alpha = 1;

        StartCoroutine(MakeTransparentCoroutine());

    }

    public void MakeOpaque(CanvasGroup canvasGroup)
    {
        targetCanvasGroup = canvasGroup;
        targetCanvasGroup.alpha = 0;

        StartCoroutine(AlphaHandlerCoroutine(false));

        Debug.Log("got out");
        
    }




    IEnumerator AlphaHandlerCoroutine(bool alphaStatus)
    {
        switch (alphaStatus)
        {
            //Transparent
            case true:
                while(coroutineRunning)
                    yield return MakeTransparentCoroutine();                
                break;

            //Opaque
            case false:
                yield return MakeOpaqueCoroutine();
                break;

        }   

        
    }


    IEnumerator MakeTransparentCoroutine()
    {
        coroutineRunning = true;

        while (targetCanvasGroup.alpha >= 0.01)
        {
            targetCanvasGroup.alpha -= (Time.deltaTime * transparencySpeed);                        
        }

        targetCanvasGroup.alpha = 0.0f;

        coroutineRunning = false;

        
        yield break;

    }


    IEnumerator MakeOpaqueCoroutine()
    {
        coroutineRunning = true;


        while (targetCanvasGroup.alpha < 0.98)
        {
            targetCanvasGroup.alpha += (Time.deltaTime * transparencySpeed);
            
            yield return null;
        }

        targetCanvasGroup.alpha = 1;

        Debug.Log("Coroutine end");

        coroutineRunning = false;


        yield break;


    }

    IEnumerator AddDelay(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
    }

    public void WaitForSeconds(float seconds)
    {
        StartCoroutine(AddDelay(seconds));

    }





}
