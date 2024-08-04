using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChargeState : PlayerState
{
    public float chargeTime = 1f; // 蓄力时间
    public float maxCharge = 5f; // 最大蓄力值
    private float currentCharge = 0f; // 当前蓄力值

    float attackDir;
    public ChargeState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        anim.CrossFadeInFixedTime("Charge", 0, 0);
    }

    public override void Exit()
    {
        base.Exit();
        currentCharge = 0f;//重置蓄力值
        
    }
    public override void Update()
    {
        base.Update();
        ZeroVelocity();
        FlipController(PlayerInputSystem.MainInstance.PlayerXMove.x); //选择攻击方向
        // 增加当前蓄力值
        currentCharge += Time.deltaTime / chargeTime;
        currentCharge = Mathf.Clamp(currentCharge, 0f, maxCharge);
        // 计算攻击力量
        float attackPower = currentCharge * 10f;
        // 执行攻击逻辑....
        if (!PlayerInputSystem.MainInstance.Charge)
        {
            stateMachine.ChangeState(stateMachine.ChargeAttack1);
            anim.SetTrigger(AnimatorID.Charge1ID);
        }

    }
}
