using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestSort : MonoBehaviour
{
    // Start is called before the first frame update
    // public InputParam inputparam = new InputParam();
    public InputParam inputparam;
    public Testcompare Testcompare = new Testcompare() ;
    void Start()
    {
        QuikSort<float> SortTest = new QuikSort<float>();   //改成选择，按钮， 输出
        SortTest.Sort(inputparam.inputArray1, Testcompare, 0, inputparam.inputArray1.Length - 1);

        for(int i = 0; i < inputparam.inputArray1.Length; i++)
        {
            Debug.Log(inputparam.inputArray1[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}