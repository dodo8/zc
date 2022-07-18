using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//使用委托的形式来写
public static class BuSort<T> {

    public static void Sort<T>(T[] arr, Func<T, T, int> compare)
    {
        for(int i = 0; i<arr.Length - 1; i++)
        {
            for(int j = 0; j<arr.Length - i - 1; j++)
            {
                if(compare(arr[j], arr[j + 1]) > 0)
                {
                    T temp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }

}


