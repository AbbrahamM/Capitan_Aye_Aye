using UnityEngine;

public class UISetCanvasSettings : MonoBehaviour
{
    [SerializeField]
    RectTransform RectTransform;
    [SerializeField]
    Vector2 pivot = Vector2.zero;
    [SerializeField]
    Vector3 position = Vector3.zero;

    [SerializeField]
    bool onEnable = true;
    private void OnEnable()
    {
        if (!onEnable)
            return;

        SetPivot();
        SetPosition();
    }

    public void SetPivot()
    {
        RectTransform.pivot = pivot;
    }

    public void SetPosition()
    {
        RectTransform.localPosition = position;
    }
}
