using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//д�¼�֮ǰ�ɣ�һ��Ҫע���һ�����ǣ�һ���¼������ж��ִ���ߣ������Ƕಥ��
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

    //C#�д�д��Сд���ݽṹ��ʲô����  object��Object

    //��׼д��
    //public EventMethod() => handle = GetHandle();

    //��һ������ôд������=>�������൱��ָ�������������÷�
    //public string EventMethod()  //���캯���ǲ����Դ����͵�
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

    public bool Add(EventMethod eventMethod)//���Բ��ӷ���ֵô��
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
