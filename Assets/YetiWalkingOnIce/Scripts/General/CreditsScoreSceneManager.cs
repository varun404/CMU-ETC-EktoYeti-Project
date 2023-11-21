using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScoreSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }


    void ActivateEktoSystem()
    {
        if (!EktoVRManager.S.ekto.IsSystemActivated())
            EktoVRManager.S.ekto.StartSystem();
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(0.5f);

        ActivateEktoSystem();

        yield return new WaitForSeconds(4.5f);
        FindObjectOfType<SceneLoader>().LoadSceneByID(1);
        yield break;
    }
}
