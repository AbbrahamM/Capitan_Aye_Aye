using UnityEngine;
using UnityEngine.Events;

public class GMDetectAspectRation : MonoBehaviour
{
    [SerializeField]
    float lessEqualName = 0;
    [SerializeField]
    UnityEvent toDoIfTrue;
    [SerializeField]
    UnityEvent toDoIfFalse;
    private void OnEnable()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float aspectRatio = screenWidth / screenHeight;
        Debug.Log("Screen Width " + (aspectRatio));

        if(aspectRatio <= lessEqualName)
        {
            toDoIfTrue?.Invoke();
        }
        else
        {
            toDoIfFalse?.Invoke();
        }
    }

}
