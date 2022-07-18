using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SortTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Student[] stu = {
            new Student("stu1", 40),
             new Student("stu2", 50),
             new Student("stu3", 46),
            new Student("stu4", 83),
             new Student("stu5", 93),
            new Student("stu6", 29)};
        BuSort<Student>.Sort<Student>(stu, Student.Compare);
        foreach(var item in stu)
        {
            Debug.Log(item.score.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
