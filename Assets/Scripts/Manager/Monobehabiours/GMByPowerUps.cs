using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GMByPowerUps : MonoBehaviour
{
    [SerializeField]
    UnityEvent toDoIfCanBuy;
    [SerializeField]
    UnityEvent toDoIfCanNotBuy;
    [SerializeField]
    UnityEvent toDoIfMax;
    
    public void Buy(GMPowerUp gMPowerUp)
    {
        if (GameManager.instance.GMSave.powerUps.Contains(gMPowerUp.Name))
        {
            int index = GameManager.instance.GMSave.powerUps.ToList().IndexOf(gMPowerUp.Name);
            if(GameManager.instance.GMSave.powerUpsIndex[index] + 1 < gMPowerUp.durationSeconds.Length)
            {
                if (GameManager.instance.GMSave.toUseBananas - gMPowerUp.price >= 0)
                {
                    toDoIfCanBuy?.Invoke();
                }
                else
                {
                    toDoIfCanNotBuy?.Invoke();
                }
            }
        }
        else
        {
            Debug.Log("What is happenign ");
            if (GameManager.instance.GMSave.toUseBananas - gMPowerUp.price >= 0)
            {
                toDoIfCanBuy?.Invoke();
            }
            else { toDoIfCanNotBuy?.Invoke();
            }
        }
    }

    public void CanBuy(GMPowerUp gMPowerUp)
    {
        if (GameManager.instance.GMSave.powerUps.Contains(gMPowerUp.Name))
        {
            int index = GameManager.instance.GMSave.powerUps.ToList().IndexOf(gMPowerUp.Name);

            Debug.Log("Can Buy " + GameManager.instance.GMSave.powerUps.Contains(gMPowerUp.Name) + " " + index + " " + (GameManager.instance.GMSave.toUseBananas - gMPowerUp.price >= 0));
            if (GameManager.instance.GMSave.powerUpsIndex[index] + 1 < gMPowerUp.durationSeconds.Length && GameManager.instance.GMSave.toUseBananas - gMPowerUp.price >= 0)
            {
                GameManager.instance.GMSave.powerUpsIndex[index] += 1;
                GameManager.instance.GMSave.toUseBananas -= gMPowerUp.price;
            }
        }
        else
        {
            if (GameManager.instance.GMSave.toUseBananas - gMPowerUp.price >= 0)
            {
                if (GameManager.instance.GMSave.powerUps == null || GameManager.instance.GMSave.powerUps.Length <= 0)
                {
                    GameManager.instance.GMSave.powerUps = new string[1];
                    GameManager.instance.GMSave.powerUpsIndex = new int[1];

                    GameManager.instance.GMSave.powerUps[0] = gMPowerUp.Name;
                    GameManager.instance.GMSave.powerUpsIndex[0] = 0;
                }
                else
                {
                    string[] tmpPowerUps = new string[GameManager.instance.GMSave.powerUps.Length + 1];
                    int[] tmpIndex = new int[GameManager.instance.GMSave.powerUpsIndex.Length + 1];

                    GameManager.instance.GMSave.powerUps.CopyTo(tmpPowerUps, 0);
                    GameManager.instance.GMSave.powerUpsIndex.CopyTo(tmpIndex, 0);

                    tmpPowerUps[tmpPowerUps.Length - 1] = gMPowerUp.Name;
                    tmpIndex[tmpIndex.Length - 1] = 0;


                    GameManager.instance.GMSave.powerUps = new string[tmpPowerUps.Length];
                    GameManager.instance.GMSave.powerUpsIndex = new int[tmpIndex.Length];

                    tmpPowerUps.CopyTo(GameManager.instance.GMSave.powerUps, 0);
                    tmpIndex.CopyTo(GameManager.instance.GMSave.powerUpsIndex, 0);
                }
                GameManager.instance.GMSave.toUseBananas -= gMPowerUp.price;
            }
        }
    }

    public void Max(GMPowerUp gMPowerUp)
    {
        int index = GameManager.instance.GMSave.powerUps.ToList().IndexOf(gMPowerUp.Name);
        if (GameManager.instance.GMSave.powerUpsIndex[index] + 1 == gMPowerUp.durationSeconds.Length)
        {
            toDoIfMax?.Invoke();
        }
    }
}
