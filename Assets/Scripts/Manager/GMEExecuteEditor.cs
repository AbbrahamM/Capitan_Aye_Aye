using UnityEngine;
using UnityEngine.Events;
[ExecuteInEditMode]
public class GMEExecuteEditor : MonoBehaviour
{
    [SerializeField]
    UnityEvent executeOnEnable;
    private void OnEnable()
    {
        executeOnEnable?.Invoke();
    }
}
