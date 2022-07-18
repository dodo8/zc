using System.Collections;
using System.Collections.Generic;


public class Student
{//prop
    public string name { get; private set; }
    public int score { get; private set; }

    public Student(string name, int score)
    {//ctor
        this.name = name;
        this.score = score;
    }

    static public int Compare(Student stu1, Student stu2)
    {
        //静态方法和非静态方法的区别
        //非静态方法只能通过实例化对象.调用，
        //静态方法可通过类.调用，因而二者生命周期也不一样
        if(stu1.score < stu2.score)
        {
            return -1;
        }
        else if(stu1.score > stu2.score)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}

public class CommonData 
{



}
