using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GMDynamicRewards", menuName = "Scriptable Objects/Game Manager/Rewards/Dynamic Rewards")]
public class GMDynamicRewards : ScriptableObject
{
    [SerializeField]
    int quantity = 0;
    [SerializeField]
    GMActivatePowerUp gMActivatePower;
    [SerializeField]
    UnityEvent execute;
    
    
    public void AddBananas()
    {
        GMPlayerController.instance.IncreaseBananaCounter(quantity);
        Debug.Log("I increase by banas " +  quantity);
    }

    public void UnlockPowerUp(string powerUp)
    {
        gMActivatePower.ActivatePowerUp(powerUp);
    }


    public void ShowMessage(string message)
    {

        GMPlayerController.instance.ShowMessage(message);
    }

    public void AddLife()
    {
        GMPlayerController.instance.AddLife(quantity);
    }

    public void Execute()
    {
        execute?.Invoke();  
    }

    public void ResetDashTime()
    {
        GMPlayerController.instance.ResetDash();
    }
}
