using System;
using System.Collections.Generic;
using System.Diagnostics;
using zhou.Tool.Singleton;
public class GameEventManager : Singleton<GameEventManager>
{
    private interface IEventHelp
    {

    }
    private class EventHelp : IEventHelp
    {
        public Action action;
        public EventHelp(Action action)
        {
            this.action = action;
        }

        //����¼���ע�ắ��

        public void AddCall(Action action)
        {
            this.action += action;
        }

        //�����¼�
        public void Call()
        {
            action?.Invoke();
        }

        //�Ƴ��¼�
        public void Remove(Action action)
        {
            this.action -= action;
        }
    }

    private Dictionary<string, IEventHelp> eventCenter = new Dictionary<string,IEventHelp >();
    /// <summary>
    /// ����¼�����
    /// </summary>
    /// <param name="eventName">�¼�����</param>
    /// <param name="action">�¼�</param>
    public void AddEventListening(string eventName,Action action)
    {
        if(eventCenter.TryGetValue(eventName, out var e))
        {
            (e as EventHelp)?.AddCall(action); 
        }
        else
        {
            //����¼����Ĳ����ڽ�������ֵ��¼�
            eventCenter.Add(eventName, new EventHelp(action));
        }
    }
    public void CallEvent(string eventName)
    {
        if(eventCenter.TryGetValue(eventName,out var e))
        {
            (e as EventHelp)?.Call();
        }
        else
        {
            Debug.Print($"��ǰδ�ҵ�{eventName}���¼�,�޷�����");
        }
    }
    public void RemoveEvent(string eventName,Action action)
    {
        if(eventCenter.TryGetValue(eventName,out var e))
        {
            (e as EventHelp)?.Remove(action);
        }
        else
        {
            Debug.Print($"��ǰδ�ҵ�{eventName}���¼�,�޷�ɾ��");
        }
    }
}
