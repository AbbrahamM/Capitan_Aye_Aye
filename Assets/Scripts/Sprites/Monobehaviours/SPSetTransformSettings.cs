using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class SPSetTransformSettings : MonoBehaviour
{
    [SerializeField]
    UnityEvent<int> getIntData;
    public void SetTranformXPosition(float xPos)
    {
        Vector3 position = transform.position;
        position.x = xPos;
        transform.position = position;
    }

    public void GetSiblingIndex()
    {
        getIntData?.Invoke(transform.GetSiblingIndex());
    }
}
