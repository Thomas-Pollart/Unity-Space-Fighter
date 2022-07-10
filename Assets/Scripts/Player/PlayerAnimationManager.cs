using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private readonly int sideHashCode = Animator.StringToHash("Side");

    private void Update()
    {
        WingsAnimation();
    }

    private void WingsAnimation()
    {
        var playerInput = Input.GetAxis("Horizontal");
        var right = playerInput > 0;
        var left = playerInput < 0;

        if (left)
        {
            animator.SetInteger(sideHashCode, 1);
        }
        else if (right)
        {
            animator.SetInteger(sideHashCode, -1);
        }
        else
        {
            animator.SetInteger(sideHashCode, 0);
        }
    }
}
