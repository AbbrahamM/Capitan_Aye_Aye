using UnityEngine;

[CreateAssetMenu(fileName = "GMIncreaseCounter", menuName = "Scriptable Objects/Game Manager/Incrase Counter")]
public class GMIncreaseCounter : ScriptableObject
{
    [SerializeField]
    int increaseValue = 1;
    public void IncreaseBabanaFromCollidr(Collider2D collider)
    {
        if (collider.TryGetComponent(out GMPlayerController gMPlayerController))
        {
            gMPlayerController.IncreaseBananaCounter(increaseValue);
        }
    }
}
