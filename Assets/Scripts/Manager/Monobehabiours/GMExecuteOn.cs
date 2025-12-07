using UnityEngine;
using UnityEngine.Events;

public class GMExecuteOn : MonoBehaviour
{
    [SerializeField]
    UnityEvent executeOnEnable;
    [SerializeField]
    UnityEvent executeOnDisable;

    [SerializeField]
    UnityEvent justExecute;

    private void OnEnable()
    {
        Debug.Log("Enable  " + gameObject.name);
        executeOnEnable?.Invoke();
    }

    private void OnDisable()
    {
        Debug.Log("Disable " + gameObject.name);
        executeOnDisable?.Invoke();
    }

    public void Execure()
    {
        justExecute?.Invoke();
    }
}
