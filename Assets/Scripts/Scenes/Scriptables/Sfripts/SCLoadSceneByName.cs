using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Simple Load Scene", menuName = "Scriptable Objects/Scenes/Load/Simple Load Scene")]
public class SCLoadSceneByName : ScriptableObject
{
    public void SimpleLoadSceneByName(string name)
    {
        Debug.Log("Load Simple Scene " + name);
        SceneManager.LoadScene(name,LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
