using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SPRDash : MonoBehaviour
{
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float dashDuration;
    [SerializeField]
    UnityEvent<float> toDoWhenStart;

    [SerializeField]
    UnityEvent<float> toDoWhenEnd;

    IEnumerator DashI;
    [SerializeField]
    Rigidbody2D rb;
    public void Dash()
    {
        if(DashI == null)
        {
            rb.linearVelocity = Vector2.zero;
            DashI = IDash();
            StartCoroutine(DashI);
        }
    }

    IEnumerator IDash()
    {
        toDoWhenStart?.Invoke(dashSpeed);

        Debug.Log("start Dashing  " + dashDuration);

        yield return new WaitForSeconds(dashDuration);

        Debug.Log("I finish dash ");
        toDoWhenEnd?.Invoke(dashSpeed);
        DashI = null;
    }

    public void Stop()
    {
        if (DashI != null) { 
            StopCoroutine(DashI);
            toDoWhenEnd?.Invoke(dashSpeed);
            DashI = null;
        }
    }

    public float DASHSPEED
    {
        set { dashSpeed = value; }
        get { return dashSpeed; }   
    }

    public float DASHDURATION
    { 
        set { dashDuration = value; }
        get { return dashDuration; } 
    }
}
