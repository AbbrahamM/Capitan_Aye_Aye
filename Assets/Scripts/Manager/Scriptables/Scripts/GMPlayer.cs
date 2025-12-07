using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Game Manager/Player")]
public class GMPlayer : ScriptableObject
{
    public float jumpForce = 12;

    public float gravityDown = 5;
    public float gravityUp = 2;

    public int bananasCounter = 0;


    public float dificultyFactor = 0;

    public float dashSpeed = 2f;
    public float dashDuratio = 0.25f;
    public float dashCooldown = 5f;

    public int life = 2;
    public void IncreaseFactor(float factor)
    {
        dificultyFactor = factor;
    }
}
