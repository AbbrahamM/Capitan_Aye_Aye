using UnityEngine;

[CreateAssetMenu(fileName = "GMDificulty", menuName = "Scriptable Objects/Game Manager/Dificulty")]
public class GMDificulty : ScriptableObject
{
    public float BackgroundSpeed = 350f;

    public float dificultyFactor = 0;

    public float speedUpFactor = 2;

    public float[] skillDuration;

    public void IncreaseFactor(float factor)
    {
        dificultyFactor = factor;
    }

}
