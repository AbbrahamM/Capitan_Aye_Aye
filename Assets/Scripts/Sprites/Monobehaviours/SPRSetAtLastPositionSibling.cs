using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(SpriteRenderer))]
public class SPRSetAtLastPositionSibling : MonoBehaviour
{
    [SerializeField]
    enum EdgeToCross { Left, Right };

    [SerializeField]
    EdgeToCross edgeToCross = EdgeToCross.Left; // Select which edge to cross

    [SerializeField]
    float spacing = 0.1f; // Space between sprites

    Camera mainCamera;

    float screenLeft = 0;
    float screenRight = 0;

    [SerializeField]
    UnityEvent<GameObject> toDoWhenOutOfScreen;

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        screenLeft = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect;
        screenRight = mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect;
    }

    /*void Update()
    {
        CheckAndReposition();
    }*/


    private void OnBecameInvisible()
    {
        CheckAndReposition();
    }

    void CheckAndReposition()
    {
        // Check if this object is the first child
        if (transform.GetSiblingIndex() == 0)
        {
            Transform firstChild = transform;
            Transform lastChild = transform.parent.GetChild(transform.parent.childCount - 1);

            SpriteRenderer firstChildRenderer = firstChild.GetComponent<SpriteRenderer>();
            SpriteRenderer lastChildRenderer = lastChild.GetComponent<SpriteRenderer>();

            // Check if the first child is going out of the screen
            if (edgeToCross == EdgeToCross.Left && firstChild.position.x + firstChildRenderer.bounds.extents.x < screenLeft)
            {
                // Move the first child to the end of the row
                Debug.Log("Who enters here? " + firstChild.name);
                toDoWhenOutOfScreen?.Invoke(firstChild.gameObject);

                // Calculate new position for the first child
                Vector3 newPosition = lastChild.position;
                newPosition.x += lastChildRenderer.bounds.size.x + spacing;

                firstChild.position = newPosition;
                firstChild.SetSiblingIndex(transform.parent.childCount - 1); // Move it to the last position
            }
            else if (edgeToCross == EdgeToCross.Right && firstChild.position.x - firstChildRenderer.bounds.extents.x > screenRight)
            {
                // Move the first child to the end of the row when crossing the right edge
                toDoWhenOutOfScreen?.Invoke(firstChild.gameObject);

                Vector3 newPosition = lastChild.position;
                newPosition.x -= lastChildRenderer.bounds.size.x + spacing;

                firstChild.position = newPosition;
                firstChild.SetSiblingIndex(transform.parent.childCount - 1); // Move it to the last position
            }
        }
    }
}
