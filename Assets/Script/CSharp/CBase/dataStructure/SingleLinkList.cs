using System.Collections;
using System.Collections.Generic;
using System;

public class SingleLinkNode<T>
{
    public T data;
    public SingleLinkNode<T> next;
}


public class SingleLinkList<T>
{
    public SingleLinkNode<T> head = new SingleLinkNode<T>();

    public void CreateList(T[] split) {   //���͵ĵ����ǲ���Ҫ�����ذ�//ͷ�巨
        SingleLinkNode<T> s;
        int i;
        head.next = null;
        for(i = 0; i < split.Length; i++) {
            s = new SingleLinkNode<T>();
            s.data = split[i];
            s.next = head.next;
            head.next = s;
        }
    }

    public void CreateListR(T[] split) {    //β�巨
        SingleLinkNode<T> s, r;
        int i;
        r = head;                               //rʼ��ָ��β���,��ʼʱָ��ͷ���
        for(i = 0; i < split.Length; i++)       //ѭ���������ݽ��
        {
            s = new SingleLinkNode<T>();
            s.data = split[i];                  //�������ݽ��s
            r.next = s;                         //��s������r���֮��
            r = s;
        }
        r.next = null;			                //��β����next�ֶ���Ϊnull
    }

    //������ڵ����
    public int ListLength() {
        int n = 0;
        SingleLinkNode<T> p;
        p = head;                                //pָ��ͷ���,n��Ϊ0(��ͷ�������Ϊ0)
        while(p.next != null)
        {
            n++;
            p = p.next;
        }
        return n;	
    }

    //�飺��������
    public int LocateElem(T e)
    {
        int i = 1;
        SingleLinkNode<T> p;
        p = head.next;                              //pָ��ʼ���,i��Ϊ1(����ʼ�������Ϊ1)
        while(p != null && !p.data.Equals(e))     //����dataֵΪe�Ľ��,�����Ϊi  //Ϊʲôequals���ԣ����Ƿ��͵�����д��ô
        {
            p = p.next;
            i++;
        }
        if(p == null)                           //������Ԫ��ֵΪe�Ľ��,����0
            return (0);
        else                                    //����Ԫ��ֵΪe�Ľ��,�������߼����i
            return (i);
    }


    //��������Ԫ�أ���λ��i�����Ԫ��item
    public void ListInsert(int i, T e) {

        
    }

    //ɾ������Ԫ��
    public void ListDelete(int i,ref T e) {
    }
}

public class Node<T>
{
    private T data;
    private Node<T> next;

    public Node(T val, Node<T> p)
    {
        data = val;
        next = p;
    }

    public Node(Node<T> p)
    {
        next = p;
    }

    public Node(T val)
    {
        data = val;
        next = null;
    }


    public Node()
    {
        data = default(T);
        next = null;
    }

    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    public Node<T> Next
    {
        get { return next; }
        set { next = value; }
    }
}

public class LinkList<T> 
{
    private Node<T> head;

    public Node<T> Head
    {
        get { return head; }
        set { head = value; }
    }

    public LinkList()
    {
        head = null;
    }

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T this[int index]
    {
        get
        {
            return this.GetItemAt(index);
        }
    }

    /// <summary>
    /// ���ص�����ĳ���
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        Node<T> p = head;
        int len = 0;
        while(p != null)
        {
            len++;
            p = p.Next;
        }
        return len;
    }

    /// <summary>
    /// ���
    /// </summary>
    public void Clear()
    {
        head = null;
    }

    /// <summary>
    /// �Ƿ�Ϊ��
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return head == null;
    }

    /// <summary>
    /// ����󸽼�Ԫ��
    /// </summary>
    /// <param name="item"></param>
    public void Append(T item)
    {
        Node<T> d = new Node<T>(item);
        Node<T> n = new Node<T>();

        if(head == null)
        {
            head = d;
            return;
        }

        n = head;
        while(n.Next != null)
        {
            n = n.Next;
        }
        n.Next = d;
    }

    //ǰ��
    public void InsertBefore(T item, int i)
    {
        if(IsEmpty() || i < 0)
        {
            Console.WriteLine("List is empty or Position is error!");
            return;
        }

        //���ͷ����
        if(i == 0)
        {
            Node<T> q = new Node<T>(item);
            q.Next = Head;//��"ͷ"�ĳɵڶ���Ԫ��
            head = q;//���Լ�����Ϊ"ͷ"
            return;
        }

        Node<T> n = head;
        Node<T> d = new Node<T>();
        int j = 0;

        //�ҵ�λ��i��ǰһ��Ԫ��d
        while(n.Next != null && j < i)
        {
            d = n;
            n = n.Next;
            j++;
        }

        if(n.Next == null) //˵���������ڵ����(��׷��)
        {
            Node<T> q = new Node<T>(item);
            n.Next = q;
            q.Next = null;
        }
        else
        {
            if(j == i)
            {
                Node<T> q = new Node<T>(item);
                d.Next = q;
                q.Next = n;
            }
        }
    }

    /// <summary>
    /// ��λ��i�����Ԫ��item
    /// </summary>
    /// <param name="item"></param>
    /// <param name="i"></param>
    public void InsertAfter(T item, int i)
    {
        if(IsEmpty() || i < 0)
        {
            Console.WriteLine("List is empty or Position is error!");
            return;
        }

        if(i == 0)
        {
            Node<T> q = new Node<T>(item);
            q.Next = head.Next;
            head.Next = q;
            return;
        }

        Node<T> p = head;
        int j = 0;

        while(p != null && j < i)
        {
            p = p.Next;
            j++;
        }
        if(j == i)
        {
            Node<T> q = new Node<T>(item);
            q.Next = p.Next;
            p.Next = q;
        }
        else
        {
            Console.WriteLine("Position is error!");
        }
    }

    /// <summary>
    /// ɾ��λ��i��Ԫ��
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public T RemoveAt(int i)
    {
        if(IsEmpty() || i < 0)
        {
            Console.WriteLine("Link is empty or Position is error!");
            return default(T);
        }

        Node<T> q = new Node<T>();
        if(i == 0)
        {
            q = head;
            head = head.Next;
            return q.Data;
        }

        Node<T> p = head;
        int j = 0;

        while(p.Next != null && j < i)
        {
            j++;
            q = p;
            p = p.Next;
        }

        if(j == i)
        {
            q.Next = p.Next;
            return p.Data;
        }
        else
        {
            Console.WriteLine("The node is not exist!");
            return default(T);
        }
    }

    /// <summary>
    /// ��ȡָ��λ�õ�Ԫ��
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public T GetItemAt(int i)
    {
        if(IsEmpty())
        {
            Console.WriteLine("List is empty!");
            return default(T);
        }

        Node<T> p = new Node<T>();
        p = head;

        if(i == 0)
        {
            return p.Data;
        }

        int j = 0;

        while(p.Next != null && j < i)
        {
            j++;
            p = p.Next;
        }

        if(j == i)
        {
            return p.Data;
        }
        else
        {
            Console.WriteLine("The node is not exist!");
            return default(T);
        }
    }

    //��Ԫ��ֵ��������
    public int IndexOf(T value)
    {
        if(IsEmpty())
        {
            Console.WriteLine("List is Empty!");
            return -1;
        }
        Node<T> p = new Node<T>();
        p = head;
        int i = 0;
        while(!p.Data.Equals(value) && p.Next != null)
        {
            p = p.Next;
            i++;
        }
        return i;
    }

    /// <summary>
    /// Ԫ�ط�ת
    /// </summary>
    public void Reverse()
    {
        LinkList<T> result = new LinkList<T>();
        Node<T> t = this.head;
        result.Head = new Node<T>(t.Data);
        t = t.Next;

        //(�ѵ�ǰ���ӵ�Ԫ�ش�head��ʼ������������뵽��һ���������У������õ�������������Ԫ��˳���ԭ�������෴��)
        while(t != null)
        {
            result.InsertBefore(t.Data, 0);
            t = t.Next;
        }
        this.head = result.head;//��ԭ����ֱ�ӹҵ�"��ת�������"��
        result = null;//��ʽ���ԭ��������ã��Ա���GC��ֱ�ӻ���
    }
}


/*Console.WriteLine("-------------------------------------");
Console.WriteLine("��������Կ�ʼ...");
LinkList<string> link = new LinkList<string>();
link.Head = new Node<string>("x");
link.InsertBefore("w", 0);
link.InsertBefore("v", 0);
link.Append("y");
link.InsertBefore("z", link.Count());
Console.WriteLine(link.Count());//5
Console.WriteLine(link.ToString());//v,w,x,y,z
Console.WriteLine(link[1]);//w
Console.WriteLine(link[0]);//v
Console.WriteLine(link[4]);//z
Console.WriteLine(link.IndexOf("z"));//4
Console.WriteLine(link.RemoveAt(2));//x
Console.WriteLine(link.ToString());//v,w,y,z
link.InsertBefore("x", 2);
Console.WriteLine(link.ToString());//v,w,x,y,z
Console.WriteLine(link.GetItemAt(2));//x
link.Reverse();
Console.WriteLine(link.ToString());//z,y,x,w,v
link.InsertAfter("1", 0);
link.InsertAfter("2", 1);
link.InsertAfter("6", 5);
link.InsertAfter("8", 7);
link.InsertAfter("A", 10);//Position is error!

Console.WriteLine(link.ToString()); //z,1,2,y,x,w,6,v,8*/
