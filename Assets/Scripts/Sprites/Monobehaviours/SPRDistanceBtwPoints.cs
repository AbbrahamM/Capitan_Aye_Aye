using UnityEngine;
using UnityEngine.Events;

public class SPRDistanceBtwPoints : MonoBehaviour
{
    [SerializeField]
    Transform pointA;
    [SerializeField]
    Transform pointB;

    [SerializeField]
    UnityEvent<float> toDoWhenCalculateDistance;

   

    public void CalculateDistance()
    {
        toDoWhenCalculateDistance?.Invoke(Vector3.Distance(pointA.position, pointB.position));
    }
}
