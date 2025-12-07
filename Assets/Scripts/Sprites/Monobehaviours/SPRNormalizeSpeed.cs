using UnityEngine;

public class SPRNormalizeSpeed : MonoBehaviour
{

    Rigidbody2D rb2D;
    [SerializeField]
    float speedOffset = 5f;

    Vector3 firstPosContact = Vector3.zero;

    float ceilDistance = 0;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(!enabled)
            return;
        Vector2 velocity = rb2D.linearVelocity;
        if (Mathf.Abs(velocity.y) > Mathf.Sign(rb2D.linearVelocityY) * ((ceilDistance + speedOffset) - Vector3.Distance(rb2D.position, firstPosContact)))
        {
            float clampedY = Mathf.Sign(rb2D.linearVelocityY) * ((ceilDistance + speedOffset) - Vector3.Distance(rb2D.position, firstPosContact)); // Keep direction, clamp magnitude
            rb2D.linearVelocityY = clampedY;


            Debug.Log("Max Linear Velocity " + ((ceilDistance + speedOffset)));
        }


        //rb2D.linearVelocityY = Mathf.Sign(rb2D.linearVelocityY) * 1;//((ceilDistance + speedOffset) - Vector3.Distance(rb2D.position, firstPosContact))
        rb2D.linearVelocityX = Mathf.Clamp(rb2D.linearVelocityX, 0, (ceilDistance + speedOffset) - Vector3.Distance(rb2D.position, firstPosContact));
    }

    public void GetContactaPosision(RaycastHit2D hit)
    {
        Debug.Log("I set it up");
        firstPosContact = hit.point;
    }

    public float TOPDISTANCE
    {
        set { ceilDistance = value; }
    }
}
