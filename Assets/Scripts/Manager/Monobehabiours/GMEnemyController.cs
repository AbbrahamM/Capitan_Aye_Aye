using UnityEngine;
using UnityEngine.Events;

public class GMEnemyController : MonoBehaviour
{
    [SerializeField]
    GMEnemy mEnemy;

    [SerializeField]
    UnityEvent<float> showDificulty;
    public GMEnemy GMEnemy { get { return mEnemy; } }

    public void ShowDificulty()
    {
        showDificulty?.Invoke(mEnemy.dificultyFactor);
    }
}
