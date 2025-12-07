using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Game Manager/Enemy")]
public class GMEnemy : ScriptableObject
{
    public Vector2 backForce=new Vector2(-2000, 1000);

    public float dificultyFactor = 0;

    public void IncreaseFactor(float factor)
    {
        dificultyFactor = factor;
    }

}
