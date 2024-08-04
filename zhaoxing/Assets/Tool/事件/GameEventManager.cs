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

        //添加事件的注册函数

        public void AddCall(Action action)
        {
            this.action += action;
        }

        //调用事件
        public void Call()
        {
            action?.Invoke();
        }

        //移除事件
        public void Remove(Action action)
        {
            this.action -= action;
        }
    }

    private Dictionary<string, IEventHelp> eventCenter = new Dictionary<string,IEventHelp >();
    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="action">事件</param>
    public void AddEventListening(string eventName,Action action)
    {
        if(eventCenter.TryGetValue(eventName, out var e))
        {
            (e as EventHelp)?.AddCall(action); 
        }
        else
        {
            //如果事件中心不存在叫这个名字的事件
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
            Debug.Print($"当前未找到{eventName}的事件,无法呼叫");
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
            Debug.Print($"当前未找到{eventName}的事件,无法删除");
        }
    }
}
