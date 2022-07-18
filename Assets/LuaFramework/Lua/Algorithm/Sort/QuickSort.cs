//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[System.Serializable]
//public class InputParam
//{
//    public List<float> inputArray = new List<float>(); //如何改成public List<T>的形式
//    public float[] inputArray1 = new float[10];

//    // private void a(){
//    //     inputArray.Sort()
//    // }

//    //Action,func
//}

//public class QuikSort<T>  //快速排序
//{
//    private static void CmpAction(Action<T> action, T p1, T p2){
//        action(p1,p2)   
//    }

//    private static int CmpInt(int Left, int Right)
//    {
//        if((int)Left < (int)Right)
//            return -1;
//        else
//            return -2;
//    }

////CmpAction<int> (CmpInt,)

//    private static int CmpFloat(float Left, float Right)
//    {
//        if((float)Left < (float)Right)
//            return -1;
//        else
//            return -2;
//    }

//    CmpAction

//public void Sort(T[] array, CmpAction<T> cmp, int left, int right)
//    {
//        if(left >= right)
//        {
//            return;
//        }

//        var p = Partition(array, comparer, left, right);
//        Sort(array, comparer, left, p);
//        Sort(array, comparer, p + 1, right);
//    }

//    private int Partition(T[] array, IComparer<T> comparer, int left, int right)
//    {
//        var pivot = array[left];
//        var nleft = left;
//        var nright = right;
//        while(true)
//        {
//            while(comparer.Compare(array[nleft], pivot) < 0)
//            {
//                nleft++;
//            }

//            while(comparer.Compare(array[nright], pivot) > 0)
//            {
//                nright--;
//            }

//            if(nleft >= nright)
//            {
//                return nright;
//            }

//            var t = array[nleft];
//            array[nleft] = array[nright];
//            array[nright] = t;

//            nleft++;
//            nright--;
//        }
//    }
//}
