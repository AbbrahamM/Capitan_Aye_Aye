using System;
using UnityEngine;
using UnityEngine.Events;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager instance;

    [SerializeField]
    Languages currentLanguage = Languages.ES;
    Language currentLanguageClass = null;
    [SerializeField]
    UnityEvent<int> toDoWhenChangeLanguage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {

        LoadLanguageData();
    }

    public Language LANGUAGEDATA
    {
        get { return currentLanguageClass; }
    }

    public Languages CURRENTLANGUAGE
    {
        get { return currentLanguage; }
        set { currentLanguage = value; 
            LoadLanguageData();
            toDoWhenChangeLanguage?.Invoke((int)currentLanguage);
        }
    }

    public enum Languages
    {
        EN,
        ES
    }

    private void LoadLanguageData()
    {
        TextAsset language = Resources.Load<TextAsset>("Language/" + currentLanguage.ToString());
        currentLanguageClass = JsonUtility.FromJson<Language>(language.text);
        Debug.Log("Language \n" + language.text);
        Resources.UnloadAsset(language);
    }

    public void SetLanguage(int language)
    {
        currentLanguage = (Languages)Enum.ToObject(typeof(Languages), language);

        Debug.Log("Set Language " + currentLanguage + " " + language);
    }
}
