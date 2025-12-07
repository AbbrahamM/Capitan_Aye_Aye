using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Daly Quest Manager", menuName ="Scriptable Objects/Game Manager/Quests/Daly Quest Manager")]
public class GMDiaryQuest : ScriptableObject
{
    ChallengeType type;
    int targetAmount = 0;
    bool unlockedDailyQuests = false;
    [SerializeField]
    UnityEvent<GMQuestRules> toDoWhenFound;
    public void GenerateDailyChallenge()
    {
        if (!unlockedDailyQuests)
        {
            foreach (GMQuestRules gMQuest in questBananas)
            {
                gMQuest.DONE = true;
            }
            return;
        }

        Debug.Log("Start Date " + GameManager.LimpiarAmPm(GameManager.instance.GMSave.startDate));
        DateTime givenDate = DateTime.Parse(GameManager.LimpiarAmPm(GameManager.instance.GMSave.startDate));
        DateTime currentDate = DateTime.Now;
        int dayDifference = (currentDate - givenDate).Days;

        // Assign quest type based on dayDifference (alternates daily)
        type = (ChallengeType)(dayDifference % 2); // Example: 0 = distance, 1 = bananas

        // New logic: increase targetAmount by 10 per day passed
        int baseValue = 40;
        int incrementPerDay = 10;
        int targetAmount = baseValue + (dayDifference * incrementPerDay);

        Debug.Log("Target Amount " + targetAmount + " | Days Passed: " + dayDifference + " | Today: " + currentDate + " | Start: " + givenDate);

        foreach (GMQuestRules gMQuest in questBananas)
        {
            gMQuest.DONE = false;
            if (gMQuest.type == type)
            {
                gMQuest.toReachNumner = targetAmount;
                GameManager.instance.GMChallengeType = type;
                toDoWhenFound?.Invoke(gMQuest);
            }
        }
    }

    public bool UnlockDailyQuest
    {
        set { unlockedDailyQuests = value; }
    }

    [SerializeField]
    List<GMQuestRules> questBananas = new();
}

public enum ChallengeType { Distance, Bananas,PowerUp,Enemies }
