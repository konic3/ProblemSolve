using UnityEngine;
using System.Collections.Generic;
using System;

public class Queue<T>
{
    public class ListNode
    {
        public T Value { get; set; }
        public ListNode Next { get; set; }

        public ListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private ListNode front;
    private ListNode rear;
    private int count; // ����� ������ �����ϱ� ���� ����

    public Queue()
    {
        front = null;
        rear = null;
        count = 0; // �ʱ� ��� ������ 0���� ����
    }

    public void Enqueue(T data)
    {
        ListNode newNode = new ListNode(data);
        if (rear == null)
        {
            front = newNode;
            rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
        count++; // ��� �߰��� count ����
    }

    public T Dequeue()
    {
        if (front == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T dequeuedValue = front.Value;
        front = front.Next;

        if (front == null)
        {
            rear = null;
        }

        count--; // ��� ���Ž� count ����
        return dequeuedValue;
    }

    // ť�� �ִ� ����� ������ ��ȯ�ϴ� �Ӽ�
    public int Count
    {
        get { return count; }
    }
}
