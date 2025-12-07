using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class SPRJump : MonoBehaviour
{
    [SerializeField]
    float dificultyFactor;
    Rigidbody2D rb2D;
    bool canAct = true;
    [SerializeField]
    float distance = 2f;
    [SerializeField]
    Vector3 offsetL = Vector3.zero;
    [SerializeField]
    Vector3 offsetR = Vector3.zero;
    [SerializeField]
    LayerMask layers;
    [SerializeField]
    float jumpCeilDistanceFactor = 5f;
    [SerializeField]
    int maxNumberOfJumps = 1;

    int currentJumps = 0;

    IEnumerator grounded;

    bool falling = false;
    bool jumping = false;
    

    float ceilDistance = 0;
    [SerializeField]
    UnityEvent<RaycastHit2D> toDoWhenGrounded;
    [SerializeField]
    UnityEvent toDoWhenFalling;
    [SerializeField]
    UnityEvent toDoTouchButtomFloor;
    private float gravityDown = 0;
    private float gravityUp = 0;
    private float jumpForce = 0;

    bool flying = false;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (rb2D != null && rb2D.linearVelocityY < 0f && enabled)
        {
            rb2D.gravityScale = Mathf.Clamp(gravityDown * (1 + dificultyFactor), gravityDown, gravityDown*1.5f); 
            toDoWhenFalling?.Invoke();
            falling = true;

        } else if(!falling && rb2D.linearVelocityY > 0)
        {
            rb2D.gravityScale = Mathf.Clamp(gravityUp * (1 + dificultyFactor),gravityUp, gravityUp*1.5f);
        }


        RaycastHit2D hitL = Physics2D.Raycast(transform.position + offsetL, -transform.up, (distance * transform.localScale.y), layers);

        RaycastHit2D hitR = Physics2D.Raycast(transform.position + offsetR, -transform.up, (distance * transform.localScale.y), layers);

        if ((hitL.collider != null && hitR.collider != null) && falling)
        {
            Debug.Log("I grounded ");

            canAct = true;
            rb2D.gravityScale = gravityDown * (1 + dificultyFactor);
            rb2D.linearVelocity = Vector2.zero;

            if (hitL.collider != null  && hitL.collider.gameObject.layer == 8)
                toDoTouchButtomFloor?.Invoke();

            if (hitR.collider != null && hitR.collider.gameObject.layer == 8)
                toDoTouchButtomFloor?.Invoke();

            currentJumps = 0;
            falling = false;
            jumping = false;
            toDoWhenGrounded?.Invoke(hitL);


        }
        else if (hitL.collider == null && hitR.collider == null)
        {
            jumping = true;
        }
    }

    public void Liana()
    {
        Debug.Log("I grounded ");
        canAct = true;
        currentJumps = 0;
        falling = false;
        jumping = false;
    }

    
    public void Jump()
    {
        Debug.Log("Jump " + canAct + " " + currentJumps + " " + maxNumberOfJumps);
        if (canAct && currentJumps < maxNumberOfJumps && !flying)
        {
            currentJumps++;
            falling |= false;
            rb2D.linearVelocity = Vector2.zero;
            rb2D.gravityScale = gravityUp;
            rb2D.AddForce(rb2D.transform.up * jumpForce * (1 + dificultyFactor), ForceMode2D.Impulse);

            if(currentJumps >= maxNumberOfJumps)
                canAct = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + offsetL, -transform.up * (distance * transform.localScale.y));

        Gizmos.DrawRay(transform.position + offsetR, -transform.up * (distance * transform.localScale.y));
    }

    public void SetUpGravityScale()
    {
        rb2D.gravityScale = gravityUp;
    }

    public float TOPDISTANCE
    {
        set { ceilDistance = value; }
    }
    public bool CANACT
    {
        set {  canAct = value; }
    }

    public int MAXJUMPS
    {
        set { maxNumberOfJumps = value; Debug.Log("Max number set " + value); }
    }

    /*public bool FALLING
    {
        set { canAct = value; }
    }*/

    public bool FLYING
    {
        set { flying = value; }
    }

    public float GRAVITYDOWN
    {
        set { gravityDown = value; }
    }

    public float GRAVITYUP
    {
        set { gravityUp = value; }
    }

    public float JUMPFORCE
    {
        set { jumpForce = value; Debug.Log("Set Jump Force " + value); }
    }

    public float DIFICULTYFACTOR
    {
        set { dificultyFactor = value; }
    }

    public void IncreaseGravity()
    {
    }
}
