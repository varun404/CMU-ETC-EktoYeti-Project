using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject PPVolume;
    public Animator blackImageAnimator;     // The animator of the black screen image.

    public UnityEvent OnGameBegin, OnGameOver;



    private void Awake()
    {
        OnGameBegin?.Invoke();
    }
    private void Update()
    {
        //if (!EktoVRManager.S.ekto.IsServerConnected() || !EktoVRManager.S.ekto.IsSystemActivated())
        //{
        //    //Pause game
        //    Time.timeScale = 0;
        //}
        //else
        //    Time.timeScale = 1;
    }

    private void OnEnable()
    {
        PlayerController.Dead += ActivateWaterSphere;
        GameOverStatus.GameOverAction += GameOver;

    }

    private void OnDisable()
    {
        PlayerController.Dead -= ActivateWaterSphere;
        GameOverStatus.GameOverAction -= GameOver;
    }


    void ActivateWaterSphere()
    {
        PPVolume.SetActive(true);
    }


    void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }


    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(3.5f);

        OnGameOver?.Invoke();
    }
}
