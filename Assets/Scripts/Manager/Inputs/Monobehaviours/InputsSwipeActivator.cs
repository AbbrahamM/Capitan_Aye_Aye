using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputsSwipeActivator : MonoBehaviour
{
    [SerializeField]
    bool activateOnEnable = true;

    [SerializeField]
    bool diactivateOnDisable = true;

    private void OnEnable()
    {
        if(activateOnEnable)
            InputsManager.instance.INPUTS.Touch.Swipe.Enable();
    }

    public void Activate()
    {
        InputsManager.instance.INPUTS.Touch.Swipe.Enable();
    }

    public void Diactivate()
    {
        InputsManager.instance.INPUTS.Touch.Swipe.Disable();
    }

    private void OnDisable()
    {
        if(diactivateOnDisable)
            InputsManager.instance.INPUTS.Touch.Swipe.Disable();
    }
}
