using UnityEngine;

[CreateAssetMenu(fileName = "Destroy GameObject", menuName = "Scriptable Objects/Game Manager/Destroy GameObject")]
public class GMDestroyGameObject : ScriptableObject
{
    public void DestroyGameObjectFromTrigger(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }

    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void SetActiveFalse(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void SetActiveFalseFromTrigger(Collider2D collider)
    {
        Debug.Log("I am hitted " + collider.gameObject.name);
        collider.gameObject.SetActive(false);
    }
}
