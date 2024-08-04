using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : PlayerState
{
    public AirState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        anim.SetBool(AnimatorID.JumpID,true);
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if (PlayerInputSystem.MainInstance.PrimaryAttack)
        {
            stateMachine.ChangeState(stateMachine.PrimaryAttack);
        }
        if (xInput != 0)
        {
            SetVelocity(xInput * stateMachine.hero.moveSpeed, rb.velocity.y);
        }
        if (stateMachine.hero.IsGroundDetected())//´¥µØ
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        if(stateMachine.hero.IsWallDetected())//´¥Ç½
        {
            stateMachine.ChangeState(stateMachine.WallSlideState);
        }
    }
    public override void Exit()
    {
        base.Exit();
        anim.SetBool(AnimatorID.JumpID, false);
    }
}
