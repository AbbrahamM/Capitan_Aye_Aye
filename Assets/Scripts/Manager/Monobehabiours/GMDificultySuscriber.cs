using UnityEngine;
using UnityEngine.Events;

public class GMDificultySuscriber : MonoBehaviour
{
    [SerializeField]
    UnityEvent increaseDificulty;

    private void Start()
    {
        GMBackgroundSpeedDificultyManager.increaseDificulty += IncreaseDifitulty;
    }

    private void OnEnable()
    {
        
    }


    private void IncreaseDifitulty()
    {
        increaseDificulty?.Invoke();
    }

    private void OnDisable()
    {
        
    }

    private void OnDestroy()
    {
        GMBackgroundSpeedDificultyManager.increaseDificulty -= IncreaseDifitulty;
    }
}
