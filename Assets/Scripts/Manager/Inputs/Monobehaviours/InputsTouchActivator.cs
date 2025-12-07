using UnityEngine;

public class InputsTouchActivator : MonoBehaviour
{
    [SerializeField]
    bool activateOnEnable = true;

    [SerializeField]
    bool diactivateOnDisable = true;

    private void OnEnable()
    {
        if (activateOnEnable)
            InputsManager.instance.INPUTS.Touch.Touch.Enable();
    }

    public void Activate()
    {
        InputsManager.instance.INPUTS.Touch.Touch.Enable();
    }

    public void Diactivate()
    {
        InputsManager.instance.INPUTS.Touch.Touch.Disable();
    }

    private void OnDisable()
    {
        if (diactivateOnDisable)
            InputsManager.instance.INPUTS.Touch.Touch.Disable();
    }
}
