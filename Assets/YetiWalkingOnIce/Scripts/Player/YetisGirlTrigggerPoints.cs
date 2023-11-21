using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetisGirlTrigggerPoints : MonoBehaviour
{
    public bool doHug, doWave, winBlock, audioOnly;
    public AudioClip clipForThisTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (doWave)
            {
                YetisGirl.yetisGirlInstance.DoWave(clipForThisTrigger);
                return;
            }

            if(winBlock)
            {
                GameOverStatus.SetGameState(GameOverStatus.GameState.Win);
                return;
            }

            if(doHug)
            {
                YetisGirl.yetisGirlInstance.DoHug(clipForThisTrigger);
                return;
            }
        }
    }
}
