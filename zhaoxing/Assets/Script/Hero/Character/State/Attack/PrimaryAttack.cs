using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : PlayerState
{
    public PrimaryAttack(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        anim.CrossFadeInFixedTime("PrimaryAttack", 0, 0);
        TimerManager.MainInstance.GetTimer(0.1f, BusyForAttack);//1.修改移动时攻击时后可以移动的BUG
                                                                //2.但给了点时间模拟惯性可以动一点
    }

    public override void Exit()
    {
        base.Exit();
        triggerCalled = false;
    }
    
    public override void Update()
    {
        base.Update();
        if (triggerCalled)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
    public void BusyForAttack()
    {
        ZeroVelocity();
    }
}
