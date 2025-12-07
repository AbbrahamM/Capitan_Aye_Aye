using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GMGetDate", menuName = "Scriptable Objects/Game Manager/Get Date")]
public class GMGetDate : ScriptableObject
{
    [SerializeField]
    UnityEvent<string> getCurrentDate;
    public void GetDateCurrentDate()
    {
        getCurrentDate?.Invoke(DateTime.Now.ToString());
    }
}
