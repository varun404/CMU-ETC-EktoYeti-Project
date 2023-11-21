using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class WalkOnIceController : MonoBehaviour
{    

    [SerializeField]
    BootPointRaycastCheck[] leftBootPoints, rightBootPoints;

    bool left, right;


    RaycastHit hit;

    float currentTime;
    
    // Update is called once per frame
    void Update()
    {        
        if (!(currentTime > 1.0f))
        {
            currentTime += Time.deltaTime;
            return;
        }

        if (!DetectIfStepOnAnything())
        {
            Debug.Log("OOF, I WALKED OFF THE PATH");
            
            if (PlayerController.isPlayedDead)
                return;

            PlayerController.isPlayedDead = true;
            GameOverStatus.SetLosingReason(GameOverStatus.LosingReason.WalkOffPath);
            PlayerController.PlayerDead();
        }
    }

    int leftPointsCount, rightPointsCount;
    private bool DetectIfStepOnAnything()
    {
        leftPointsCount = 0;
        rightPointsCount = 0;

        for (int i = 0; i < leftBootPoints.Length; i++)
        {
            if (leftBootPoints[i].isPointValid)
                leftPointsCount++;
        }

        for (int i = 0; i < rightBootPoints.Length; i++)
        {
            if (rightBootPoints[i].isPointValid)
                rightPointsCount++;
        }

        left = leftPointsCount > 0 ? true : false;
        right = rightPointsCount > 0 ? true : false;



        //if (Physics.Raycast(playerHeadTransform.position, playerHeadTransform.position + Vector3.up * -10f, out hit, Mathf.Infinity, roadLayer))
        //{
        //    head = true;
        //    Debug.Log("Head : " + hit.collider.gameObject.name);
        //}
        //else 
        //{ 
        //    head = false;  
        //    Debug.Log("Head : None"); 
        //}


        //Debug.Log("Head : " + head + " ... " + "Right : " + right + " ... " + "Left : " + left);

        //All safe
        //if (!left && !right && !head)
        //    return false;        

        Debug.Log(left + " LEFT ... " + right + " RIGHT");

        if (!left && !right)
            return false;


        return true;


        ////Stepping over ice blocks
        //if (!head && (right && left))
        //    return true;


        ////WTF
        //if (!left && !right)
        //    return false;
        
        //Vector2 distanceLeft = playerHeadTransform.position - leftBootTransform.position;
        //Vector2 distanceRight = playerHeadTransform.position - rightBootTransform.position;

        //if ((distanceRight.magnitude * distanceRight.magnitude) < (distanceLeft.magnitude * distanceLeft.magnitude))
        //{
        //    if (right && head)
        //        return true;
        //    else
        //        return false;
        //}
        //else if ((distanceRight.magnitude * distanceRight.magnitude) > (distanceLeft.magnitude * distanceLeft.magnitude))
        //{

        //    if (left && head)
        //        return true;
        //    else
        //        return false;

        //}

        //return false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawLine(Camera.main.transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 10f, Camera.main.transform.position.z));
        foreach (var item in leftBootPoints)
        {
            Gizmos.DrawLine(item.transform.position, item.transform.position + Vector3.up * -4f);

        }

        foreach (var item in rightBootPoints)
        {
            Gizmos.DrawLine(item.transform.position, item.transform.position + Vector3.up * -4f);

        }
               

    }


}
