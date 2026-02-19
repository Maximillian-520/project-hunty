using UnityEngine;

public class JumpState : BaseState
{
    [SerializeField] private Rigidbody2D rb;

    private float jumpSpeed = 0f;
    private float walkDirection = 0f;
    private float walkSpeed = 0f;

    public override void EnterState()
    {
        rb.linearVelocityY = jumpSpeed;
    }
    public override void ExitState(){}
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        rb.linearVelocityX = walkDirection * walkSpeed;
        rb.linearVelocityY -= PlayerData.GRAVITY_SPEED * Time.fixedDeltaTime;
    }

    public void SetJumpSpeed(float newJumpSpeed)
    {
        jumpSpeed = newJumpSpeed;
    }
    public void SetWalkDireciton(float newWalkDirection)
    {
        walkDirection = newWalkDirection;
    }
    public void SetWalkSpeed(float newWalkSpeed)
    {
        walkSpeed = newWalkSpeed;
    }
}
