using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class InputParam{
    public List<float> inputArray = new List<float>(); //如何改成public List<T>的形式
    public float[] inputArray1 = new float[10];

    // private void a(){
    //     inputArray.Sort()
    // }

//Action,func
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
    public void Sort(T[] array, IComparer<T> comparer, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        var p = Partition(array, comparer, left, right);
        Sort(array, comparer, left, p);
        Sort(array, comparer, p + 1, right);
    }

    private int Partition(T[] array, IComparer<T> comparer, int left, int right)
    {
        var pivot = array[left];
        var nleft = left;
        var nright = right;
        while (true)
        {
            while (comparer.Compare(array[nleft], pivot) < 0)
            {
                nleft++;
            }

            while (comparer.Compare(array[nright], pivot) > 0)
            {
                nright--;
            }

            if (nleft >= nright)
            {
                return nright;
            }

            var t = array[nleft];
            array[nleft] = array[nright];
            array[nright] = t;

            nleft++;
            nright--;
        }
    }
}



//归并排序链表方法：

//链表方法：
/*
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

*/

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

//堆排序
public class HeapSorter<T> {
    private static void HeapSort(int[] arr)
    {
        int vCount = arr.Length;
        int[] tempKey = new int[vCount + 1];
        // 元素索引从1开始
        for(int i = 0; i < vCount; i++)
        {
            tempKey[i + 1] = arr[i];
        }
        // 初始数据建堆（从含最后一个结点的子树开始构建，依次向前，形成整个二叉堆）
        for(int i = vCount / 2; i >= 1; i--)
        {
            Restore(tempKey, i, vCount);
        }
        // 不断输出堆顶元素、重构堆，进行排序
        for(int i = vCount; i > 1; i--)
        {
            int temp = tempKey[i];
            tempKey[i] = tempKey[1];
            tempKey[1] = temp;
            Restore(tempKey, 1, i - 1);
        }
        //排序结果
        for(int i = 0; i < vCount; i++)
        {
            arr[i] = tempKey[i + 1];
        }
    }

    private static void Restore(int[] arr, int rootNode, int nodeCount)
    {
        while(rootNode <= nodeCount / 2) // 保证根结点有子树
        {
            //找出左右儿子的最大值
            int m = (2 * rootNode + 1 <= nodeCount && arr[2 * rootNode + 1] > arr[2 * rootNode]) ? 2 * rootNode + 1 : 2 * rootNode;
            if(arr[m] > arr[rootNode])
            {
                int temp = arr[m];
                arr[m] = arr[rootNode];
                arr[rootNode] = temp;
                rootNode = m;
            }
            else
            {
                break;
            }
        }
    }
}


//复杂结构的icompare继承
/*
public class Student(){
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int age;
    // 年龄
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    private string grade;
    // 年级
    public string Grade
    {
        get { return grade; }
        set { grade = value; }
    }

    public Student(string name,int age,string grade) {
        this.name = name;
        this.age = age;
        this.grade = grade;
    }
}

public class StudentComparer :IComparer<Student> {
    public enum CompareType
    {
        Name,
        Age,
        Grade
    }

    private CompareType type;
    public StudentComparer(CompareType type) {
        this.type = type;
    }

    public int Compare(Student x, Student y) {
        switch (this.type)
        {
            case CompareType.Name:
                return x.Name.CompareTo(y.Name);
            case CompareType.Age:
                return x.Age.CompareTo(y.Age);
            default://case CompareType.Grade:
                return x.Grade.CompareTo(y.Grade);
        }

    }


/*
//年龄升序排列
     class AgeASC : IComparer<Student>
     {
         public int Compare(Student x, Student y)
         {
             return x.Age - y.Age;
         }
     }
     //年龄降序排列
     class AgeDESC : IComparer<Student>
     {
         public int Compare(Student x, Student y)
         {
             //return y.Age - x.Age;
             return y.Age.CompareTo(x.Age);
         }
     }
     //姓名升序排列
    class NameASC : IComparer<Student>
    {
       public int Compare(Student x, Student y)
        {
            return x.StuName.CompareTo(y.StuName); //x在前，升序
         }
    }
    //姓名降序排列
     class NameDESC : IComparer<Student>
     {
         public int Compare(Student x, Student y)
         {
             return y.StuName.CompareTo(x.StuName); //y在前，降序
         }
     }

//使用方法：
 static void Main(string[] args)
        {
            //实例化List<T>集合对象
            List<Student> list = new List<Student>();
            //添加对象元素
            Student objStu1 = new Student() { Age = 20, StuId = 1001, StuName = "小张" };
            Student objStu2 = new Student() { Age = 22, StuId = 1003, StuName = "小李" };
            Student objStu3 = new Student() { Age = 22, StuId = 1002, StuName = "小王" };
            list.Add(objStu1);
            list.Add(objStu2);
            list.Add(objStu3);
            //默认排序
            Console.WriteLine("------------默认排序------------");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("姓名：{0}  年龄：{1}  学号：{2}", list[i].StuName, list[i].Age, list[i].StuId);
            }
            //年龄降序排序
            Console.WriteLine("------------年龄降序排序------------");
            list.Sort(new AgeDESC());
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("姓名：{0}  年龄：{1}  学号：{2}", list[i].StuName, list[i].Age, list[i].StuId);
            }
            //姓名升排序
            Console.WriteLine("------------姓名升序排序------------");
            list.Sort(new NameASC());
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("姓名：{0}  年龄：{1}  学号：{2}", list[i].StuName, list[i].Age, list[i].StuId);
            }
            Console.ReadLine();
        }
*/

/*
//IComparable和IComparer比较器
class Student : IComparable<Student>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public int CompareTo(Student other)
    {
        return Age.CompareTo(other.Age);  //一直到是可以比较的基本元素为止
    }
}

class SortName : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        return x.Name.CompareTo(y.Name);
    }
}
}
public class test
{
    public static void Main()
    {
        List<Student> arr = new List<Student>();
        arr.Add(new Student("张三", 7, "一年级"));
        arr.Add(new Student("李四", 11, "二年级"));
        arr.Add(new Student("王五", 21, "一年级"));
        arr.Add(new Student("陈六", 8, "三年级"));
        arr.Add(new Student("刘七", 15, "二年级"));
       
        // 调用Sort方法，实现按年级排序
        arr.Sort(new StudentComparer(StudentComparer.CompareType.Grade)); 

        //上面我们完全可以写成委托的形式
        //arr.Sort(delegate(Student x, Student y) { return x.Grade.CompareTo(y.Grade ); }); 

        // 循环显示集合里的元素
        foreach( Student item in arr)
            Console.WriteLine(item.ToString());

        // 调用Sort方法，实现按姓名排序
        arr.Sort(new StudentComparer(StudentComparer.CompareType.Name));            
        // 循环显示集合里的元素
        foreach( Student item in arr)
            Console.WriteLine(item.ToString());
    }
}
*/


public class Testcompare:IComparer<float>{
    public int Compare(float x, float y)
    {
        return x.CompareTo(y);
    }
}

public class TestSort : MonoBehaviour
{
    // Start is called before the first frame update
    // public InputParam inputparam = new InputParam();
    public InputParam inputparam;
    public Testcompare Testcompare = new Testcompare() ; 
    void Start()
    {
        QuikSort<float> SortTest = new QuikSort<float>();   //改成选择，按钮， 输出
        SortTest.Sort(inputparam.inputArray1,Testcompare,0,inputparam.inputArray1.Length - 1);

        for(int i = 0;i<inputparam.inputArray1.Length;i++){
            Debug.Log(inputparam.inputArray1[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}








//其他参考资料

//https://blog.csdn.net/weixin_46215617/article/details/108230953
