using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class SPRFitToScreen : MonoBehaviour
{
    [SerializeField]
    enum AspectRatioMode { None, KeepX, KeepY, KeepOriginal }
    [SerializeField]
    AspectRatioMode aspectRatioMode = AspectRatioMode.KeepOriginal; // Select aspect ratio mode

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FitSpriteToScreen()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        Transform spriteTransform = transform;
        Camera mainCamera = Camera.main;

        float screenHeight = mainCamera.orthographicSize * 2f;
        float screenWidth = screenHeight * mainCamera.aspect;

        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        float scaleX = screenWidth / spriteSize.x;
        float scaleY = screenHeight / spriteSize.y;

        switch (aspectRatioMode)
        {
            case AspectRatioMode.KeepX:
                spriteTransform.localScale = new Vector3(scaleX, scaleX, 1f);
                break;
            case AspectRatioMode.KeepY:
                spriteTransform.localScale = new Vector3(scaleY, scaleY, 1f);
                break;
            case AspectRatioMode.KeepOriginal:
                float scale = Mathf.Min(scaleX, scaleY);
                spriteTransform.localScale = new Vector3(scale, scale, 1f);
                break;
            case AspectRatioMode.None:
            default:
                spriteTransform.localScale = new Vector3(scaleX, scaleY, 1f);
                break;
        }
    }
}
