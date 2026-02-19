using UnityEngine;

public class WalkState : BaseState
{
    [SerializeField] private Rigidbody2D rb;

    private float walkDirection = 0f;
    private float walkSpeed = 0f;

    public override void EnterState(){}
    public override void ExitState(){}
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        rb.linearVelocityX = walkDirection * walkSpeed;
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
