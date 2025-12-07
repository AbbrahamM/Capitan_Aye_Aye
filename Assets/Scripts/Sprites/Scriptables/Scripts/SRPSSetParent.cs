using UnityEngine;

[CreateAssetMenu(fileName = "Set Parent ", menuName = "Scriptable Objects/Sprite Render/Set Parent")]
public class SRPSSetParent : ScriptableObject
{
    public void SetParentNull(Transform transform)
    {
        transform.parent = null;
    }

    public void SetParentNullScale1(Transform transform)
    {
        transform.SetParent(null);
        transform.localScale = Vector3.one;
    }
    public void SetParentNullScale2(Transform transform)
    {
        transform.SetParent(null);
        transform.localScale = Vector3.one*2;
    }

    public void SetParentNull(GameObject gameObject)
    {
        gameObject.transform.parent = null;
    }
}
