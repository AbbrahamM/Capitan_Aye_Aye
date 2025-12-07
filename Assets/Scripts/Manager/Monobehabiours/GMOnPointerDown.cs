
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GMOnPointerDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    Button button;
    [SerializeField]
    UnityEvent onPointerDown;
    [SerializeField]
    UnityEvent onPointerUp;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (button.interactable)
        {
            onPointerDown?.Invoke();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (button.interactable)
            onPointerUp?.Invoke();
    }
}
