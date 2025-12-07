using UnityEngine;
using UnityEngine.Events;

public class SPRDetectScreenEdge : MonoBehaviour
{
    [SerializeField]
    enum EdgeToCross { Left, Right };

    [SerializeField]
    EdgeToCross edgeToCross = EdgeToCross.Left; // Select which edge to cross


    Camera mainCamera;

    float screenLeft = 0;
    float screenRight = 0;

    [SerializeField]
    UnityEvent<GameObject> toDoWhenOutOfScreen;

    [SerializeField]
    float edgeOfsset = 0;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        screenLeft = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect - edgeOfsset;
        screenRight = mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect + edgeOfsset;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!enabled)
            return;

        CheckAndReposition();
    }

    void CheckAndReposition()
    {
        // Check if this object is the first child
       
          

            // Check if the first child is going out of the screen
            if (edgeToCross == EdgeToCross.Left && spriteRenderer.transform.position.x + spriteRenderer.bounds.extents.x < screenLeft)
            {
            Debug.Log("Do i get here? ");
                toDoWhenOutOfScreen?.Invoke(spriteRenderer.gameObject);
            }
            else if (edgeToCross == EdgeToCross.Right && spriteRenderer.transform.position.x - spriteRenderer.bounds.extents.x > screenRight)
            {
                // Move the first child to the end of the row when crossing the right edge
                toDoWhenOutOfScreen?.Invoke(spriteRenderer.gameObject);

            }
    }
}
