using UnityEngine;
using UnityEngine.Events;

public class GMIfString : MonoBehaviour
{
    [SerializeField]
    UnityEvent<string> todoIfStringTrue;
    [SerializeField]
    UnityEvent<string> todoIfStringFalse;
    [SerializeField]
    string stringToTest;
    bool found = false;


    public void ExecuteFalse()
    {
        todoIfStringFalse?.Invoke(stringToTest);
    }

    public void IfStringFor(string str)
    {
        if (found)
            return;

        if(str == stringToTest)
        {
            found = true;

            Debug.Log("String Test " + str + " " + stringToTest);
            todoIfStringTrue?.Invoke(str);
        }
        else
        {
            todoIfStringFalse?.Invoke(str);
        }
    }
}
