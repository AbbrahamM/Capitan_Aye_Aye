using UnityEngine;
using UnityEngine.Events;

public class GMDistance : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer = null;
    [SerializeField]
    Transform parentTransform;
    private float totalDistance = 0f;
    private Camera mainCamera;
    private float spriteWidth;

    float leftEdgeOfCamera = 0;
    [SerializeField]
    UnityEvent<float> showDistance;
    void Start()
    {
        mainCamera = Camera.main;
        if(spriteRenderer == null)
            spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x; // Get the width of the sprite
        else
        {
            spriteWidth = spriteRenderer.bounds.size.x;
        }

        if(parentTransform == null)
            parentTransform = transform;


        leftEdgeOfCamera = mainCamera.ViewportToWorldPoint(mainCamera.transform.position).x;
    }

    void FixedUpdate()
    {
        if(!enabled)
            return;

        float leftEdgeOfSprite = parentTransform.position.x - spriteWidth / 2;

        if (leftEdgeOfSprite < leftEdgeOfCamera)
        {
            float outOfScreenAmount = leftEdgeOfCamera - leftEdgeOfSprite;
            outOfScreenAmount = Mathf.Clamp(outOfScreenAmount, 0, spriteWidth); // Ensure it doesn't exceed sprite width
            totalDistance = Mathf.Max(totalDistance, Mathf.Abs(parentTransform.position.x - (mainCamera.ViewportToWorldPoint(Vector3.one * 0.5f).x + spriteWidth / 2)));
            Debug.Log("Distance " + gameObject.name + " " + totalDistance);
            showDistance?.Invoke(totalDistance);
        }else
            totalDistance = 0f;
    }
}
