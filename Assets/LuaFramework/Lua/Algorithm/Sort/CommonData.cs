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
        //��̬�����ͷǾ�̬����������
        //�Ǿ�̬����ֻ��ͨ��ʵ��������.���ã�
        //��̬������ͨ����.���ã����������������Ҳ��һ��
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
