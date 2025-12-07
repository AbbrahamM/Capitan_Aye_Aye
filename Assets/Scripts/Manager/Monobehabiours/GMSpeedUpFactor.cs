using UnityEngine;
using UnityEngine.Events;

public class GMSpeedUpFactor : MonoBehaviour
{
    GMDificulty mDificulty;

    [SerializeField]
    UnityEvent<float> toDoWhenChangeSpeed;

    [SerializeField]
    UnityEvent<float> toDoWhenSpeedUp;

    [SerializeField]
    UnityEvent<float> showSpeed;
    private void Awake()
    {
        mDificulty = GameManager.instance.GAMEDIFICULTY;
    }


    public void ChangeSpeedUp(float speedUp)
    {
        mDificulty.speedUpFactor = speedUp;
        toDoWhenChangeSpeed.Invoke(speedUp);
    }

    public void ShowSpeed()
    {
        showSpeed?.Invoke(mDificulty.speedUpFactor);
    }

    public void SpeedUp()
    {
        toDoWhenSpeedUp?.Invoke(mDificulty.speedUpFactor);
    }
}
