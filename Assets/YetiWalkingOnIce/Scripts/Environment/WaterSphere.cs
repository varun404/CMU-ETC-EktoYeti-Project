using System.Collections;
using UnityEngine;

public class WaterSphere : MonoBehaviour
{
    [SerializeField]
    Material waterSphereMat;

    [SerializeField]
    float fillSpeed = 1.5f;

    float fillValue = 1f;
    
    private void OnEnable()
    {
        waterSphereMat.SetFloat("_FillAmount", 1f);
        StartCoroutine(WaterSphereActivated());
    }

    IEnumerator WaterSphereActivated()
    {
        while(fillValue > 0)
        {
            fillValue -= Time.deltaTime * fillSpeed;
            Debug.Log(fillValue);
            waterSphereMat.SetFloat("_FillAmount", fillValue);
            yield return null;
        }

        yield break;

    }
}
