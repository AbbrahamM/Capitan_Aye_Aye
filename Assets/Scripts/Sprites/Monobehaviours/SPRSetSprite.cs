using UnityEngine;
using UnityEngine.Events;

public class SPRSetSprite : MonoBehaviour
{
    [SerializeField]
    string dynamicPathId;
    [SerializeField]
    UnityEvent<Sprite> setSprite;
    [SerializeField]
    UnityEvent<string> getPath;

    public void SetSpriteFromDynamicPath()
    {
        Sprite sprite = Resources.Load<Sprite>(SpriteManager.instance.GetDynamicPath(dynamicPathId));
        setSprite?.Invoke(sprite);
    }

    public void GetDynamicPathById()
    {
        Debug.Log("Dinamic Path " + SpriteManager.instance.GetDynamicPath(dynamicPathId));
        getPath?.Invoke(SpriteManager.instance.GetDynamicPath(dynamicPathId));
    }
}
