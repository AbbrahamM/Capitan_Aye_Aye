using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GMQuest", menuName = "Scriptable Objects/Game Manager/Quests/Quest")]
public class GMQuest : ScriptableObject
{
    public List<bool> toUnLock = new();


    public void Unlock()
    {
        int index = toUnLock.IndexOf(toUnLock.Last(e=>!e));
        toUnLock[index] = true;
    }
}
