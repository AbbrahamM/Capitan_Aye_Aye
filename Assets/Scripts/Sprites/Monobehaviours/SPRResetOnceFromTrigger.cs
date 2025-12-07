using UnityEngine;

public class SPRResetOnceFromTrigger : MonoBehaviour
{
    public void ResetFromTrigger(Collider2D other)
    {
        if (SpriteManager.instance.ONLUONCE.Contains(other.gameObject.name))
        {
            Debug.Log("how many times do i enter here Reset " +  other.gameObject.name);
            SpriteManager.instance.ONLUONCE.Remove(other.gameObject.name);
        }
    }
}
