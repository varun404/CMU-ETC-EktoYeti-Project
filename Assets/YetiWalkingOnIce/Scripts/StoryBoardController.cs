using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StoryBoardController : MonoBehaviour
{
    private Image image;                // The Image component.
    public List<Sprite> spriteImages;       // A list of images.

    public GameObject iceBlocksForVisual;

    public UnityEvent OnStoryBoardDone;


    private void Start()
    {
        StartStoryBoard();
    }

    public void ToggleImage()           // Toggle the image visible/invisible.
    {
        if (image.color.a == 0)
        {
            image.color = new Color(image.color.r, image.color.b, image.color.b, 255);
            return;
        }
        image.color = new Color(image.color.r, image.color.b, image.color.b, 0);        // Change the alpha value of the image.

        OnStoryBoardDone?.Invoke();
    }


    public void ChangeImage(int index)
    {
        image.sprite = spriteImages[index];         // Let it load a specific image.
    }


    public void StartStoryBoard()
    {        
        StartCoroutine(StartStoryBoardCoroutine());
    }

    IEnumerator StartStoryBoardCoroutine()
    {
        image = GetComponent<Image>();

        image.sprite = spriteImages[0];
        yield return new WaitForSeconds(8.0f);


        image.sprite = spriteImages[1];
        iceBlocksForVisual.SetActive(true);
        yield return new WaitForSeconds(8.0f);
        iceBlocksForVisual.SetActive(false);

        image.sprite = spriteImages[2];
        yield return new WaitForSeconds(9.0f);

        ToggleImage();

        yield break;
    }
}
