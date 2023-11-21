using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EKTO_Unity_Plugin;

public class QuitGame : MonoBehaviour
{

    [SerializeField]
    float waitForSecondsBeforeQuittingGame = 10f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Ekto.S.StopSystem();
        yield return new WaitForSeconds(waitForSecondsBeforeQuittingGame);
        Application.Quit();
        yield break;
    }


}
