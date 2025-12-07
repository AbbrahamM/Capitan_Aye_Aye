using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SPTriggerEnterInjector : MonoBehaviour
{
    [SerializeField]
    UnityEvent<Collider2D> toDo;
    [SerializeField]
    List<int> layer = new();

    private void OnEnable()
    {
        SPROnTrigger.onEnter += Inject;
    }

    public void Inject(Collider2D collider,GameObject trigger)
    {
        if(collider.gameObject.GetInstanceID() == gameObject.GetInstanceID() && layer.Contains(trigger.layer))
            toDo?.Invoke(collider);
    }

    private void OnDisable()
    {
        SPROnTrigger.onEnter -= Inject;
    }
}
