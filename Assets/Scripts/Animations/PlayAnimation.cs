using UnityEngine;

[CreateAssetMenu(fileName = "PlayvAnimation", menuName = "Scriptable Objects/Animations/Play Animation")]
public class PlayAnimation : ScriptableObject
{
    [SerializeField]
    string animatonName = "";
    public void PlayAnimationByName(GameObject gameObject)
    {
        gameObject.GetComponent<Animator>().Play(animatonName);
    }
}
