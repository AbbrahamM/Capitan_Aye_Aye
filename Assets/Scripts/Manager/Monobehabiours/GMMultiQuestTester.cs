using UnityEngine;

public class GMMultiQuestTester : MonoBehaviour
{
    [SerializeField]
    GMMultiQuestManager[] multiQuests;

    public void Test()
    {
        foreach (var multiQuest in multiQuests) { 
            multiQuest.TestDone();
        }
    }
}
