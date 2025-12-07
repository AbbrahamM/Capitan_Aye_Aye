using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SPROnlyOnce : MonoBehaviour
{
    [SerializeField]
    UnityEvent ifOnlyOnceExists;
    private void OnEnable()
    {
        StartCoroutine(OnlyOnce());
    }

    
    public IEnumerator OnlyOnce()
    {
        yield return new WaitForEndOfFrame();
        if (!SpriteManager.instance.ONLUONCE.Contains(gameObject.name))
        {
            SpriteManager.instance.ONLUONCE.Add(gameObject.name);
        }
        else
        {
            ifOnlyOnceExists?.Invoke();
        }
    }

    public void RemoveOnlyOnce()
    {
        Debug.Log("how many times do i enter here Remove " + gameObject.name);
        SpriteManager.instance.ONLUONCE.Remove(gameObject.name);
    }

    
}
