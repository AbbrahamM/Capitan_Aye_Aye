using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GMQuest Rule", menuName = "Scriptable Objects/Game Manager/Quests/Reach Bananas")]
public class GMQuestRules : ScriptableObject
{
    public ChallengeType type = ChallengeType.Bananas;
    public int toReachNumner = 1;
    public int rewardToUnlock = 10;

    public string dynamicReward = string.Empty;


    [SerializeField]
    public UnityEvent<bool> reachNumber = null;
    public UnityEvent<string> reachNumberString = null;
    [HideInInspector]
    public UnityEvent reachNumberVoid = null;
    [SerializeField]
    private bool alreadyDone = false;

    public void Test(int currentNumber)
    {
        if (!alreadyDone && currentNumber == toReachNumner && GameManager.instance.GMChallengeType == type)
        {
            Debug.Log("I reached the number " + currentNumber +" " + +toReachNumner + " " + type);
            reachNumber?.Invoke(true);
            reachNumberVoid?.Invoke();
            reachNumberString?.Invoke(dynamicReward);
            alreadyDone = true;
        }
    }

    public void TestAll(int currentNumber)
    {
        for (int i = 0; i < GameManager.instance.GMSave.dailyQuestType.Length; i++)
        {
            if (GameManager.instance.GMSave.dailyQuestType[i] == type.ToString() && !GameManager.instance.GMSave.dailyQuestComplited[i])
            {
                Debug.Log("Daily quest value " + GameManager.instance.GMSave.dailyQuestValue.Length + " " + i  + " " + GameManager.instance.GMSave.dailyQuestType.Length + " " + GameManager.instance.GMSave.dailyQuestComplited.Length);

                if (GameManager.instance.GMSave.dailyQuestValue[i] <= currentNumber)
                {
                    Debug.Log($"{i} I Unlocked {type}: {GameManager.instance.GMSave.dailyQuestValue[i]} : {currentNumber}");
                    GameManager.instance.GMSave.dailyQuestComplited[i] = true;
                }
            }
        }
    }
    public void TestIndividual(int currentNumber)
    {
        Debug.Log("I not reached the number individual " + currentNumber + " " + +toReachNumner + " " + type);
        if (!alreadyDone && currentNumber == toReachNumner)
        {
            Debug.Log("I reached the number individual " + currentNumber + " " + +toReachNumner + " " + type);
            alreadyDone = true;
            reachNumber?.Invoke(true);
            reachNumberVoid?.Invoke();
            reachNumberString?.Invoke(dynamicReward);
        }
    }

    public bool DONE
    {
        set { alreadyDone = value; }
        get { return alreadyDone; }
    }
    public int TOREACH
    {
        set {  toReachNumner = value; }
    }
    public void IncreaseToReach(int newToReach)
    {
        toReachNumner += newToReach;
    }
}
