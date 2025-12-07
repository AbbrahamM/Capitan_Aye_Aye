using UnityEngine;
using UnityEngine.UI;

public class ScrollToSelected : MonoBehaviour
{
    public ScrollRect scrollView;
    public RectTransform contentPanel; // The parent of all scrollable items
    [SerializeField]
    float offset = 0.1f;
    public void ScrollToItem(GameObject selectedItem)
    {
        // Get content size and viewport width
        float contentWidth = contentPanel.rect.width;
        float viewportWidth = scrollView.viewport.rect.width;

        // Get the selected item’s anchored position within the content
        float itemX = Mathf.Abs(selectedItem.GetComponent<RectTransform>().anchoredPosition.x);

        // Calculate normalized scroll position with offset applied
        float normalizedX = Mathf.Clamp01((itemX / (contentWidth - viewportWidth)) + offset);

        // Apply scroll position
        scrollView.horizontalNormalizedPosition = normalizedX;


        Debug.Log("I selected " + selectedItem + " " + normalizedX);
    }
}

