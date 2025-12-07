using System;
using UnityEngine;
using UnityEngine.Events;

public class SPMoveTowardsGravity : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float followSpeed = 5f;
    [SerializeField] float distanceToStop = 0.1f;
    [SerializeField] UnityEvent toDoWhenNoTarget;
    [SerializeField] Vector3 offset = Vector3.zero;
    [SerializeField] float gravity = -9.81f; // Simulated gravity force
    [SerializeField] float verticalVelocity = 0f; // Tracks falling speed
    [SerializeField] float raycastDistance = 0.1f; // Distance for ground detection
    [SerializeField] LayerMask groundLayer; // Define what is considered ground
    [SerializeField] Vector3 raycastOffset = Vector3.zero; // Offset for raycasting position

    private bool isGrounded = false;

    private void FixedUpdate()
    {
        if (!enabled)
            return;

        try
        {
            if (target == null)
            {
                toDoWhenNoTarget?.Invoke();
                return;
            }

            Vector3 rayOrigin = transform.position + raycastOffset; // Offset raycast position

            // Perform a raycast downward to check for ground
            isGrounded = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance, groundLayer);

            // Gravity effect stops if grounded
            if (!isGrounded)
                verticalVelocity += gravity * Time.fixedDeltaTime;
            else
                verticalVelocity = 0f; // Reset gravity when hitting ground

            Vector3 targetPosition = target.position + offset;
            float distance = Vector3.Distance(transform.position, targetPosition);

            if (distance > distanceToStop)
            {
                Vector3 direction = (targetPosition - transform.position).normalized;
                transform.position += new Vector3(direction.x * followSpeed * Time.fixedDeltaTime, verticalVelocity * Time.fixedDeltaTime);
            }
        }
        catch (NullReferenceException)
        {
            target = null;
            toDoWhenNoTarget?.Invoke();
        }
        catch (MissingReferenceException)
        {
            target = null;
            toDoWhenNoTarget?.Invoke();
        }
    }

    // Draw Gizmos for visualization in Scene View
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rayOrigin = transform.position + raycastOffset;
        Gizmos.DrawLine(rayOrigin, rayOrigin + Vector3.down * raycastDistance);
    }

    public void SetTargetFromTrigger(Collider2D other)
    {
        Debug.Log("Entered trigger: " + other.name);
        target = other.transform;
    }

    public void SetTargetNull()
    {
        target = null;
    }
}
