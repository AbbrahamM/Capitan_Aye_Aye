using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputsManager : MonoBehaviour
{
    public static InputsManager instance;



    private InputSystem inputs;
    private void Awake()
    {
        if (instance == null) {
            instance = this;
            inputs = new();
            TouchSimulation.Enable();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public InputSystem INPUTS
    {
        get { return inputs; }
    }
}
