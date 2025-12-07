using UnityEngine;
using UnityEngine.Events;

public class SPRGetManagerData : MonoBehaviour
{
    [SerializeField]
    UnityEvent<bool> getTMPBool;
    public void GetTMBool()
    {
        Debug.Log("TMP Loaded " + SpriteManager.instance.TMPLOADED);
        getTMPBool?.Invoke(SpriteManager.instance.TMPLOADED);
    }

    public void SetTMPBool(bool tmp)
    {
        SpriteManager.instance.tmpLoaded = tmp;
    }
}
