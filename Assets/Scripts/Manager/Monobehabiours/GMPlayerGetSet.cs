using UnityEngine;
using UnityEngine.Events;

public class GMPlayerGetSet : MonoBehaviour
{
    [SerializeField] GMPlayerController playerController;
    GMPlayer mPlayer;

    [Header("Float Events")]
    [SerializeField] UnityEvent<float> onJumpForce;
    [SerializeField] UnityEvent<float> onGravityUp;
    [SerializeField] UnityEvent<float> onGravityDown;
    [SerializeField] UnityEvent<float> onBananaCounter;
    [SerializeField] UnityEvent<float> onDificultyFactor;
    [SerializeField] UnityEvent<float> onDashSpeed;
    [SerializeField] UnityEvent<float> onDashDuration;
    [SerializeField] UnityEvent<float> onDashCooldown;

    private void Awake()
    {
        Debug.Log("Do i get here?");
        mPlayer = playerController.GMPlayer;
    }

    public void GetAll()
    {
        GetJumpForce();
        GetGravityUp();
        GetGravityDown();
        GetBananaCounter();
        GetDificultyFactor();
        GetDashSpeed();
        GetDashDuration();
        GetDashCooldown();
    }

    public void GetJumpForce() { 
        onJumpForce?.Invoke(mPlayer.jumpForce);
        Debug.Log("Get jump force ");
    }
    public void GetGravityUp() { onGravityUp?.Invoke(mPlayer.gravityUp); }
    public void GetGravityDown() { onGravityDown?.Invoke(mPlayer.gravityDown); }
    public void GetBananaCounter() { onBananaCounter?.Invoke(mPlayer.bananasCounter); }
    public void GetDificultyFactor() { onDificultyFactor?.Invoke(mPlayer.dificultyFactor); }
    public void GetDashSpeed() { onDashSpeed?.Invoke(mPlayer.dashSpeed); }
    public void GetDashDuration() { onDashDuration?.Invoke(mPlayer.dashDuratio); }
    public void GetDashCooldown() { onDashCooldown?.Invoke(mPlayer.dashCooldown); }
}
