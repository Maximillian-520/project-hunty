using UnityEngine;

public class RunState : BaseState
{
    [SerializeField] private Rigidbody2D rb;

    private float runDirection = 0f;
    private float runSpeed = 0f;

    public override void EnterState(){}
    public override void ExitState(){}
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        rb.linearVelocityX = runDirection * runSpeed;
    }

    public void SetRunDireciton(float newRunDirection)
    {
        runDirection = newRunDirection;
    }
    public void SetRunSpeed(float newRunSpeed)
    {
        runSpeed = newRunSpeed;
    }
}
