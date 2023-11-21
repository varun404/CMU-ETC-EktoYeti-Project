using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public static bool isPlayedDead = false;
    public enum PlayerStatus { Dead, Alive}
    public static PlayerStatus currentPlayerStatus;

    public static event Action Dead = delegate { };

    static IceRoad.IceTypes currentIceUnderPlayer;

    private void Awake()
    {
        //transform.position = playerSpawnPoint.position;
        currentPlayerStatus = PlayerStatus.Alive;
        currentIceUnderPlayer = IceRoad.IceTypes.Unmelting;
    }


    private void Update()
    {        
        Vector3 v = transform.localRotation *  EktoVRManager.S.ekto.GetSystemUserVelocity();        
        //Debug.Log("Speed = " + Mathf.Abs(v.magnitude));
        transform.localPosition += v * Time.deltaTime;
        Vector3 offset = new Vector3(transform.localPosition.x, -EktoVRManager.S.ekto.GetBootToFloorOffset(), transform.localPosition.z);
        transform.localPosition = offset;
    }


    public static void SetIceUnderPlayer(IceRoad.IceTypes ice)
    {
        currentIceUnderPlayer = ice;
    }

    public static void PlayerDead()
    {        
        currentPlayerStatus = PlayerStatus.Dead;        
        GameOverStatus.SetGameState(GameOverStatus.GameState.Lose);
        Debug.Log("I'M DEAD");

        Dead?.Invoke();        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawLine(Camera.main.transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 10f, Camera.main.transform.position.z));
        Gizmos.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Vector3.up * -4f);
           
    }


}
