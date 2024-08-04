using System;
using UnityEngine;

public enum TimerState
{
    NOTWORKER,//����
    WORKERING,//����
    DONE//�������
}
public class GameTimer
{
    private float startTime;//��ʱʱ��
    private Action task;//��ʱ������ִ�е�����
    private bool isStopTimer;//�Ƿ�ֹͣ��ǰ��ʱ��
    private TimerState state;//��ǰ��ʱ��״̬
    public GameTimer()
    {
        ResetTimer();
    }
    //��ʼ��ʱ
    public void StartTimer(float time, Action task)
    {
        startTime = time;
        this.task = task;
        isStopTimer = false;
        state = TimerState.WORKERING;
    }
    //���¼�ʱ��
    public void UpdataTimer()
    {
        if (isStopTimer) return;
        startTime -= Time.deltaTime;
        if (startTime < 0f)
        {
            task?.Invoke();
            state = TimerState.DONE;
            isStopTimer = true;
        }
    }
    //ȷ����ʱ��״̬
    public TimerState GetTimerState() => state;
    //���ü�ʱ��
    public void ResetTimer()
    {
        startTime = 0;
        task = null;
        isStopTimer = false;
        state = TimerState.NOTWORKER;
    }
}
