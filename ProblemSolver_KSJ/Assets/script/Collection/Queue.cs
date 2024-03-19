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
    private int count; // 요소의 개수를 추적하기 위한 변수

    public Queue()
    {
        front = null;
        rear = null;
        count = 0; // 초기 요소 개수는 0으로 설정
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
        count++; // 요소 추가시 count 증가
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

        count--; // 요소 제거시 count 감소
        return dequeuedValue;
    }

    // 큐에 있는 요소의 개수를 반환하는 속성
    public int Count
    {
        get { return count; }
    }
}
