using UnityEngine;
using UnityEngine.Events;

public class GMGetManagerData : MonoBehaviour
{
    [SerializeField]
    UnityEvent<string> getStingData;

    public void GetToDayReward()
    {
        getStingData?.Invoke(GameManager.instance.ToDayDynamicQuiest);
    }
}
