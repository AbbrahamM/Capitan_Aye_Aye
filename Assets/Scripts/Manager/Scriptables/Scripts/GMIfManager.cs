using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GMIfManager", menuName = "Scriptable Objects/Game Manager/If/GMIfManager")]
public class GMIfManager : ScriptableObject
{
    [SerializeField]
    int staticNumber = 0;
    [SerializeField]
    bool more = false;
    [SerializeField]
    bool equals=false;
    [SerializeField]
    bool less=false;

    [SerializeField]
    UnityEvent ifTrue;
    [SerializeField]
    UnityEvent ifFalse;

    public void If(int number)
    {
        if (more&&!equals)
        {
            if (number > staticNumber)
            {
                ifTrue?.Invoke();
            }
            else
            {
                ifFalse?.Invoke();
            }
        }
        else if (more && equals)
        {
            Debug.Log("I reach the number " + number + " " + name);
            if (number >= staticNumber)
            {
                Debug.Log("I reach the number " + number + " " + name);
                ifTrue?.Invoke();
            }
            else
            {
                ifFalse?.Invoke();
            }
        }
        else if (less && equals) { 
            if(number <= staticNumber)
            {
                ifTrue?.Invoke();
            }
            else
            {
                ifFalse?.Invoke();
            }
        }
        else if (less && !equals)
        {
            if(number < staticNumber)
            {
                ifTrue?.Invoke();
            }
            else
            {
                ifFalse?.Invoke();
            }
        }
    }
   
}
