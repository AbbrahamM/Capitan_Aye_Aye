using UnityEngine;
using UnityEngine.Events;

public class SPHitRate : MonoBehaviour
{
    [SerializeField]
    Vector3 offsetM = Vector3.zero;
    [SerializeField]
    LayerMask layers;
    [SerializeField]
    float distance = 2f;
    [SerializeField]
    UnityEvent<RaycastHit2D> alwwaysTouching;
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + offsetM, -transform.up, (distance * transform.localScale.y), layers);
        if (hit.collider != null)
        {
            alwwaysTouching?.Invoke(hit);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position + offsetM, -transform.up * (distance * transform.localScale.y));
    }
}
