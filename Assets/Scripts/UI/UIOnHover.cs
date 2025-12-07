using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    UnityEvent<PointerEventData> toDoPointeEnter;
    [SerializeField]
    UnityEvent<PointerEventData> toDoPointeExit;

    [SerializeField]
    UnityEvent<BaseEventData> toDoOnSelect;
    [SerializeField]
    UnityEvent<BaseEventData> toDoOnDiselect;
    [SerializeField]
    CanvasGroup canvasGroup = null;

    public void OnDeselect(BaseEventData eventData)
    {
        if (canvasGroup == null)
            toDoOnDiselect?.Invoke(eventData);
        else if (canvasGroup.interactable)
        {
            toDoOnDiselect?.Invoke(eventData);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(canvasGroup == null) 
            toDoPointeEnter?.Invoke(eventData);
        else if (canvasGroup.interactable)
        {
            toDoPointeEnter?.Invoke(eventData);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (canvasGroup == null)
            toDoPointeExit?.Invoke(eventData);   
        else if(canvasGroup.interactable)
            toDoPointeExit?.Invoke(eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (canvasGroup == null)
            toDoOnSelect?.Invoke(eventData);
        else if (canvasGroup.interactable)
            toDoOnSelect?.Invoke(eventData);
    }
}
