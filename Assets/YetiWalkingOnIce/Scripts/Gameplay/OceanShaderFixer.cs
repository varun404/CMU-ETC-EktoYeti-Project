using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanShaderFixer : MonoBehaviour
{

    [SerializeField]
    Material oceanMat;

    float value = 100;

    private void Awake()
    {
        
    }

    private void Update()
    {
        oceanMat.SetFloat("_FoamScale", value);
        value += 0.01f;
    }

}
