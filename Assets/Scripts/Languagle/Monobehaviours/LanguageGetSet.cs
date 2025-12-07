using System;
using UnityEngine;
using UnityEngine.Events;
using static LanguageManager;

public class LanguageGetSet : MonoBehaviour
{
    [SerializeField]
    UnityEvent<int> getCurrentLanguage;
    public void GetCurrentLanuage()
    {
        getCurrentLanguage?.Invoke((int)LanguageManager.instance.CURRENTLANGUAGE);
    }

    public void ChangeCurrentLanguage(int language)
    {
        Debug.Log("New Language " + (Languages)Enum.ToObject(typeof(Languages), language));
        LanguageManager.instance.CURRENTLANGUAGE = (Languages)Enum.ToObject(typeof(Languages), language);
        getCurrentLanguage?.Invoke(language);
    }
}
