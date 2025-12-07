using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputsSwipeSuscriberPerform : MonoBehaviour
{
    [SerializeField]
    UnityEvent<InputAction.CallbackContext> execute;


    private void OnEnable()
    {
        InputsManager.instance.INPUTS.Touch.Swipe.performed += Execute;
    }

    private void Execute(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Delta " + callbackContext.ReadValue<Vector2>());
        execute?.Invoke(callbackContext);    
    }

    private void OnDisable()
    {
        InputsManager.instance.INPUTS.Touch.Swipe.performed -= Execute;
    }
}
