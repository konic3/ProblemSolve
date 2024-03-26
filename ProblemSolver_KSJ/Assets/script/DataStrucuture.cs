using System;
using UnityEngine;

namespace DataStrucuture
{
    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T>
    {
        public LinkedListNode<T> Head { get; private set; }

        public LinkedList()
        {
            Head = null;
        }

        public void Add(T data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                LinkedListNode<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
    }

    public class Queue<T>
    {
        private LinkedList<T> list;

        public Queue()
        {
            list = new LinkedList<T>();
        }

        // ť�� ��Ҹ� �߰��մϴ�.
        public void Enqueue(T data)
        {
            list.Add(data);
        }

        // ť���� ��Ҹ� �����ϰ� ��ȯ�մϴ�.
        public T Dequeue()
        {
            if (list.Head == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T data = list.Head.Data;
            list.Head = list.Head.Next;
            return data;
        }

        // ť�� ��Ҹ� �� �� �����ϰ� ��� ��ť�� �� �ٽ� ��ť�մϴ�.
        public void DequeueAllAndEnqueueExceptLast()
        {
            LinkedListNode<T> current = list.Head;
            LinkedListNode<T> previous = null;

            // ������ ��带 ã���ϴ�.
            while (current.Next != null)
            {
                previous = current;
                current = current.Next;
            }

            // ������ ��带 �����ϰ� ��� ��带 ��ť�ϰ� �ٽ� ��ť�մϴ�.
            current = list.Head;
            while (current != previous)
            {
                Enqueue(Dequeue());
                current = current.Next;
            }
        }
    }

    public class Stack<T>
    {
        private Queue<T> queue;

        public Stack()
        {
            queue = new Queue<T>();
        }

        // ���ÿ� ��Ҹ� �߰��մϴ�.
        public void Push(T data)
        {
            queue.Enqueue(data);
        }

        // ���ÿ��� ��Ҹ� �����ϰ� ��ȯ�մϴ�.
        public T Pop()
        {
            if (queue.Head == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            // ť�� ��Ҹ� �� �� �����ϰ� ��� ��ť�� �� �ٽ� ��ť�մϴ�.
            queue.DequeueAllAndEnqueueExceptLast();

            // ������ ���� ���� �ִ� ��Ҹ� ��ȯ�մϴ�.
            return queue.Dequeue();
        }
    }
}
