using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerState
{
    public JumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        anim.SetBool(AnimatorID.JumpID, true);
        rb.velocity = new Vector2(rb.velocity.x, stateMachine.hero.jumpForce);//将y轴速度改变
    }
    public override void Exit()
    {
        base.Exit();
        
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
        if (rb.velocity.y < 0)//当速度小于0时切换为airState
        {
            stateMachine.ChangeState(stateMachine.AirState);//与其说是airState，不如说是FallState
        }
        if (stateMachine.hero.IsWallDetected())
        {
            stateMachine.ChangeState(stateMachine.WallSlideState);
        }
    }
}
