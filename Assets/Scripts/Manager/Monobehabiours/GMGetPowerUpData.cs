using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GMGetPowerUpData : MonoBehaviour
{
    [SerializeField]
    UnityEvent<int> getDurationNumber;
    [SerializeField]
    UnityEvent<int> getIndex;
    [SerializeField]
    UnityEvent<float> getPrice;
    public void GetDuration(GMPowerUp gMPowerUp)
    {
        if (GameManager.instance.GMSave.powerUps != null && GameManager.instance.GMSave.powerUps.Contains(gMPowerUp.Name))
        {
            int index = GameManager.instance.GMSave.powerUps.ToList().IndexOf(gMPowerUp.Name);
            Debug.Log("Index " + index + " " + gMPowerUp.durationSeconds[GameManager.instance.GMSave.powerUpsIndex[index]] + " " + gMPowerUp.Name);
            int duration = gMPowerUp.durationSeconds[GameManager.instance.GMSave.powerUpsIndex[index]];

            getDurationNumber?.Invoke(duration);
           
        }
    }

    public void GetIndex(GMPowerUp gMPowerUp)
    {
        if (GameManager.instance.GMSave.powerUps != null && GameManager.instance.GMSave.powerUps.Contains(gMPowerUp.Name))
        {
            int index = GameManager.instance.GMSave.powerUps.ToList().IndexOf(gMPowerUp.Name);
            Debug.Log("Index " + index + " " + gMPowerUp.durationSeconds[GameManager.instance.GMSave.powerUpsIndex[index]] + " " + gMPowerUp.Name);
            int index2 = GameManager.instance.GMSave.powerUpsIndex[index];
            getIndex?.Invoke(index2);

        }
    }

    public void GetPrice(GMPowerUp gMPowerUp)
    {
        if (GameManager.instance.GMSave.powerUps != null && GameManager.instance.GMSave.powerUps.Contains(gMPowerUp.Name))
        {
            
            float duration = gMPowerUp.price;

            getPrice?.Invoke(duration);

        }
    }
}
