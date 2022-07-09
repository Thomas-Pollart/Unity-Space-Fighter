using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

    public Animator PlayerAnimator;
    private int hashCode = Animator.StringToHash("Side");

    private void Update()
    {
        switch (Input.GetAxisRaw("Horizontal"))
        {
            case > 0:
                PlayerAnimator.SetInteger(hashCode, 1);
                break;
            case < 0:
                PlayerAnimator.SetInteger(hashCode, -1);
                break;
            default:
                PlayerAnimator.SetInteger(hashCode, 0);
                break;
        }
    }
}
