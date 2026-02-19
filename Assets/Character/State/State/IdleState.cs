using UnityEngine;

public class IdleState : BaseState
{
    [SerializeField] private Rigidbody2D rb;

    public override void EnterState()
    {
        rb.linearVelocityX = 0;
    }
    public override void ExitState(){}
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
}
