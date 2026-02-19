using System;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float currentFacingDirection = 1.0f;

    public void UpdateFacingDirection(float facingDirection)
    {
        // Check if valid
        if(Math.Sign(facingDirection) == 0) return;
        if(currentFacingDirection == facingDirection) return;
        // Change direction
        transform.localScale = new Vector3(
            transform.localScale.x * -1,
            transform.localScale.y,
            transform.localScale.z
        );
        currentFacingDirection = facingDirection;
    }

    public void UpdateWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void UpdateRunning(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }
}
