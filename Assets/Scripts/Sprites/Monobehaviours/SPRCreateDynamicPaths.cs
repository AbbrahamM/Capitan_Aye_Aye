using UnityEngine;
using UnityEngine.Events;

public class SPRCreateDynamicPaths : MonoBehaviour
{
    [SerializeField]
    DynamicPaths dynamicPaths;

    [SerializeField]
    UnityEvent<DynamicPaths> addDynamicPaths;


    public void AddDynamicPath()
    {
        addDynamicPaths?.Invoke(dynamicPaths);
    }
}
