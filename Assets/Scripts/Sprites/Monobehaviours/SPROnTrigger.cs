using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SPROnTrigger : MonoBehaviour
{
    [SerializeField]
    List<int> layers = new();

    [SerializeField]
    UnityEvent<Collider2D> onEnterE;
    [SerializeField]
    UnityEvent<Collider2D> onExitE;

    [SerializeField]
    bool onlyOnce = false;

    bool hitted = false;


    public static event Action<Collider2D,GameObject> onEnter;
    public static event Action<Collider2D,GameObject> onExit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enabled)
            return;
        if (!hitted && layers.Contains(collision.gameObject.layer))
        {
            Debug.Log("Enter " +gameObject.name + " " + collision.name);
            hitted = true;

            onEnter?.Invoke(collision,gameObject);
            onEnterE?.Invoke(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!enabled)
            return;
        if (!onlyOnce && layers.Contains(collision.gameObject.layer))
        {
            hitted = false;
            onExit?.Invoke(collision, gameObject);
            onExitE?.Invoke(collision);
        }
    }

    private void OnDisable()
    {
        hitted = false;
    }

    public bool ONLYONCE
    {
        set { onlyOnce = value; }
    }

    public bool HITTED
    {
        set { hitted = value; }
    }
}
