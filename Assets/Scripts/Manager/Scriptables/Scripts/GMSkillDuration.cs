using UnityEngine;
using UnityEngine.Events;

public class GMSkillDuration : MonoBehaviour
{
    [SerializeField]
    UnityEvent<float> getSkillDuration;
    [SerializeField]
    int skillIndex = 0;
    public void GetSkillDuration()
    {
        getSkillDuration?.Invoke(GameManager.instance.GAMEDIFICULTY.skillDuration[skillIndex]);
    }

    public void SetSkillDuration(float skillDuration)
    {
        GameManager.instance.GAMEDIFICULTY.skillDuration[skillIndex] = skillDuration;
    }
}
