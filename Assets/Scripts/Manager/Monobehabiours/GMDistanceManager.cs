using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GMDistanceManager : MonoBehaviour
{
    float fullDistance = 0;
    [SerializeField]
    UnityEvent<int> showDistance;

    int last = 0;

    float modifier = 0;
    int startSubstract = 5;
    public void AddDistance(float distance)
    {
        //currentDistance = distance;
        //Debug.Log("How many times i enter here? " + currentDistance  + " " + distance);
        //
        if (!enabled)
            return;

        showDistance?.Invoke(Mathf.RoundToInt(last + fullDistance));

        if (last < Mathf.CeilToInt((distance + modifier) * 0.2f) - startSubstract)
            last = Mathf.CeilToInt((distance + modifier)*0.2f) - startSubstract;       
        
        Debug.Log("Distance Manager " + gameObject.name + " " + (last + fullDistance));
    }


    public void AddCurrentDistance()
    {
        fullDistance += last;
        Debug.Log("Current Distance added " + last);
        last = 0;
    }

    public float DISTANCEMODIFIER
    {
        set { modifier = value; }
    }
}
