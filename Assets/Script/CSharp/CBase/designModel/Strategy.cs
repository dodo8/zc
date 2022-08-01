using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISkill
{
    public abstract void useSkill();
}

public interface AttackSkill : ISkill
{

}

public interface UpSkill : ISkill
{

}

public class chengjie : AttackSkill//伤害技能
{
    public void useSkill()
    {

    }
}

public class kuangbao : UpSkill //增益技能
{
    public void useSkill()
    {

    }
}


public abstract class Hero
{
    private String heroName;
    private ISkill iskill;  //策略模式//完全把这里当个接口，当个盲盒,以后可以万种变化 
    private int heroHurt;

    public void normalAttack()
    {

    }

    public void skill()
    {
        iskill.useSkill();
    }

    public String getHeroName()
    {
        return heroName;
    }

    public void setHeroName(String heroName)
    {
        this.heroName = heroName;
    }

    public void setIskill(ISkill iskill)
    {
        this.iskill = iskill;
    }
    public int getHeroHurt()
    {
        return heroHurt;
    }
    public void setHeroHurt(int heroHurt)
    {
        this.heroHurt = heroHurt;
    }
}


//定义一个英雄
public class xiaohei : Hero
{
    public xiaohei()
    {
        this.setHeroName("xiaohei");
    }
    public void normalAttack()
    {

    }
}

public class HeroTest
{
    Hero hero = new xiaohei();


    
    //  hero.setIskill(new chengjie());//面向接口编程的体现
    //hero.setIskill(new KuangBao());

    //  hero.normalAttack();

    //hero.skill();

}

public class SalaryContext
{
    private ISalaryStrategy _strategy;

    public SalaryContext(ISalaryStrategy strategy)
    {
        this._strategy = strategy;
    }

    public ISalaryStrategy ISalaryStrategy
    {
        get { return _strategy; }
        set { _strategy = value; }
    }

    public void GetSalary(double income)
    {
        _strategy.CalculateSalary(income);
    }
}

public interface ISalaryStrategy
{
    //工资计算
    void CalculateSalary(double income);
}

//程序员的工资--相当于具体策略角色ConcreteStrategyA
public class ProgrammerSalary : ISalaryStrategy
{
    public void CalculateSalary(double income)
    {
        Console.WriteLine("我的工资是：基本工资(" + income + ")底薪(" + 8000 + ")+加班费+项目奖金（10%）");
    }
}

//普通员工的工资---相当于具体策略角色ConcreteStrategyB
public class NormalPeopleSalary : ISalaryStrategy
{
    public void CalculateSalary(double income)
    {
        Console.WriteLine("我的工资是：基本工资(" + income + ")底薪(3000)+加班费");
    }
}

//CEO的工资---相当于具体策略角色ConcreteStrategyC
public sealed class CEOSalary : ISalaryStrategy
{
    public void CalculateSalary(double income)
    {
        Console.WriteLine("我的工资是：基本工资(" + income + ")底薪(20000)+项目奖金(20%)+公司股票");
    }
}


public class Server
{
    SalaryContext context = new SalaryContext(new NormalPeopleSalary());
    context.GetSalary(3000);

}



public class Client
{
    public static void Main(String[] args)
    {
        //普通员工的工资
        Console.WriteLine("【普通员工的工资】");
        SalaryContext context = new SalaryContext(new NormalPeopleSalary());
        context.GetSalary(3000);

        //程序员的工资
        Console.WriteLine("【程序员的工资】");
        context.ISalaryStrategy = new ProgrammerSalary();
        context.GetSalary(6000);

        //CEO的工资
        Console.WriteLine("【CEO的工资】");
        context.ISalaryStrategy = new CEOSalary();
        context.GetSalary(6000);

        Console.Read();
    }
}



