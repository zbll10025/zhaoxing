using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpState : PlayerState
{
    float stateTimer;
    public WallJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.1f;//��ʱ������һ��ʱ������idle
        SetVelocity(7 * -facingDir, stateMachine.hero.jumpForce);//�����򷴷�����
        
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        stateTimer -= Time.deltaTime;
        if (xInput != 0)
        {
            SetVelocity(xInput * stateMachine.hero.moveSpeed, rb.velocity.y);
        }
        if (stateTimer < 0) 
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        if (stateMachine.hero.IsWallDetected())
        {
            stateMachine.ChangeState(stateMachine.WallSlideState);
        }
        if (stateMachine.hero.IsGroundDetected())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
