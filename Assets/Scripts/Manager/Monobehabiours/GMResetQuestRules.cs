using UnityEngine;

public class GMResetQuestRules : MonoBehaviour
{
    [SerializeField]
    string path;

    private void OnEnable()
    {
        foreach (GMQuestRules questRule in Resources.LoadAll<GMQuestRules>(path))
        {
            questRule.DONE = false;
        }

        foreach(GMMultiQuestManager queatManager in Resources.LoadAll<GMMultiQuestManager>(path))
        {
            queatManager.DONE = false;
        }
    }
}
