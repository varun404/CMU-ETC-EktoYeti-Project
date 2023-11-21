using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EKTO_Unity_Plugin;

public class EktoVRManager : EktoEventListener
{
    public Ekto ekto;
    public static EktoVRManager S;

    private void Awake()
    {
        if (S != null && S != this)
        {
            Debug.Log("EKTO REMOVING DUP");
            Destroy(this.gameObject);
        }
        else
        {
            S = this;
            ekto = Ekto.S;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ekto.AddEventListener(this);
    }

    private void Update()
    {
        ekto.CheckForEvents();
    }

    private void OnDestroy()
    {
        ekto.RemoveEventListener(this);
        ekto.Shutdown();
    }

    private void OnApplicationQuit()
    {
        ekto.Shutdown();
    }
}
