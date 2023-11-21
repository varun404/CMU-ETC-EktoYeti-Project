using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootPointRaycastCheck : MonoBehaviour
{

    public bool isPointValid;


    RaycastHit hitInfo;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, Mathf.Infinity, 1 << 3))
        {
            Debug.Log(hitInfo.collider.gameObject.name);
            isPointValid = true;
        }
        else
            isPointValid = false;
    }
}
