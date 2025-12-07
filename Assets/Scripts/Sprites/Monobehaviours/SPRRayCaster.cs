using UnityEngine;
using UnityEngine.Events;

public class SPRRayCaster : MonoBehaviour
{
    [SerializeField]
    LayerMask whatDetects;
    [SerializeField]
    Vector2 direction = Vector2.zero;
    [SerializeField]
    Vector2 offset = Vector2.zero;
    [SerializeField]
    float distance = 5;
    [SerializeField]
    UnityEvent<Collider2D> touching;
    [SerializeField]
    UnityEvent notTouching;

    private void FixedUpdate()
    {
        if(!enabled)
            return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)offset, direction, distance, whatDetects);
        if (hit.collider != null)
        {
            Debug.Log("What Detects touching " + gameObject.name);
            touching?.Invoke(hit.collider);
        }
        else {
            notTouching?.Invoke();
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + (Vector3)offset, direction * distance);
    }
}
