using UnityEngine;

public class LosingReasonCanvasText : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text losingReasonText;

    // Start is called before the first frame update
    void Start()
    {
        switch (GameOverStatus.reasonForLosingGame)
        {
            case GameOverStatus.LosingReason.Penguin:
                losingReasonText.text = "You were hit by a Penguin!";
                break;

            case GameOverStatus.LosingReason.WalkOffPath:
                losingReasonText.text = "Oof, you walked off the path";
                break;
            
        }
    }
}
