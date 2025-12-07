using UnityEngine;

[CreateAssetMenu(fileName = "Set Time Scale", menuName = "Scriptable Objects/Game Manager/Set Time Scale")]
public class GMAetTimeScale : ScriptableObject
{
    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
