using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Special Chest",menuName ="Scriptable Objects/Game Manager/Special Chest")]
public class GMSpecialChest : ScriptableObject
{
    [SerializeField]
    SpecialChest[] specialChest;

    public void GetRandomTreasure()
    {
        
        int randomNumber = Random.Range(0, specialChest.Length);

        specialChest[randomNumber].toExecute?.Invoke(); 
    }
}

[Serializable]
public class SpecialChest
{
    public float factorToAppear = 1;
    public UnityEvent toExecute;
}
