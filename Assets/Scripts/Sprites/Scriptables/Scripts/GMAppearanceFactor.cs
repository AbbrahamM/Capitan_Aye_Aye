using UnityEngine;

[CreateAssetMenu(fileName = "Appear Object Data", menuName = "Scriptable Objects/Game Manager/Apper Object Data")]
public class GMAppearanceFactor : ScriptableObject
{
    [Header("Per Object")]
    public GameObject prefabReference;
    public float appearFactor = 1;
    public float maxCount;
    public bool forceToAppear = true;

    [Header("General")]
    public float randomAppearShowFactor = 0.5f;
    public Vector2 maxMin = new Vector2(0.5f, 1);
}
