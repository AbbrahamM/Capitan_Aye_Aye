using UnityEngine;
using UnityEngine.Events;

public class UIGetSibling : MonoBehaviour
{
    [SerializeField]
    bool executeOnEnable = true;
    [SerializeField]
    UnityEvent<int> getSiblingPosition;
    [SerializeField]
    bool parentSibling = false;

    private void OnEnable()
    {
        if (executeOnEnable)
            GetSibling();
    }


    public void GetSibling()
    {
        if(!parentSibling)
            getSiblingPosition?.Invoke(transform.GetSiblingIndex());
        else
            getSiblingPosition?.Invoke(transform.parent.transform.GetSiblingIndex());
    }
}
