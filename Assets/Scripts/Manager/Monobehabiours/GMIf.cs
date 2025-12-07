using UnityEngine;
using UnityEngine.Events;

public class GMIf : MonoBehaviour
{
    [SerializeField]
    UnityEvent toDoIfTrue;
    [SerializeField]
    UnityEvent toDoIfFalse;
    [SerializeField]
    bool flag = false;

    public void Excute()
    {
        
        if (flag)
        {
            toDoIfTrue?.Invoke();
        }
        else
        {
            Debug.Log("Enable  " + gameObject.name);
            toDoIfFalse?.Invoke();
        }
    }

    public bool FLAG
    {
        set { flag = value; Debug.Log("Set Value " + gameObject.name + " " + value); }
    }
}
