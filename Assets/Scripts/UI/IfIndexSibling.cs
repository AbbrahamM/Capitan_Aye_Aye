using UnityEngine;
using UnityEngine.Events;

public class IfIndexSibling : MonoBehaviour
{
    [SerializeField]
    UnityEvent toDoIndexSiblinTrue;
    [SerializeField]
    UnityEvent toDoIndexSiblinFalse;

    bool fond = false;

    private void OnEnable()
    {
        fond = false;
    }

    public void IfSiblingFor(int index)
    {
        Debug.Log("Children " +  index + " " + transform.GetSiblingIndex());
        if (!fond)
        {
            if (transform.GetSiblingIndex() == index)
            {
                Debug.Log("I am true " + transform.name);
                toDoIndexSiblinTrue?.Invoke();
                fond = true;
            }
            else
            {
                toDoIndexSiblinFalse?.Invoke();
            }
        }
    }

    public void IfLastSibling()
    {
        Debug.Log($"Sibling {transform.name}: {transform.GetSiblingIndex()} : {transform.parent.childCount - 1}");
        if (transform.GetSiblingIndex() == transform.parent.childCount-1)
        {
            toDoIndexSiblinTrue?.Invoke();
        }
        else
        {
            toDoIndexSiblinFalse?.Invoke();
        }
    }

    public void IfIndexIequelTo(int index)
    {
        Debug.Log($"Sibling {transform.name}: {transform.GetSiblingIndex()} : {transform.parent.childCount - 1}");
        if (transform.GetSiblingIndex() == index)
        {
            Debug.Log("its true ");
            toDoIndexSiblinTrue?.Invoke();
        }
        else
        {
            toDoIndexSiblinFalse?.Invoke();
        }
    }
}
