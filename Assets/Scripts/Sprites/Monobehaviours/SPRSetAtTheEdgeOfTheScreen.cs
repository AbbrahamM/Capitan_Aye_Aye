using UnityEngine;
[RequireComponent(typeof(SpriteRenderer)),ExecuteInEditMode]
public class SPRSetAtTheEdgeOfTheScreen : MonoBehaviour
{
    [SerializeField]
    enum ScreenEdge { Left, Right, Top, Bottom };
    [SerializeField]
    ScreenEdge edge = ScreenEdge.Left;
    [SerializeField]
    public float offset = 0f;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
#if UNITY_EDITOR
        PositionAtEdge();
#endif
    }

    void PositionAtEdge()
    {
       
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        Camera mainCamera = Camera.main;
        float screenHeight = mainCamera.orthographicSize * 2f;
        float screenWidth = screenHeight * mainCamera.aspect;

        Vector3 newPosition = transform.position;
        float halfSpriteWidth = spriteRenderer.bounds.extents.x;
        float halfSpriteHeight = spriteRenderer.bounds.extents.y;

        switch (edge)
        {
            case ScreenEdge.Left:
                newPosition.x = -screenWidth / 2 + halfSpriteWidth + offset;
                break;
            case ScreenEdge.Right:
                newPosition.x = screenWidth / 2 - halfSpriteWidth - offset;
                break;
            case ScreenEdge.Top:
                newPosition.y = screenHeight / 2 - halfSpriteHeight - offset;
                break;
            case ScreenEdge.Bottom:
                newPosition.y = -screenHeight / 2 + halfSpriteHeight + offset;
                break;
        }

        transform.position = newPosition;
    }
}
