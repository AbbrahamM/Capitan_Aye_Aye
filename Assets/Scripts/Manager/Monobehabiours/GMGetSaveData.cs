using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class GMGetSaveData : MonoBehaviour
{
    [SerializeField]
    UnityEvent<int> getMaxDistance;
    [SerializeField]
    UnityEvent<int> getMaxBananas;
    [SerializeField]
    UnityEvent<int> getQuestValue;
    [SerializeField]
    UnityEvent<string> getQuestType;
    [SerializeField]
    UnityEvent<bool> getQuestCompleted;
    [SerializeField]
    UnityEvent<bool> getDailyQuest;
    [SerializeField]
    UnityEvent<bool> getFirstQuestDone;
    [SerializeField]
    UnityEvent<int> getUseBanas;
    [SerializeField]
    UnityEvent<bool> getDailyQuestOpned;
    [SerializeField]
    UnityEvent<int> getCoinsToUse;
    [SerializeField]
    UnityEvent<bool> getVolume;
    [SerializeField]
    UnityEvent<int> getAllQuestsLenght;
    [SerializeField]
    UnityEvent<int> getLanguage;
    [SerializeField]
    UnityEvent<string> getMissions;

    public void GetLanguage()
    {
        getLanguage?.Invoke(GameManager.instance.GMSave.language);
    }
    public void GetMaxDistance()
    {
        getMaxDistance?.Invoke(GameManager.instance.GMSave.maxDistance);
    }

    public void GetMaxBananas()
    {
        getMaxBananas?.Invoke(GameManager.instance.GMSave.maxBananas);
    }

    public void GetQuests(int index)
    {
        Debug.Log("Get Quests Index " +  index + " " + GameManager.instance.GMSave.dailyQuestType.Length);

        if(GameManager.instance.GMSave.dailyQuestValue != null && GameManager.instance.GMSave.dailyQuestValue.Length > 0) 
            getQuestValue?.Invoke(GameManager.instance.GMSave.dailyQuestValue[index]);

        if (GameManager.instance.GMSave.dailyQuestType != null && GameManager.instance.GMSave.dailyQuestType.Length > 0)
            getQuestType?.Invoke(GameManager.instance.GMSave.dailyQuestType[index]);

        if (GameManager.instance.GMSave.dailyQuestComplited != null && GameManager.instance.GMSave.dailyQuestComplited.Length > 0)
            getQuestCompleted?.Invoke(GameManager.instance.GMSave.dailyQuestComplited[index]);

        if (GameManager.instance.GMSave.dailyQuestOpend != null && GameManager.instance.GMSave.dailyQuestOpend.Length > 0)
            getDailyQuestOpned?.Invoke(GameManager.instance.GMSave.dailyQuestOpend[index]);
    }


    public void GetAllQuests()
    {
        if(GameManager.instance.GMSave.dailyQuestValue != null)
        {
            for (int i = 0; i < GameManager.instance.GMSave.dailyQuestValue.Length; i++)
            {
                getQuestValue?.Invoke(GameManager.instance.GMSave.dailyQuestValue[i]);
            }
        }
        if(GameManager.instance.GMSave.dailyQuestType != null)
        {
            for (int i = 0; i < GameManager.instance.GMSave.dailyQuestType.Length; i++)
            {
                getQuestType?.Invoke(GameManager.instance.GMSave.dailyQuestType[i]);
            }
        }
        if(GameManager.instance.GMSave.dailyQuestComplited != null)
        {
            for (int i = 0; i < GameManager.instance.GMSave.dailyQuestComplited.Length; i++)
            {
                getQuestCompleted?.Invoke(GameManager.instance.GMSave.dailyQuestComplited[i]);
            }
        }
        if(GameManager.instance.GMSave.dailyQuestOpend != null)
        {
            for (int i = 0; i < GameManager.instance.GMSave.dailyQuestOpend.Length; i++)
            {
                getDailyQuestOpned?.Invoke(GameManager.instance.GMSave.dailyQuestOpend[i]);
            }
        }
    }

    public void GetAllQuestLength()
    {
        getAllQuestsLenght?.Invoke(GameManager.instance.GMSave.dailyQuestValue.Length-1);
    }

    public void GetUnlockDailyQuest()
    {
        getDailyQuest?.Invoke(GameManager.instance.GMSave.unlockedDailyQuest);
    }

    public void GetFirstQuestDone()
    {
        getFirstQuestDone?.Invoke(GameManager.instance.GMSave.firstQuestDone);
    }

    public void GetUseBananas()
    {
        getUseBanas?.Invoke(GameManager.instance.GMSave.toUseBananas);
    }

    public void GetDailyQuestOpened(int index)
    {
        if(GameManager.instance.GMSave.dailyQuestOpend != null && GameManager.instance.GMSave.dailyQuestOpend.Length > 0)
        {
            Debug.Log("Index " + index + " " + GameManager.instance.GMSave.dailyQuestOpend.Length);
            getDailyQuestOpned?.Invoke(GameManager.instance.GMSave.dailyQuestOpend[index]);
        }
    }

    public void GetDailyQuestComplited(int index)
    {
        Debug.Log("Index C " + index + " " + GameManager.instance.GMSave.dailyQuestComplited.Length+" "+ GameManager.instance.GMSave.dailyQuestComplited[index]);
        getQuestCompleted?.Invoke(GameManager.instance.GMSave.dailyQuestComplited[index]);
    }

    public void GetCoinsToUse()
    {
        getCoinsToUse?.Invoke(GameManager.instance.GMSave.coinsToUse);
    }

    public void GetVolume()
    {
        getVolume?.Invoke(GameManager.instance.GMSave.volume);
    }
    public void GetMissions()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Quests/DynamicQuests");
        GMDynamicQuests quests = JsonUtility.FromJson<GMDynamicQuests>(textAsset.text);

        foreach(BaseQuest quest in quests.banana_collection_rewards)
        {
            getMissions.Invoke(quest.description);
        }

        foreach (BaseQuest quest in quests.distance_rewards)
        {
            getMissions.Invoke(quest.description);
        }

    }

    public void GetMission(int index)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Quests/DynamicQuests");
        GMDynamicQuests quests = JsonUtility.FromJson<GMDynamicQuests>(textAsset.text);
        List<string> descriptions = new();
        foreach (BaseQuest quest in quests.banana_collection_rewards)
        {
            descriptions.Add(quest.description);
        }

        foreach (BaseQuest quest in quests.distance_rewards)
        {
            descriptions.Add(quest.description);
        }

        getMissions?.Invoke(descriptions[index]);

    }
}
