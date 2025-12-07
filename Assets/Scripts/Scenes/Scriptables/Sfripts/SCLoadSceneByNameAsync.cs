using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SCLoadAsyncSceneByNameAsync", menuName = "Scriptable Objects/Scenes/Load/Async Load Scene")]
public class SCLoadSceneByNameAsync : ScriptableObject
{
    public void LoadAsyncSceneByName(string sceneName)
    {
        ScenesManager.Instance.StartCoroutine(AsyncLoader(sceneName));
    }


    IEnumerator AsyncLoader(string sceneName)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);

        while (loadScene != null && loadScene.isDone) { 
            yield return loadScene;
        }
    }
}
