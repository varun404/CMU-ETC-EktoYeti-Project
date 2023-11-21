using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMeltingIce : MonoBehaviour
{
    [SerializeField]
    float meltSpeed = 0.3f;

    bool startMelting = false;
    float dieAfterSeconds = 3.0f;


    float newYPosition = 0.0f;


    Material newIceMat;
        
    float iceTransparency;

    private void Awake()
    {
        newYPosition = transform.position.y;
        newYPosition = transform.InverseTransformPoint(transform.position).y;
        iceTransparency = GetComponent<Renderer>().sharedMaterial.GetFloat("_Alpha");
    }

    private void Update()
    {
        if (!startMelting)
            return;

        newYPosition -=  Time.deltaTime * meltSpeed;
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ActivationArea"))
        {
            StartCoroutine(StartMelting());
        }

    }

    IEnumerator StartMelting()
    {
        newIceMat = new Material(GetComponent<Renderer>().sharedMaterial);
        GetComponent<Renderer>().sharedMaterial = newIceMat;

        startMelting = true;
        GetComponent<AudioSource>().clip = AudioManager.currentAudio.PlayIceMeltingAudio();
        GetComponent<AudioSource>().Play();

        while(iceTransparency >= 0.1)
        {
            iceTransparency -= Time.deltaTime * meltSpeed;
            iceTransparency = Mathf.Clamp01(iceTransparency);
            newIceMat.SetFloat("_Alpha", iceTransparency);
            yield return null;
        }

        yield return new WaitForSeconds(dieAfterSeconds);
        Destroy(gameObject);

        yield break;
    }
}
