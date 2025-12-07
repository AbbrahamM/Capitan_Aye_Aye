using System;
using System.Collections.Generic;
using System.Diagnostics;

public class GMDynamicQuests
{
    public List<DistanceReward> distance_rewards;
    public List<BananaReward> banana_collection_rewards;
}

[System.Serializable]
public abstract class BaseQuest
{
    public ChallengeType challengeType;
    public int ammount = 0;
    public string reward;
    public string description = string.Empty;
    public abstract void SetUp();
}

[System.Serializable]
public class DistanceReward : BaseQuest

{
    public int distance;

    public override void SetUp()
    {
        challengeType = ChallengeType.Distance;
        ammount = distance;
    }
}
[System.Serializable]
public class BananaReward : BaseQuest
{
    public int bananas;


    public override void SetUp()
    {
        challengeType = ChallengeType.Bananas;
        ammount = bananas;
    }
}
