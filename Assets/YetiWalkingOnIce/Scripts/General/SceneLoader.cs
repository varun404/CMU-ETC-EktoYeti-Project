using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadSceneByID(int sceneID)
    {
        SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Single);
    }


    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
