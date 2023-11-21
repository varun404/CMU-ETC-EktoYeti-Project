using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanLight : MonoBehaviour
{
    [SerializeField]
    Material Ocean;

    public bool initiation = true;
    public bool decrease = false;
    public float oceanLightStrength = 10.0f;
    public float upperBound = 8.0f;
    public float lowerBound = 1.0f;
    public float changeRate = 0.001f;
    

    // Start is called before the first frame update
    void Start()
    {
        Ocean.SetFloat("_RippleSlimness", oceanLightStrength);
    }

    // Update is called once per frame
    void Update()
    {
        if (initiation)
        {
            oceanLightStrength -= changeRate;
            Ocean.SetFloat("_RippleSlimness", oceanLightStrength);
            if (oceanLightStrength <= lowerBound)
            {
                initiation = false;
            }
        }
        else
        {
            if (!decrease)
            {
                oceanLightStrength += changeRate;
                Ocean.SetFloat("_RippleSlimness", oceanLightStrength);
                if (oceanLightStrength >= upperBound)
                {
                    decrease = true;
                }
            }
            else
            {
                oceanLightStrength -= changeRate;
                Ocean.SetFloat("_RippleSlimness", oceanLightStrength);
                if (oceanLightStrength <= lowerBound)
                {
                    decrease = false;
                }
            }
        }
        
    }
}
