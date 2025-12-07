using UnityEngine;

public class SPRSetRbSettings : MonoBehaviour
{
    Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void FreezePositionConstrain(bool value)
    {
        if (value)
            rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        else
            rb2D.constraints = RigidbodyConstraints2D.None;

        rb2D.freezeRotation = true;
    }
}
