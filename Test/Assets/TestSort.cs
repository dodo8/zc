using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class InputParam{
    public List<float> inputArray = new List<float>();
}

public interface IComparisonSorter<T>
{
    void Sort(T[] array,IComparer<T> comparer);
}

public class BubbleSorter<T>:IComparisonSorter<T>{ //冒泡排序
    public void Sort(T[] array,IComparer<T> comparer){
        for(var i = 0; i < array.Length - 1; i++){
            var waschanged = false;
            for (var j = 0; j < array.Length - i - 1; j++){  //最大的换到后面，后面一直是有序的
                if(comparer.Compare(array[j],array[j+1])>0){
                    var temp = array[j];
                    array[j] = array[j+1];
                    array[j+1] = temp;
                    waschanged = true;
                }
            }

            if(!waschanged){
                break;
            }

        }
    }
}

public class InsertionSorter<T>:IComparisonSorter<T>{   //插入排序
    public void Sort(T[] array,IComparer<T> comparer){
        for(int i = 1; i < array.Length; i++){
            var temp  = array[i];
            for(int j = i - 1;j >= 0;j--){
                if(comparer.Compare(array[j],temp)>0){//if(array[j] > temp) 
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
                else
                    break;    
            }
        }
    }
}

public class SelectionSorter<T>:IComparisonSorter<T>{//选择排序
    public void Sort(T[] array,IComparer<T> comparer){
        for (var i = 0; i < array.Length-1; i++)
        {
            var imin = i;
            for(var j = i + 1; j < array.Length; j++ )
            {
                if (comparer.Compare(array[j],array[imin])<0)
                {
                    imin = j;
                }
            }

            var t = array[imin];
            array[imin] = array[i];
            array[i] = t;
        } 

    }
}

public class QuikSort<T>  //快速排序
{
    public void Sort(T[] array, IComparer<T> comparer, int left, int right) {
        if(left >= right) {
            return;
        }
        var p = Partition(array,comparer,left,right);
        Sort(array, comparer, left, p);
        Sort(array, comparer, p, right);
    }

    private int Partition(T[] array, IComparer<T> comparer, int left, int right)
    {
        int pivot = left;
        //var pivot = SelectPivot(array, comparer, left, right);
        int nleft = left;
        int nright = right;
        while(true)
        {
            //array[i] < arr[pivot]
            while(comparer.Compare(array[nleft], array[pivot]) < 0)
            {
                nleft++;
            }

            while(comparer.Compare(array[nleft], array[pivot]) < 0)
            {
                nright--;
            }

            if(nleft >= right)
            {  //排序好了将剩下的right索引返回
                return nright;
            }

            var t = array[nleft];
            array[nleft] = array[nright];
            array[nright] = t;

            nleft++;
            nright++;
        }
    }
}

public class MergerSort<T> :IComparisonSorter<T> {//归并排序
    public void Sort(T[] array, IComparer<T> comparer) {
        if(array.Length <= 1) {  //分到最细
            return;
        }

        var (left, right) = Split(array);
        Sort(left, comparer);
        Sort(right, comparer);
        Merge(array, left, right, comparer);
    }

    public static void Merge(T[] array, T[] left, T[] right, IComparer<T> comparer) {
        var mainIndex = 0;
        var leftIndex = 0;
        var rightIndex = 0;

        while(leftIndex < left.Length && rightIndex < right.Length)
        {
            var compResult = comparer.Compare(left[leftIndex],right[rightIndex]);
            array[mainIndex++] = compResult <=0? left[leftIndex++] : right[rightIndex++];
        }

        while(leftIndex < left.Length) {
            array[mainIndex++] = left[leftIndex++];
        }

        while(rightIndex < right.Length) {
            array[mainIndex++] = right[rightIndex++];
        }
    }

    private static (T[] left, T[] right) Split(T[] array) {
        var mid = array.Length / 2;
        return (array.Take(mid).ToArray(), array.Skip(mid).ToArray());
    }
}

public class HeapSorter<T> {  //堆排序
    private static void HeapSort(IList<T> data, IComparer<T> comparer) {
        var heapsize = data.Count;
        for(var p = (heapsize-1)/2;p>=0;p--) {
            MakeHeap(data,heapsize,p,comparer);
        }

        for(var i = data.Count-1;i>0;i--) {
            var temp = data[i];
            data[i] = data[0];
            data[0] = temp;

            heapsize--;
            MakeHeap(data,heapsize,0,comparer);
        }
    }

    private static void MakeHeap(IList<T> input, int heapSize, int index, IComparer<T> comparer) { 
    
    
    
    }


}


//归并排序链表方法：

//链表方法：
/*
public class MergeSort<T> {
    public static List<T> Sort(List<T> lst, IComparer<T> comparer)
    {
        if(lst.Count <= 1)
        {
            return lst;
        }
        int mid = lst.Count/2;
        List<T> left = new List<T>();
        List<T> right = new List<T>();

        for(int i = 0; i < mid; i++)
            left.Add(lst[i]);
        for(int j = mid; j < lst.Count; j++)
            right.Add(lst[j]);
        left = Sort(left, comparer);
        right = Sort(right, comparer);
        return merge(left, right, comparer);
    }

    public static List<T> merge(List<T> left, List<T> right,IComparer<T> comparer) {
        List<T> temp = new List<T>();
        while(left.Count > 0 && right.Count > 0) {
            if(comparer.Compare(left[0], right[0])<0)
            {
                temp.Add(left[0]);
                left.RemoveAt(0);
            }
            else {
                temp.Add(right[0]);
                right.RemoveAt(0);
            }

            if(left.Count > 0) {
                for(int i = 0; i < left.Count; i++)
                {
                    temp.Add(left[i]);
                }
            }
            if(right.Count > 0)
            {
                for(int i = 0; i < right.Count; i++)
                    temp.Add(right[i]);
            }
        }
        return temp;
    }
}
*/

//其他java版本：
/*
public class MergeSort {
    public static void main(String []args){
        int []arr = {9,8,7,6,5,4,3,2,1};
        sort(arr);
        System.out.println(Arrays.toString(arr));
    }
    public static void sort(int []arr){
        int []temp = new int[arr.length];//在排序前，先建好一个长度等于原数组长度的临时数组，避免递归中频繁开辟空间
        sort(arr,0,arr.length-1,temp);
    }
    private static void sort(int[] arr,int left,int right,int []temp){
        if(left<right){
            int mid = (left+right)/2;
            sort(arr,left,mid,temp);//左边归并排序，使得左子序列有序
            sort(arr,mid+1,right,temp);//右边归并排序，使得右子序列有序
            merge(arr,left,mid,right,temp);//将两个有序子数组合并操作
        }
    }
    private static void merge(int[] arr,int left,int mid,int right,int[] temp){
        int i = left;//左序列指针
        int j = mid+1;//右序列指针
        int t = 0;//临时数组指针
        while (i<=mid && j<=right){
            if(arr[i]<=arr[j]){
                temp[t++] = arr[i++];
            }else {
                temp[t++] = arr[j++];
            }
        }
        while(i<=mid){//将左边剩余元素填充进temp中
            temp[t++] = arr[i++];
        }
        while(j<=right){//将右序列剩余元素填充进temp中
            temp[t++] = arr[j++];
        }
        t = 0;
        //将temp中的元素全部拷贝到原数组中
        while(left <= right){
            arr[left++] = temp[t++];
        }
    }
}
*/



//链表方法：





public class TestSort : MonoBehaviour
{
    // Start is called before the first frame update
    public InputParam inputparam = new InputParam();
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


//其他参考资料

//https://blog.csdn.net/weixin_46215617/article/details/108230953
