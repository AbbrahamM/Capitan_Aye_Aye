using System;
using UnityEngine;
using UnityEngine.Events;

public class SPRMoveTowardsTargget : MonoBehaviour
{
    [SerializeField]
    Transform targget;
    [SerializeField]
    float followSpeed = 0.1f;
    [SerializeField]
    float distanceToStop = 0.01f;

    [SerializeField]
    UnityEvent toDoWhenNotTarrgget;
    [SerializeField]
    Vector3 offset = Vector3.zero;

    private void FixedUpdate()
    {
        if (!enabled)
            return;
        try
        {
            if (targget == null)
            {
                toDoWhenNotTarrgget?.Invoke();
                return;
            }
                

            if (Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(targget.position.x + offset.x, 0, 0)) > distanceToStop)
                transform.position = Vector3.MoveTowards(transform.position, targget.position + offset, followSpeed);
        }
        catch(NullReferenceException) { 
            targget = null;
            toDoWhenNotTarrgget?.Invoke();
        }
        catch (MissingReferenceException)
        {
            targget = null;
            toDoWhenNotTarrgget?.Invoke();
        }
    }

    public void SetTarggetFromTrigger(Collider2D other)
    {
        Debug.Log("How many times i enter here " +  other.name);
        targget = other.transform;
    }

    public void SetTarggetNull()
    {
        targget = null;
    }
}
