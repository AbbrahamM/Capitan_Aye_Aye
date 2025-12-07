using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class UISwipe : MonoBehaviour
{
    [SerializeField]
    UnityEvent toDoVerticalUp;

    [SerializeField]
    UnityEvent toDoVerticalDown;
    [SerializeField]
    UnityEvent toDoHorizontalLeft;
    [SerializeField]
    UnityEvent toDoHorizontalRight;
    [SerializeField]
    bool onlyOnce = false;  

    bool executed = false;

    [SerializeField]
    float numRef = 0;
    public void SWiape(InputAction.CallbackContext context)
    {
        if (onlyOnce && executed)
            return;
        Debug.Log("Directio of execution " + context.ReadValue<Vector2>() + " " + numRef);
        if (context.ReadValue<Vector2>().x > numRef)
        {
            Debug.Log("How many times i enter here " + gameObject.name);
            executed = true;
            toDoHorizontalRight?.Invoke();
        } else if(context.ReadValue<Vector2>().x < numRef)
        {
            executed = true;
            toDoHorizontalLeft?.Invoke();
        }

        if (context.ReadValue<Vector2>().y > numRef)
        {
            executed = true;
            toDoVerticalUp?.Invoke();
        }
        else if (context.ReadValue<Vector2>().y < numRef)
        {
            executed = true;
            toDoVerticalDown?.Invoke();
        }
    }

    public bool Executed
    {
        set { executed = value; }
    }
}
