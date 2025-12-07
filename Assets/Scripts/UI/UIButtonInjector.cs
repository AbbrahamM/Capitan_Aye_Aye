using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class UIButtonInjector : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    ButtonClickedEvent injectEvent;
    [SerializeField]
    bool executeOnEnable = false;
    private void OnEnable()
    {
        if (executeOnEnable)
        {
            Inject(button);
        }   
    }

    public void Inject(Button button)
    {
        button.onClick = injectEvent;
        Debug.Log("Inject " +  button.name);
    }
}
