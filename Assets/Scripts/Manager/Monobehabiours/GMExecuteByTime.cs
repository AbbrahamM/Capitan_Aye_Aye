using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GMExecuteByTime : MonoBehaviour
{
    [SerializeField]
    UnityEvent toDoBefore;
    [SerializeField]
    UnityEvent toDoAfter;
    [SerializeField]
    UnityEvent<float> toDoWhile;

    float currentTime = 0;
    float staticTime = 0;
    float staticTimeInt = 0;

    IEnumerator executeByTime = null;


    public void ExecuteEndOfFrame()
    {
        if(executeByTime == null)
        {
            executeByTime = ExecuteEndOfFrameE();
            StartCoroutine(executeByTime);
        }
    }

    public void ExeteByTime(float time)
    {
        if (executeByTime == null)
        {
            executeByTime = ExecuteByTimeE(time);
            StartCoroutine(executeByTime);
        }
    }

    public void ExeteByTimeNoScale(float time)
    {
        if (executeByTime == null)
        {
            executeByTime = ExecuteByTimeNoScaleE(time);
            StartCoroutine(executeByTime);
        }
    }

    public void ExeteWhileTimeNoScaleBackwards(float time)
    {
        if (executeByTime == null)
        {
            executeByTime = ToDoWhileNoScaleBackwards(time);
            StartCoroutine(executeByTime);
        }
    }

    public void ExeteByTime(int time)
    {
        if (executeByTime == null)
        {
            executeByTime = ExecuteByTimeE((float)time);
            StartCoroutine(executeByTime);
        }
    }

    public void ExecuteByTimeWhile(float time)
    {
        if(executeByTime == null)
        {
            Debug.Log("Do get here? ");
            currentTime = 0;
            executeByTime = ToDoWhile(time);
            StartCoroutine(executeByTime);
        }
    }

    public void ExecuteByTimeWhile(int time)
    {
        if (executeByTime == null)
        {
            Debug.Log("Do get here? ");
            currentTime = 0;
            executeByTime = ToDoWhile((float)time);
            StartCoroutine(executeByTime);
        }
    }

    public void ExecuteByTimeWhile()
    {
        if (executeByTime == null)
        {
            currentTime = 0;
            executeByTime = ToDoWhile(staticTime);
            StartCoroutine(executeByTime);
        }
    }

    public void ExecuteByTimeWhileInt()
    {
        if (executeByTime == null)
        {
            currentTime = 0;
            executeByTime = ToDoWhile(staticTimeInt);
            StartCoroutine(executeByTime);
        }
    }

    IEnumerator ExecuteByTimeE(float time)
    {
        toDoBefore?.Invoke();
        Debug.Log("Execute by time " + time + " " + gameObject.name) ;
        yield return new WaitForSeconds(time);
        Debug.Log("Do i finish ");
        toDoAfter?.Invoke();
        executeByTime = null;
    }

    IEnumerator ExecuteByTimeNoScaleE(float time)
    {
        toDoBefore?.Invoke();
        yield return new WaitForSecondsRealtime(time);
        Debug.Log("Do i finish ");
        toDoAfter?.Invoke();
        executeByTime = null;
    }

    IEnumerator ExecuteEndOfFrameE()
    {
        Debug.Log("Execute End Of Frame ");
        toDoBefore?.Invoke();
        yield return new WaitForFixedUpdate();
        toDoAfter?.Invoke();
        executeByTime = null;
    }

    private void OnDisable()
    {
        if(executeByTime != null)
        {
            StopCoroutine(executeByTime);
            toDoAfter?.Invoke();
            executeByTime = null;
        }
    }

    IEnumerator ToDoWhile(float time)
    {
        toDoBefore?.Invoke();
        while (currentTime < time) {
            yield return null;
            currentTime += Time.deltaTime;
            toDoWhile?.Invoke(currentTime);
        }
        toDoAfter?.Invoke();
        executeByTime = null;
    }

    IEnumerator ToDoWhileNoScaleBackwards(float time)
    {
        toDoBefore?.Invoke();
        currentTime = time;
        while (currentTime > 0)
        {
            yield return null;
            currentTime -= Time.unscaledDeltaTime;
            toDoWhile?.Invoke(currentTime);
        }
        toDoAfter?.Invoke();
        executeByTime = null;
    }

    IEnumerator ToDoWhile(int time)
    {
        toDoBefore?.Invoke();
        while (currentTime < time)
        {
            yield return null;
            currentTime += Time.deltaTime;
            toDoWhile?.Invoke(currentTime);
        }
        toDoAfter?.Invoke();
        executeByTime = null;
    }

    public float STATICTIME
    {
        set { staticTime = value; }
    }
    public int STATICTIMEINT
    {
        set { staticTimeInt = value; }
    }
}
