using UnityEngine;

[CreateAssetMenu(fileName = "Set Dynamic Paths ", menuName = "Scriptable Objects/Sprite Render/Set Dynamic Paths")]
public class SPRSetDynamicPath : ScriptableObject
{
    public void AddDynamicPath(DynamicPaths dynamicPaths)
    {
        SpriteManager.instance.AddDynamicPath(dynamicPaths);
    }

    public void ClearDynamicPaths()
    {
        SpriteManager.instance.ClearDynamicPaths();
    }
}
