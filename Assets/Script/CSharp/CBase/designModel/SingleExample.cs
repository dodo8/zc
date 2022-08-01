using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleExample
{
    private static SingleExample instance;
    private SingleExample() { }

    public static SingleExample getInstance()
    {
        if(instance == null)
        {
            instance = new SingleExample();
        }
        return instance;
    }
    private int HP;

    public int getHpNum()
    {
        return HP; 
    }
}
//饿汉式，线程安全
//基于 classloader 机制避免了多线程的同步问题，不过，instance 在类装载时就实例化，

public class Singleton
{
    //懒汉式与饿汉式的根本区别在与是否在类内方法外创建自己的对象。
    private static Singleton instance = new Singleton();
    private Singleton() { }
    public static Singleton getInstance()
    {
        return instance;
    }
}
