using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputsTouchSuscriberPerform : MonoBehaviour
{
    [SerializeField]
    UnityEvent<InputAction.CallbackContext> execute;


    private void OnEnable()
    {
        InputsManager.instance.INPUTS.Touch.Touch.performed += Execute;
    }

    private void Execute(InputAction.CallbackContext callbackContext)
    {
        execute?.Invoke(callbackContext);
    }

    private void OnDisable()
    {
        InputsManager.instance.INPUTS.Touch.Touch.performed -= Execute;
    }
}
