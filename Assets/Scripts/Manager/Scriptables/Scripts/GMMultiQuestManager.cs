using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Multi Quests", menuName = "Scriptable Objects/Game Manager/Quests/Multi Quests")]
public class GMMultiQuestManager : ScriptableObject
{
    [SerializeField]
    string pathToTest = string.Empty;
    string dynamicPath = string.Empty;

    [SerializeField]
    GMQuestRules[] GMQuestRules;

    [SerializeField]
    UnityEvent toDoWhenQuestDone;
    [SerializeField]
    UnityEvent toDoWhenQuestNotDone;
    [SerializeField]
    bool done = false;
    public void TestDone()
    {
        Debug.Log("I test the new misions " + GMQuestRules.Count(e => e.DONE) + " " + GMQuestRules.Length + " " + pathToTest + " " + dynamicPath + " " + name);
        if (!done && pathToTest == dynamicPath && GMQuestRules.Count(e=>e.DONE) == GMQuestRules.Length)
        {
            toDoWhenQuestDone?.Invoke();
            string message = string.Empty;
            foreach(GMQuestRules rule in GMQuestRules) { message += rule.dynamicReward + " "; }
            ShowMessage(message);
            done = true;
        }
    }

    public void ShowMessage(string message)
    {

        GMPlayerController.instance.ShowMessage(message);
    }

    public string DYNAMICPATH
    {
        set { dynamicPath = value; Debug.Log("Dynamic Path MultiQuests " + dynamicPath); }
    }

    public bool DONE
    {
        set { done = value; }
    }
}
