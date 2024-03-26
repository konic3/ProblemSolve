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

        // 큐에 요소를 추가합니다.
        public void Enqueue(T data)
        {
            list.Add(data);
        }

        // 큐에서 요소를 제거하고 반환합니다.
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

        // 큐의 요소를 한 개 제외하고 모두 디큐한 후 다시 인큐합니다.
        public void DequeueAllAndEnqueueExceptLast()
        {
            LinkedListNode<T> current = list.Head;
            LinkedListNode<T> previous = null;

            // 마지막 노드를 찾습니다.
            while (current.Next != null)
            {
                previous = current;
                current = current.Next;
            }

            // 마지막 노드를 제외하고 모든 노드를 디큐하고 다시 인큐합니다.
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

        // 스택에 요소를 추가합니다.
        public void Push(T data)
        {
            queue.Enqueue(data);
        }

        // 스택에서 요소를 제거하고 반환합니다.
        public T Pop()
        {
            if (queue.Head == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            // 큐의 요소를 한 개 제외하고 모두 디큐한 후 다시 인큐합니다.
            queue.DequeueAllAndEnqueueExceptLast();

            // 스택의 가장 위에 있는 요소를 반환합니다.
            return queue.Dequeue();
        }
    }
}
