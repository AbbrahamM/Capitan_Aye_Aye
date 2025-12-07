using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Activate Power Up", menuName = "Scriptable Objects/Game Manager/Activate Power Up")]
public class GMActivatePowerUp : ScriptableObject
{
    public void ActivatePowerUp(string powerUp)
    {
        if (!GameManager.instance.GMPOERUPS.First(e => e.name.Equals(powerUp)).gameObject.activeSelf)
        {
            Debug.Log("Activate Power Up " + powerUp);
            GameManager.instance.GMPOERUPS.First(e => e.name.Equals(powerUp)).gameObject.SetActive(true);
        }
    }

    public void DiactivatePowerUp(string powerUp)
    {
        GameObject powrUpG = GameManager.instance.GMPOERUPS.First(e => e.name.Equals(powerUp)).gameObject;
        if (powrUpG.activeSelf)
        {
            GameManager.instance.GMPOERUPS.First(e => e.name.Equals(powerUp)).gameObject.SetActive(false);
        }
    }
}
