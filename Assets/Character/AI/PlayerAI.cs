using UnityEngine;

public class PlayerAI : BaseAI
{
    [SerializeField] private StateController stateController;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerSprite playerSprite;
    [SerializeField] private GroundCheck groundCheck;

    [SerializeField] private WalkState walkState;
    [SerializeField] private RunState runState;
    [SerializeField] private JumpState jumpState;
    [SerializeField] private FallState fallState;

    int currentJumpAmount = 0;

    public override void UpdateCondition()
    {
        string currentState = stateController.GetCurrentStateKey();
        if(currentState == "idle")
        {
            // Check walk
            if(playerInput.moveInput != 0) ChangeToWalk();
            // Check jump
            else if(groundCheck.isOnGround && playerInput.jumpInput) ChangeToJump();
            // Check fall
            else if(!groundCheck.isOnGround){stateController.ChangeState("fall");}
        }
        if(currentState == "walk")
        {
            // Update walk
            walkState.SetWalkDireciton(playerInput.moveInput);
            walkState.SetWalkSpeed(playerData.walkSpeed);
            playerSprite.UpdateFacingDirection(playerInput.moveInput);
            // Check idle
            if(playerInput.moveInput == 0) ChangeToIdle();
            // Check run
            else if(playerInput.runInput) ChangeToRun();
            // Check jump
            else if(groundCheck.isOnGround && playerInput.jumpInput) ChangeToJump();
            // Check fall
            else if(!groundCheck.isOnGround) ChangeToFall();
        }
        if(currentState == "run")
        {
            // Update run
            runState.SetRunDireciton(playerInput.moveInput);
            runState.SetRunSpeed(playerData.runSpeed);
            playerSprite.UpdateFacingDirection(playerInput.moveInput);
            // Check idle
            if(playerInput.moveInput == 0) ChangeToIdle();
            // Check run
            else if(!playerInput.runInput) ChangeToWalk();
            // Check jump
            else if(groundCheck.isOnGround && playerInput.jumpInput) ChangeToJump();
            // Check fall
            else if(!groundCheck.isOnGround) ChangeToFall();
        }
        if(currentState == "jump")
        {
            // Update jump
            jumpState.SetWalkDireciton(playerInput.moveInput);
            jumpState.SetWalkSpeed(playerData.moveSpeed);
            // Check fall
            if(rb.linearVelocityY < 0) ChangeToFall();
            // Check idle
            else if(groundCheck.isOnGround) ChangeToIdle();
        }
        if(currentState == "fall")
        {
            // Update fall
            fallState.SetWalkDireciton(playerInput.moveInput);
            fallState.SetWalkSpeed(playerData.moveSpeed);
            // Check walk
            if(groundCheck.isOnGround && playerInput.moveInput != 0) ChangeToWalk();
            // Check idle
            else if(groundCheck.isOnGround) ChangeToIdle();
            // Check jump
            else if(playerInput.jumpInput && currentJumpAmount < playerData.maxJumpAmount) ChangeToJump();
        }
    }

    private void ChangeToIdle()
    {
        // Change state
        stateController.ChangeState("idle");
        // Reset jump
        currentJumpAmount = 0;
        // Update animation
        playerSprite.UpdateWalking(false);
        playerSprite.UpdateRunning(false);
    }

    private void ChangeToWalk()
    {
        // Change state
        stateController.ChangeState("walk");
        // Reset jump
        currentJumpAmount = 0;
        // Update animation
        playerSprite.UpdateWalking(true);
        playerSprite.UpdateRunning(false);
    }

    private void ChangeToRun()
    {
        // Change state
        stateController.ChangeState("run");
        // Reset jump
        currentJumpAmount = 0;
        // Update animation
        playerSprite.UpdateRunning(true);
    }

    private void ChangeToJump()
    {
        // Change state
        jumpState.SetJumpSpeed(playerData.jumpSpeed);
        jumpState.SetWalkDireciton(playerInput.moveInput);
        jumpState.SetWalkSpeed(playerData.moveSpeed);
        stateController.ChangeState("jump");
        currentJumpAmount++;
    }

    private void ChangeToFall()
    {
        // Change state
        fallState.SetWalkDireciton(playerInput.moveInput);
        fallState.SetWalkSpeed(playerData.moveSpeed);
        stateController.ChangeState("fall");
    }
}
