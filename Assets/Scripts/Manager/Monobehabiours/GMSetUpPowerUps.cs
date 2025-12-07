using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GMSetUpPowerUps : MonoBehaviour
{
    [SerializeField]
    UnityEvent<string> toDoWhenUnlocked;
    private void OnEnable()
    {
        
        if(GameManager.instance.GMSave.powerUps != null)
        {
            foreach (string unlocked in GameManager.instance.GMSave.powerUps)
            {
               toDoWhenUnlocked?.Invoke(unlocked);
                Debug.Log("[GMSetUpPowerUps] " + unlocked);
            }
        }
    }
}
