using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class LanguageSelector : MonoBehaviour
{
    [HideInInspector]
    public string fieldName;
    public int arrayIndex; // index to pick if the field is an array
    public TMP_Text target;

    [SerializeField]
    bool executeOnStart = true;

    [SerializeField]
    UnityEvent<string> passText;

    void Start()
    {
        if(executeOnStart) 
            target.text = GetText(fieldName,arrayIndex);
    }

    public string GetText(string fieldName, int index = -1)
    {
        var field = typeof(Language).GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
        var value = field?.GetValue(LanguageManager.instance.LANGUAGEDATA);
        if (value == null) return "<Missing>";

        if (value is string str) return str;

        if (value is string[] arr)
        {
            if (index >= 0 && index < arr.Length) return arr[index];
            else return $"<Index {index} out of range>";
        }

        return $"<Unsupported type {field.FieldType}>";
    }

    private void GetAllTextsFromArray(string fieldName)
    {
        var field = typeof(Language).GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
        var value = field?.GetValue(LanguageManager.instance.LANGUAGEDATA);
        if (value is string[] arr)
        {
            foreach (var item in arr)
            {
                passText?.Invoke(item);
            }
        }
    }

    public void GetAllTextsArray()
    {
        GetAllTextsFromArray(fieldName);
    }

    public void SetText()
    {
        target.text = GetText(fieldName, arrayIndex);
    }

    public void AddText()
    {
        target.text += GetText(fieldName, arrayIndex);
    }

    public void PassText()
    {
        passText?.Invoke(GetText(fieldName, arrayIndex));
    }
}
