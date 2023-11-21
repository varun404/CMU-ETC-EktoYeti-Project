using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PPController : MonoBehaviour
{
    [SerializeField]
    Volume ppVolume;
    
    [SerializeField]
    float fillSpeed = 1.5f;

    void OnEnable()
    {
        StartCoroutine(PPActivated());
    }


    IEnumerator PPActivated()
    {

        while (ppVolume.weight < 0.98)
        {
            ppVolume.weight += Time.unscaledDeltaTime * fillSpeed;
            yield return null;
        }

        ppVolume.weight = 1;

        yield break;

    }
}
