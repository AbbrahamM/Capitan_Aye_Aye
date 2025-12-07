using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIScrollRectItemCentereBugger : MonoBehaviour
{
    [Header("References")]
    public ScrollRect scrollRect;

    [Header("Settings")]
    public float centerScale = 1.2f;
    public float sideScale = 0.8f;
    public float snapSpeed = 15f;
    public float centeringThreshold = 0.05f; // 5% of viewport width
    public float centerOffset = -150;

    private int currentCenterIndex = 0;
    private bool isDragging = false;
    private float itemWidth;
    private float itemSpacing;
    private float contentPadding;

    [SerializeField]
    UnityEvent<Transform> toDoWhenSelected;
    [SerializeField]
    EventSystem eventSystem;
    IEnumerator smoothCenter;
    void Start()
    {
        InitializeItems();
        scrollRect.onValueChanged.AddListener(OnScroll);

        Debug.Log("enter ");


        //CenterOnItem(0); // Start centered on first item
    }
    void InitializeItems()
    {
       

        // Get layout settings
        var layout = scrollRect.content.GetComponent<HorizontalLayoutGroup>();
        itemSpacing = layout.spacing;
        contentPadding = layout.padding.left;

       

        itemWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
    }

    void OnScroll(Vector2 pos)
    {
        if(isDragging) 
            UpdateCenterItem();

    }

    void UpdateCenterItem()
    {
        float closestDistance = float.MaxValue;
        int newCenterIndex = currentCenterIndex;

        // Find closest item to center
        for (int i = 0; i < transform.childCount; i++)
        {
            float distance = Mathf.Abs(GetDistanceToCenter(i));

            if (distance < closestDistance)
            {
                closestDistance = distance;
                newCenterIndex = i;
            }
        }

        // Only update if past threshold
        if (closestDistance < centeringThreshold * scrollRect.viewport.rect.width)
        {
            currentCenterIndex = newCenterIndex;
        }

        UpdateItemScales();
    }

    float GetDistanceToCenter(int index)
    {
        // Get item center in viewport space
        Vector3 itemCenter = scrollRect.viewport.InverseTransformPoint(transform.GetChild(index).position);
        return itemCenter.x + centerOffset;
    }

    void UpdateItemScales()
    {
        int topSortingOrder = 20; // Ensure the centered item is always on top.
        
        for (int i = 0; i < transform.childCount; i++)
        {
            float distance = Mathf.Abs(GetDistanceToCenter(i));
            float viewportWidth = scrollRect.viewport.rect.width;
            float normalizedDistance = Mathf.Clamp01(distance / (viewportWidth * 0.5f));

            float scale = Mathf.Lerp(centerScale, sideScale, normalizedDistance);
            transform.GetChild(i).localScale = Vector3.one * scale;

            // Adjust sorting order dynamically
            int sortingOrder = Mathf.RoundToInt(Mathf.Lerp(1, topSortingOrder, 1 - normalizedDistance));
            transform.GetChild(i).gameObject.GetComponent<Canvas>().sortingOrder = sortingOrder;

            if (scale >= 1.1f)
            {
                eventSystem.SetSelectedGameObject(transform.GetChild(i).gameObject);
            }
        }
    }



    public void OnBeginDrag()
    {
        isDragging = true;
        if(smoothCenter != null)
            StopCoroutine(smoothCenter);
    }

    public void OnEndDrag()
    {
        isDragging = false;
        CenterOnItem(currentCenterIndex);
    }

    public void CenterOnItem(int index)
    {
        if(smoothCenter != null)
        {
            currentCenterIndex = Mathf.Clamp(index, 0, transform.childCount - 2);

            smoothCenter = SmoothCenter();
            StartCoroutine(smoothCenter);
        }
    }

    IEnumerator SmoothCenter()
    {
        float startPos = scrollRect.horizontalNormalizedPosition;
        float targetPos = GetNormalizedPositionForItem(currentCenterIndex);
        float t = 0;

        while (t < 1f)
        {
            t += Time.unscaledDeltaTime * snapSpeed;
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(startPos, targetPos, t);
            UpdateItemScales();
            yield return null;
        }

        scrollRect.horizontalNormalizedPosition = targetPos+centerOffset;
        UpdateItemScales();
        smoothCenter = null;
    }

    float GetNormalizedPositionForItem(int index)
    {
        if (transform.childCount <= 1) return 0.65f;

        // Calculate exact position needed to center this item
        float itemCenter = contentPadding + (itemWidth + itemSpacing) * index + itemWidth * 0.65f;
        float viewportCenter = scrollRect.viewport.rect.width * 0.5f;
        float contentWidth = scrollRect.content.rect.width;

        return (itemCenter - viewportCenter) / (contentWidth - scrollRect.viewport.rect.width) -0.1f;
    }
}
