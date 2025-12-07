using UnityEngine;
using UnityEngine.Events;

public class GMDificultySetGet : MonoBehaviour
{
    GMDificulty GMDificulty;

    [SerializeField]
    UnityEvent<float> getFloatData;
    private void Awake()
    {
        GMDificulty = GameManager.instance.GAMEDIFICULTY;
    }


    public void GetBackgroundSpeed()
    {
        getFloatData?.Invoke(GMDificulty.BackgroundSpeed);
    }

    public void GetDificultyFactor()
    {
        getFloatData?.Invoke(GMDificulty.dificultyFactor);
    }

    public void GetSpeedUpFactor()
    {
        getFloatData?.Invoke(GMDificulty.speedUpFactor);
    }

    public void GetSkillDuration(int index)
    {
        getFloatData?.Invoke(GMDificulty.skillDuration[index]);
    }
}
