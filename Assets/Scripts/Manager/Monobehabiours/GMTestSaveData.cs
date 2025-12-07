using UnityEngine;
using UnityEngine.Events;

public class GMTestSaveData : MonoBehaviour
{
    [SerializeField]
    UnityEvent<int> toDoIfMaxDistance;
    [SerializeField]
    UnityEvent<int> toDoIfMaxBananas;

    public void TestMaxBanans(int bananas)
    {
        if (bananas > GameManager.instance.GMSave.maxBananas) { 
            toDoIfMaxBananas?.Invoke(bananas);
        }
    }

    public void TestMaxDistance(int distance)
    {
        if(distance > GameManager.instance.GMSave.maxDistance)
        {
            toDoIfMaxDistance?.Invoke(distance); 
        }
    }
}
