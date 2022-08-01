using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//写事件之前吧，一定要注意的一个点是，一个事件可能有多个执行者，所以是多播的
/*
public abstract class EventMethod
{
    private string handle;
    private Action action;

    public string Handle
    {
        get { return handle; }
    }

    protected virtual string GetHandle()
    {
        return GetType().Name;
    }

    //C#中大写和小写数据结构又什么区别  object和Object

    //标准写法
    //public EventMethod() => handle = GetHandle();

    //第一次想这么写，但是=>在这里相当于指定匿名函数的用法
    //public string EventMethod()  //构造函数是不可以带类型的
    //{
    //    handle = GetHandle();
    //    return handle;
    //}

    public EventMethod(Action action)
    {
        handle = GetHandle();
        this.action = action;
    }

    public void Awake(params object[] parameters)
    {
        action?.Invoke();
    }
}


public class EventSystem
{

    private readonly Dictionary<string,HashSet<EventMethod>> events = new Dictionary<string, HashSet<EventMethod>>();

    public bool Add(EventMethod eventMethod)//可以不接返回值么？
    {
        if(!events.ContainsKey(eventMethod.Handle))
            events.Add(eventMethod.Handle, new HashSet<EventMethod>());
        if(events.TryGetValue(eventMethod.Handle, out var hashSet)) {
            hashSet.Add(eventMethod);
        }
        //HashSet<EventMethod> hashSet;
        //if(events.TryGetValue(eventMethod.Handle, out hashSet)) {
        //      hashSet.Add(eventMethod);
        //}
        return false;
    }

    public void Remove(EventMethod eventMethod) {
        if(!events.TryGetValue(eventMethod.Handle, out var hashSet)) {
            hashSet.Remove(eventMethod);
            if(hashSet.Count <= 0)
                events.Remove(eventMethod.Handle);
        }
    }

    public void Awake(string handle, params object[] parameters) {
        if(events.TryGetValue(handle, out var value))
        {
            foreach(var item in value)
               item.Awake(parameters);
        }
    }

}
*/




public class EventSystem
{
    public delegate void EventDelegate(params object[] parameters);
    private readonly Dictionary<string,HashSet<EventDelegate>> events = new Dictionary<string, HashSet<EventDelegate>>();

    public void Add(string eventId, EventDelegate action)//可以不接返回值么？
    {
        if(!events.ContainsKey(eventId))
            events.Add(eventId, new HashSet<EventDelegate>());
        if(events.TryGetValue(eventId, out var hashSet))
        {
            hashSet.Add(action);
        }
        //HashSet<EventMethod> hashSet;
        //if(events.TryGetValue(eventMethod.Handle, out hashSet)) {
        //      hashSet.Add(eventMethod);
        //}
    }

    public void Remove(string eventId, EventDelegate action)
    {
        if(!events.TryGetValue(eventId, out var hashSet))
        {
            hashSet.Remove(action);
            if(hashSet.Count <= 0)
                events.Remove(eventId);
        }
    }

    public void Trigger(string eventId, params object[] parameters)
    {

        if(events.TryGetValue(eventId, out var value))
        {
            foreach(var item in value)
            {
                item?.Invoke(parameters);
            }
        }
    }
}

public class UnityEventSystemTest: MonoBehaviour
{
    void Start()
    {
        EventSystem.Add();
    }

    public void BindEvent() {

    }

    public void UnBindEvent()
    {

    }

    public void execute()
    {
        
    }



}



