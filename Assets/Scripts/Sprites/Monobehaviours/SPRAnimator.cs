using UnityEngine;

public class SPRAnimator : MonoBehaviour
{
    Animator animator;
    int layer = 0;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetLayerWaight(float waight)
    {
        animator.SetLayerWeight(layer, waight);
    }
    public int Layer
    {
        get { return layer; }
        set { layer = value; }
    }
}
