using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChargeState : PlayerState
{
    public float chargeTime = 1f; // ����ʱ��
    public float maxCharge = 5f; // �������ֵ
    private float currentCharge = 0f; // ��ǰ����ֵ

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
        currentCharge = 0f;//��������ֵ
        
    }
    public override void Update()
    {
        base.Update();
        ZeroVelocity();
        FlipController(PlayerInputSystem.MainInstance.PlayerXMove.x); //ѡ�񹥻�����
        // ���ӵ�ǰ����ֵ
        currentCharge += Time.deltaTime / chargeTime;
        currentCharge = Mathf.Clamp(currentCharge, 0f, maxCharge);
        // ���㹥������
        float attackPower = currentCharge * 10f;
        // ִ�й����߼�....
        if (!PlayerInputSystem.MainInstance.Charge)
        {
            stateMachine.ChangeState(stateMachine.ChargeAttack1);
            anim.SetTrigger(AnimatorID.Charge1ID);
        }

    }
}
