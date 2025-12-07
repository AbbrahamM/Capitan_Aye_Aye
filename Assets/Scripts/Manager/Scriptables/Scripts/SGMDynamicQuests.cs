using System.Collections.Generic;
using System;
using UnityEngine;
using static GMDynamicQuests;
using UnityEngine.Windows;

[CreateAssetMenu(fileName = "SGMDynamicQuests", menuName = "Scriptable Objects/Game Manager/Quests/DynamicQuests")]
public class SGMDynamicQuests : ScriptableObject
{
    GMDynamicQuests gMDynamicQuests = null;
    [SerializeField]
    string questsPath = string.Empty;
    [SerializeField]
    List<GMQuestRules> gmQuestRules;
    public void SetUp()
    {
        TextAsset text = Resources.Load<TextAsset>(questsPath);
        gMDynamicQuests = JsonUtility.FromJson<GMDynamicQuests>(text.text);
        Debug.Log("Set Up " + text.text);
    }

    public void GetTodayUnifiedQuest()
    {
        if (gMDynamicQuests == null)
        {
            Debug.LogWarning("Quests not initialized.");
        }

        List<BaseQuest> unified = GetCombinedQuests();
        if (unified == null || unified.Count == 0)
        {
            Debug.LogWarning("Unified quest list is empty.");
        }
        DateTime dateTime = DateTime.Parse(GameManager.LimpiarAmPm(GameManager.instance.GMSave.startDate));
        int daysPassed = (DateTime.Today - dateTime).Days + 12;
        int index = daysPassed % unified.Count;

        unified[index].SetUp();
        Debug.Log("Which today " + unified[index].challengeType + " " + unified[index].reward + " " + (unified[index].ammount));
        foreach (GMQuestRules rule in gmQuestRules) {
            rule.DONE = true;
            if (rule.type == unified[index].challengeType)
            {
                switch (rule.type)
                {
                    case ChallengeType.Distance:
                        GameManager.instance.ToDayDynamicQuiest = "Recorre " + unified[index].ammount + " Metros y Obten " + unified[index].reward;
                        break;
                    case ChallengeType.Bananas:
                        GameManager.instance.ToDayDynamicQuiest = "Recoge " + unified[index].ammount + " Banans y Obten " + unified[index].reward;
                        break;
                }
                rule.DONE = false;
                rule.toReachNumner = Mathf.RoundToInt(unified[index].ammount);
                rule.dynamicReward = unified[index].reward;
                Debug.Log("Path " + Application.dataPath + "/Assets/Resources/Quests/Dynamic Rewards/" + unified[index].reward.Trim());
                GMDynamicRewards reward = Resources.Load<GMDynamicRewards>("Quests/Dynamic Rewards/" + unified[index].reward.Trim());
                Debug.Log("I load the Reward " + reward.name);
                rule.reachNumberVoid.AddListener(reward.Execute);


                if (GameManager.instance.GMSave.dynamicQuest == true && DateTime.Today == DateTime.Parse(GameManager.instance.GMSave.today))
                {
                    rule.DONE = true;
                }

            }
        }
    }
    public List<BaseQuest> GetCombinedQuests()
    {
        List<BaseQuest> combined = new List<BaseQuest>();
        combined.AddRange(gMDynamicQuests.distance_rewards);
        combined.AddRange(gMDynamicQuests.banana_collection_rewards);
        return combined;
    }
}
