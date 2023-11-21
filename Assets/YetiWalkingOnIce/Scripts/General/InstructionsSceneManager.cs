using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstructionsSceneManager : MonoBehaviour
{

    public UnityEvent OnInstructionsSceneBegin;



    // Start is called before the first frame update
    void Start()
    {
        OnInstructionsSceneBegin?.Invoke();
    }

}
