using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GMIfQuestKind : MonoBehaviour
{
    [SerializeField]
    UnityEvent<ChallengeType> toDoDistance;
    [SerializeField]
    UnityEvent<ChallengeType> toDoBananas;
    public void Test(string kind)
    {
        Debug.Log("Kind " + kind);
        switch (Enum.Parse(typeof(ChallengeType), kind)){
            case ChallengeType.Distance:
                toDoDistance?.Invoke(ChallengeType.Distance);
                break;
            default:
                toDoBananas?.Invoke(ChallengeType.Bananas);
                break;
        }
    }
}
