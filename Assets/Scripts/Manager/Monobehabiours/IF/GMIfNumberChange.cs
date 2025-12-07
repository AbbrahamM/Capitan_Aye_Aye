using UnityEngine;
using UnityEngine.Events;

public class GMIfNumberChange : MonoBehaviour
{
    [SerializeField]
    UnityEvent ifFalse;
    [SerializeField]
    UnityEvent ifTrue;

    int currentNumber = 0;

    public void IfNumberIncreases(int lastNumber)
    {
        if (lastNumber > currentNumber)
        {
            Debug.Log("Number Increases " + lastNumber + " " + currentNumber);
            ifTrue?.Invoke();
        }
        else
        {
            ifFalse?.Invoke();
        }

        currentNumber = lastNumber;
    }
}
