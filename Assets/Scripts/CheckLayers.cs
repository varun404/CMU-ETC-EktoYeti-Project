using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLayers : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            if (!transform.GetChild(i).CompareTag("Melt1"))
            {
                if (transform.GetChild(i).gameObject.layer == 6)
                    continue;

                Debug.Log(transform.GetChild(i).gameObject.name);
                
            }
        }
        
    }


}
