using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float moveInput = 0f;
    public bool runInput = false;
    public bool jumpInput = false;

    public void SetMoveInput(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<float>();
    }

    public void SetRunInput(InputAction.CallbackContext ctx)
    {
        runInput = ctx.performed;
    }

    public void SetJumpInput(InputAction.CallbackContext ctx)
    {
        jumpInput = ctx.performed;
    }
}
