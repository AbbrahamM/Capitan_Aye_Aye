using UnityEngine;
[RequireComponent(typeof(SpriteRenderer)),ExecuteInEditMode]
public class SPRSetAtSiblingsPosition : MonoBehaviour
{
    [SerializeField]
    float spacing = 0.1f; // Space between sprites

    private void OnEnable()
    {
        ArrangeSprites();
    }

    public void ArrangeSprites()
    {

        int childCount = transform.parent.childCount;
        if (childCount == 0)
        {
            Debug.LogWarning("No children found in the parent transform.");
            return;
        }

        float currentX = transform.parent.GetChild(0).position.x; // Start from first child's position
        SpriteRenderer firstSpriteRenderer = transform.parent.GetChild(0).GetComponent<SpriteRenderer>();
        if (firstSpriteRenderer != null)
        {
            currentX += firstSpriteRenderer.bounds.size.x / 2; // Adjust for first sprite's width
        }

        for (int i = 1; i < childCount; i++)
        {
            SpriteRenderer spriteRenderer = transform.parent.GetChild(i).GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                float spriteWidth = spriteRenderer.bounds.size.x;
                currentX += spriteWidth / 2 + spacing; // Move position to the right
                transform.parent.GetChild(i).position = new Vector3(currentX, transform.parent.GetChild(i).position.y, transform.parent.GetChild(i).position.z);
                currentX += spriteWidth / 2; // Update currentX for the next sprite
            }
        }
    }
}
