using UnityEngine;
using UnityEngine.Events;

public class UIIf : MonoBehaviour
{
    [SerializeField]
    UnityEvent toDoIfTrue;
    [SerializeField]
    UnityEvent toDoIfFalse;

    bool flag = false;

    public void Excute()
    {
        if (flag)
        {
            toDoIfTrue?.Invoke();
        }
        else
        {
            toDoIfFalse?.Invoke();
        }
    }

    public bool FLAG
    {
        set { flag = value; }
    }
}
