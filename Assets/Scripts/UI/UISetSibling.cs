using UnityEngine;

public class UISetSibling : MonoBehaviour
{
    int lastSibling = 0;

    private void OnEnable()
    {
        lastSibling = transform.GetSiblingIndex();
    }

    public void SetLastSibling()
    {
        if(transform.GetSiblingIndex() != transform.parent.childCount - 1)
        {
            transform.parent.GetChild(0).SetAsLastSibling();
            transform.SetAsLastSibling();
        }
    }

    public void ResuturnToLastSibling()
    {
        transform.SetSiblingIndex(lastSibling);
    }
}
