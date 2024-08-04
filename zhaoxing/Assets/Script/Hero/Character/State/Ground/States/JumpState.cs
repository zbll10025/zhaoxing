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
        rb.velocity = new Vector2(rb.velocity.x, stateMachine.hero.jumpForce);//��y���ٶȸı�
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
        if (rb.velocity.y < 0)//���ٶ�С��0ʱ�л�ΪairState
        {
            stateMachine.ChangeState(stateMachine.AirState);//����˵��airState������˵��FallState
        }
        if (stateMachine.hero.IsWallDetected())
        {
            stateMachine.ChangeState(stateMachine.WallSlideState);
        }
    }
}
