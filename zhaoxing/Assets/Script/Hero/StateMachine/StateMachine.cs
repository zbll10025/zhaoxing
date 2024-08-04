using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    public IState currentState;
    /// <summary>
    /// �л�״̬�Ľӿ�API
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(IState newState)
    {

        //����Ϊ����
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }
    /// <summary>
    /// ��������Ľӿ�API
    /// </summary>
    public void HandInput()
    {
        //ֻ����һ��״̬���������
        currentState?.HandInput();
    }
    /// <summary>
    /// ���·������߼��Ľӿ�API
    /// </summary>
    public void Update()
    {
        currentState?.Update();
    }
    public void AnimationFinishTrigger()
    {
        currentState?.AnimationFinishTrigger();
    }
}
