using UnityEngine;

[CreateAssetMenu(fileName = "GMPowerUp", menuName = "Scriptable Objects/Game Manager/Power Up")]
public class GMPowerUp : ScriptableObject
{
    public string Name;

    public int price;

    public int[] durationSeconds;
}
