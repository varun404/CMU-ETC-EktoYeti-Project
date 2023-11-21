using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


// Used for showing the images.
public class UIImageController : MonoBehaviour
{
    //private Image image;                // The Image component.

    //public UnityEvent GameOverSceneInit, OnDoneShowingGameStatus;

    //// Start is called before the first frame update
    //void Start()
    //{

    //    image = GetComponent<Image>();

    //    if(image == null)
    //    {
    //        Debug.LogError("Cannot load image UI");
    //    }
    //    if (GameOverStatus.GetGameState() == GameOverStatus.GameState.Win)
    //    {
    //        GameOverSceneInit?.Invoke();
    //        StartCoroutine(EndGameCredits());
    //    }
    //    if (GameOverStatus.GetGameState() == GameOverStatus.GameState.Lose)
    //    {
    //        image.sprite = spriteImages[1];
    //        GameOverSceneInit?.Invoke();
    //        StartCoroutine(EndGameCredits());
    //    }
    //}

    
   
    ////Start storyboard
    //public void OpeningImage()
    //{
    //    image.sprite = spriteImages[3];
    //    StartCoroutine(OpeningGameImage());
    //}

    //IEnumerator OpeningGameImage()
    //{
    //    yield return new WaitForSeconds(5.0f);
    //    ChangeImage(4);
    //    yield return new WaitForSeconds(6.0f);
    //    ToggleImage();
    //    yield break;
    //}



}
