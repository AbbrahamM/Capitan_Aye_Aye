using UnityEngine;

public class GMSetPosition : MonoBehaviour
{
    [SerializeField]
    Vector3 offset = Vector3.zero;

    [SerializeField]
    bool move = false;

    [SerializeField]
    float moveSpeed = 0.5f;

    Vector3 newPos = Vector3.zero;  
    public void SetPositionXFromCollider(Collider2D collision)
    {
        newPos = new Vector3(collision.transform.position.x,transform.position.y,transform.position.z) + offset;
        if (!move)
        {
            transform.position = newPos;    
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position,newPos)>0.01f && newPos!=Vector3.zero) { 
            transform.position = Vector3.MoveTowards(transform.position,newPos,moveSpeed);
        }
    }

    public void ResetPositoin()
    {
        newPos = Vector3.zero;
    }
}
