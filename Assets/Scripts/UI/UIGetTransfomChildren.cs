using UnityEngine;
using UnityEngine.Events;

public class UIGetTransfomChildren : MonoBehaviour
{
    [SerializeField]
    Transform _transfomReference;

    [SerializeField]
    UnityEvent<int> getSiblingIndex;
    public void GetTransformChildren() { 
        getSiblingIndex?.Invoke(_transfomReference.GetSiblingIndex());
    }
}
