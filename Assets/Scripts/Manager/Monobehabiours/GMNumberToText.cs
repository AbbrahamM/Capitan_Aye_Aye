using TMPro;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent (typeof(TextMeshProUGUI))]
public class GMNumberToText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI TextMeshProUGUI;
    [SerializeField]
    string beforeText = string.Empty;
    [SerializeField]
    string afterText = string.Empty;

    [HideInInspector]
    public string dynamicText;
    [SerializeField]
    UnityEvent toDoAfter;
    private void Awake()
    {
        if(TextMeshProUGUI != null) 
            TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    public void IntToText(int value)
    {
        Debug.Log("Is it? " + gameObject.name);
        TextMeshProUGUI.text = beforeText + value.ToString("0") + afterText;
        toDoAfter?.Invoke();

    }

    public void FloatToText(float value)
    {
        TextMeshProUGUI.text = beforeText + value.ToString("0") +afterText;
        toDoAfter?.Invoke();
    }

    public void IntToTextFormula(int value)
    {
        object[] args = { value };

        Debug.Log("Arg " + value);
        TextMeshProUGUI.text = string.Format(dynamicText, args);
    }

    public string DYNAMICTEXT
    {
        set { dynamicText = value; }
    }
}
