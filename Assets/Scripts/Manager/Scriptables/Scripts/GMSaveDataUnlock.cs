using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GM Set Save Data Values", menuName = "Scriptable Objects/Game Manager/Load&Save/Set Save Data Values")]
public class GMSaveDataUnlock : ScriptableObject
{
    public void SetStartDate(string startDate)
    {
        GameManager.instance.GMSave.startDate = startDate;
        Debug.Log("Set Date " + GameManager.instance.GMSave.startDate);
    }
    public void SetFirstDistace(bool state)
    {
        GameManager.instance.GMSave.firstQuestDone = state;
    }

    public void SetMaxDistance(int distance)
    {
        if(distance > GameManager.instance.GMSave.maxDistance)
        {
            GameManager.instance.GMSave.maxDistance = distance;
        }
    }

    public void SetMaxBananas(int bananas)
    {
        if(bananas > GameManager.instance.GMSave.maxBananas)
        {
            GameManager.instance.GMSave.maxBananas = bananas;
        }
    }

    public void IncreaseUseBananas(int bananas)
    {
        GameManager.instance.GMSave.toUseBananas ++;
    }

    public void SetUpQuest(GMQuestRules quest)
    {
        GameManager.instance.GMSave.dailyQuestValue[GameManager.instance.GMSave.dailyQuestValue.Length-1] = quest.toReachNumner;
        GameManager.instance.GMSave.dailyQuestType[GameManager.instance.GMSave.dailyQuestValue.Length - 1] = quest.type.ToString();
        GameManager.instance.GMSave.dailyQuestComplited[GameManager.instance.GMSave.dailyQuestValue.Length - 1] = false;

    }

    public void SetLanguage(int language)
    {
        GameManager.instance.GMSave.language = language;
    }

    public void AddUpQuest(GMQuestRules quest)
    {

        Debug.Log("I added " + quest.toReachNumner + " " + GameManager.instance.GMSave.dailyQuestValue[GameManager.instance.GMSave.dailyQuestValue.Length - 1]+" " + quest.type);
        if (GameManager.instance.GMSave.dailyQuestValue[GameManager.instance.GMSave.dailyQuestValue.Length - 1] != quest.toReachNumner)
        {
            if(GameManager.instance.GMSave.dailyQuestValue != null && GameManager.instance.GMSave.dailyQuestValue.Length > 0)
            {
                int[] questValue = new int[GameManager.instance.GMSave.dailyQuestValue.Length + 1];
                GameManager.instance.GMSave.dailyQuestValue.CopyTo(questValue, 0);
                questValue[questValue.Length - 1] = quest.toReachNumner;
                GameManager.instance.GMSave.dailyQuestValue = new int[questValue.Length];
                questValue.CopyTo(GameManager.instance.GMSave.dailyQuestValue, 0);
                Debug.Log("Add Daly Quest Value " + GameManager.instance.GMSave.dailyQuestValue.Length + " " + GameManager.instance.GMSave.dailyQuestValue.Last());
            }
            if(GameManager.instance.GMSave.dailyQuestType != null && GameManager.instance.GMSave.dailyQuestType.Length > 0)
            {
                string[] questType = new string[GameManager.instance.GMSave.dailyQuestType.Length + 1];
                GameManager.instance.GMSave.dailyQuestType.CopyTo(questType, 0);
                questType[questType.Length - 1] = quest.type.ToString();
                GameManager.instance.GMSave.dailyQuestType = new string[questType.Length];
                questType.CopyTo(GameManager.instance.GMSave.dailyQuestType, 0);
                Debug.Log("Add Daly Quest Type " + GameManager.instance.GMSave.dailyQuestType.Length + " " + GameManager.instance.GMSave.dailyQuestType.Last());
            }
            if(GameManager.instance.GMSave.dailyQuestComplited != null && GameManager.instance.GMSave.dailyQuestComplited.Length > 0)
            {
                bool[] questComplited = new bool[GameManager.instance.GMSave.dailyQuestComplited.Length + 1];
                GameManager.instance.GMSave.dailyQuestComplited.CopyTo(questComplited, 0);
                questComplited[questComplited.Length - 1] = false;
                GameManager.instance.GMSave.dailyQuestComplited = new bool[questComplited.Length];
                questComplited.CopyTo(GameManager.instance.GMSave.dailyQuestComplited, 0);
                Debug.Log("Add Daly Quest Complited " + GameManager.instance.GMSave.dailyQuestComplited.Length + " " + GameManager.instance.GMSave.dailyQuestComplited.Last());
            }
            if(GameManager.instance.GMSave.dailyQuestOpend != null && GameManager.instance.GMSave.dailyQuestOpend.Length > 0)
            {
                bool[] questOpened = new bool[GameManager.instance.GMSave.dailyQuestOpend.Length + 1];
                GameManager.instance.GMSave.dailyQuestOpend.CopyTo(questOpened, 0);
                questOpened[questOpened.Length - 1] = false;
                GameManager.instance.GMSave.dailyQuestOpend = new bool[questOpened.Length];
                questOpened.CopyTo(GameManager.instance.GMSave.dailyQuestOpend, 0);
                Debug.Log("Add Daly Quest Opened " + GameManager.instance.GMSave.dailyQuestOpend.Length + " " + GameManager.instance.GMSave.dailyQuestOpend.Last());
            }
        }

    }

    public void UnlockUpQuest(GMQuestRules quest)
    {
        int index = GameManager.instance.GMSave.dailyQuestValue.ToList().IndexOf(quest.toReachNumner);
        GameManager.instance.GMSave.dailyQuestComplited[index] = true;

    }

    public void UnlockDynamicQuest(bool value)
    {
        GameManager.instance.GMSave.dynamicQuest = value;
    }

    public void SetUnlockedDailyQuests(bool state)
    {
        GameManager.instance.GMSave.unlockedDailyQuest = state;
    }

    public void SetVolume(bool state)
    {
        GameManager.instance.GMSave.volume = state;
    }

    public void SetOpenedDailyQuest(int index)
    {
        Debug.Log("Daily quest opened " + index);
        GameManager.instance.GMSave.dailyQuestOpend[index] = true;
    }

    public void AddCoins(int amount)
    {
        GameManager.instance.GMSave.coinsToUse += amount;
    }
}
