using UnityEngine;
using UnityEngine.Events;

public class GMPlayerDashManager : MonoBehaviour
{
    [SerializeField]
    GMPlayerController controller;

    [SerializeField]
    public UnityEvent<float> setUpdashCooldown;
    private void Start()
    {
        setUpdashCooldown?.Invoke(controller.GMPlayer.dashCooldown);
    }

    public void ResetDashCoolDown()
    {
        setUpdashCooldown?.Invoke(controller.GMPlayer.dashCooldown);
    }
}
