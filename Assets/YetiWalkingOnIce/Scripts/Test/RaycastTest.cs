using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectIfStepOnAnything();
    }

    private bool DetectIfStepOnAnything()
    {
        //int layerMask = 1 << 8;
        //layerMask = ~layerMask;
        RaycastHit hit;
        //Ray ray = new Ray(gameObject.transform.position, gameObject.transform.up * -1.0f);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            Debug.Log("Something below me");
            return true;
        }
        else
        {
            Debug.Log("Nothing below");
            return false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * Mathf.Infinity);
    }
}
