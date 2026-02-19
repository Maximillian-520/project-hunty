using UnityEngine;

public class FallState : BaseState
{
    [SerializeField] private Rigidbody2D rb;

    private float walkDirection = 0f;
    private float walkSpeed = 0f;

    public override void EnterState(){}
    public override void ExitState()
    {
        rb.linearVelocityY = 0f;
    }
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        rb.linearVelocityX = walkDirection * walkSpeed;
        rb.linearVelocityY -= PlayerData.GRAVITY_SPEED * Time.fixedDeltaTime;
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
