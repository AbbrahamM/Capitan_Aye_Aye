using UnityEngine;
using UnityEngine.Events;

public class GMEnemySetGet : MonoBehaviour
{
    [SerializeField] GMEnemyController gmEnemy;

    [Header("Set Events")]
    [SerializeField] UnityEvent<Vector2> onSetBackForce;
    [SerializeField] UnityEvent<float> onSetDificultyFactor;

    [Header("Get Events")]
    [SerializeField] UnityEvent<Vector2> onGetBackForce;
    [SerializeField] UnityEvent<float> onGetDificultyFactor;

    // Setter invokers
    public void SetBackForce(Vector2 newForce)
    {
        gmEnemy.GMEnemy.backForce = newForce;
        onSetBackForce?.Invoke(newForce);
    }

    public void SetDificultyFactor(float factor)
    {
        gmEnemy.GMEnemy.IncreaseFactor(factor);
        onSetDificultyFactor?.Invoke(factor);
    }

    // Getter invokers
    public void GetBackForce()
    {
        onGetBackForce?.Invoke(gmEnemy.GMEnemy.backForce);
    }

    public void GetDificultyFactor()
    {
        onGetDificultyFactor?.Invoke(gmEnemy.GMEnemy.dificultyFactor);
    }
}


