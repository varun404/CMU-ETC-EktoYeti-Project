using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameOverUIManager : MonoBehaviour
{
    private Image image;                // The Image component.
    public List<Sprite> spriteImages;       // A list of images.

    public UnityEvent GameOverSceneInit, OnDoneShowingGameStatus;

    private void Awake()
    {

        image = GetComponent<Image>();

        if (GameOverStatus.GetGameState() == GameOverStatus.GameState.Win)
        {
            image.sprite = spriteImages[0];
        }
        if (GameOverStatus.GetGameState() == GameOverStatus.GameState.Lose)
        {
            image.sprite = spriteImages[1];
        }


        GameOverSceneInit?.Invoke();
        //StartCoroutine(EndGameCredits());

    }
    public void ChangeImage(int index)
    {
        image.sprite = spriteImages[index];         // Let it load a specific image.
    }

    IEnumerator EndGameCredits()
    {
        yield return new WaitForSeconds(5.0f);
        ChangeImage(2);
        yield return DoneShowingGameStatus();
        yield break;
    }


    IEnumerator DoneShowingGameStatus()
    {
        yield return new WaitForSeconds(7f);
        OnDoneShowingGameStatus?.Invoke();

    }
}
