using UnityEngine;

public class SPRAddForce : MonoBehaviour
{

   
    [SerializeField]
    Vector2 backForce;

    [SerializeField]
    Vector2 addForce = Vector2.zero;

    public void AddForce(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rb2))
        {
            rb2.linearVelocity = Vector2.zero;
            rb2.AddForce(backForce*(1+SpriteManager.instance.DIFICULTYFACTOR), ForceMode2D.Impulse);
            Debug.Log("I do enter " + collision.gameObject.name);
        }
    }

    public void AddForceInverse(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rb2))
        {
            rb2.linearVelocity = Vector2.zero;
            rb2.AddForce(new Vector2(-backForce.x, backForce.y) * (1 + SpriteManager.instance.DIFICULTYFACTOR), ForceMode2D.Impulse);
            Debug.Log("I do enter in " + collision.gameObject.name);
        }
    }

    public void AddForce(GameObject ga)
    {
        if (ga.TryGetComponent(out Rigidbody2D rb2))
        {
            rb2.linearVelocity = Vector2.zero;
            rb2.AddForce(addForce, ForceMode2D.Impulse);
            Debug.Log("I do enter " + ga.name);
        }
    }

    public void AddForceInverse(GameObject ga)
    {
        if (ga.TryGetComponent(out Rigidbody2D rb2))
        {
            rb2.linearVelocity = Vector2.zero;
            rb2.AddForce(new Vector2(-addForce.x, addForce.y), ForceMode2D.Impulse);
            Debug.Log("I do enter in " + ga.name);
        }
    }

    public Vector2 BACKFORCE
    {
        set { backForce = value; addForce = value; }
    }
}
