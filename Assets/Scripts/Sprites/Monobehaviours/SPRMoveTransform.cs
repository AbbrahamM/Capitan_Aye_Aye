using UnityEngine;
using UnityEngine.Events;
[ExecuteInEditMode]
public class SPRMoveTransform : MonoBehaviour
{
    [SerializeField]
    Vector3 direction = Vector3.zero;
    [SerializeField]
    float speed;

    Rigidbody2D rb2D;

    [SerializeField]
    UnityEvent toDoWhenChangeSpeed;

    float currentSpeed;

    float oldSpeed;
    bool canAct = false;

    private void Awake()
    {
        //currentSpeed = speed;
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canAct) {
            Debug.Log("Enter " + currentSpeed + " " + gameObject.name);
            rb2D.linearVelocity = currentSpeed * Time.fixedDeltaTime * direction;
        }

    }

    public void Stop()
    {
        rb2D.linearVelocity = Vector2.zero;
    }


    public void SetSpeed(float newSpeed)
    {
        toDoWhenChangeSpeed.Invoke();
        oldSpeed = currentSpeed;
        currentSpeed = newSpeed;
    }

    public void ReturnToOldSpeed()
    {

        toDoWhenChangeSpeed.Invoke();
        currentSpeed = oldSpeed;
    }

    public void ReturnOrigianalSpeed()
    {

        toDoWhenChangeSpeed.Invoke();
        currentSpeed = speed;
    }

    public bool CANACT
    {
        set { canAct = value; }
    } 
}
