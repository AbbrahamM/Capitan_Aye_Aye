
using System;

public class GMSave
{
    public int maxDistance = 0;
    public int maxBananas = 0;
    public int toUseBananas = 0;
    public int coinsToUse = 0;
    public int language = 1;

    public string startDate = string.Empty;

    public string currentDate = string.Empty;

    public int[] dailyQuestValue;
    public string[] dailyQuestType;
    public bool[] dailyQuestComplited;
    public bool[] dailyQuestOpend;

    public bool unlockedDailyQuest = false;
    public bool firstQuestDone = false;

    public string[] powerUps;
    public int[] powerUpsIndex;

    public string[] unlockedSkins = { "Mono" };
    public string currentSkin = "Mono";
    public bool volume = true;

    public string today = string.Empty;
    public bool dynamicQuest = false;
}
