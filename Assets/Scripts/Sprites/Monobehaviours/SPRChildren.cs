using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SPRChildren : MonoBehaviour
{
    [SerializeField]
    UnityEvent toDoWhenFinish;
    public void SetActiveFalseAllChildren()
    {
        Debug.Log("Set children  false " + gameObject.name);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        toDoWhenFinish?.Invoke();

    }
}
