using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTestQuestion2
{
    using System;
    using System.Collections.Generic;

    class MyQueue
    {
        private List<int> queueList;

        public MyQueue()
        {
            queueList = new List<int>();
        }

       
        public void Enqueue(int n)
        {
            queueList.Add(n);
        }

        
        public int Dequeue()
        {
            if (queueList.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            int dequeuedItem = queueList[0];
            queueList.RemoveAt(0);
            return dequeuedItem;
        }

       
        public int Peek()
        {
            if (queueList.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return queueList[0];
        }
    }

    class Program
    {
        static void Main()
        {         
            MyQueue myQueue = new MyQueue();

            myQueue.Enqueue(9);
            myQueue.Enqueue(5);
            myQueue.Enqueue(3);

            Console.WriteLine("Peek: " + myQueue.Peek());

            Console.WriteLine("Dequeue: " + myQueue.Dequeue());   
            Console.WriteLine("Dequeue: " + myQueue.Dequeue());   

            myQueue.Enqueue(4);

            Console.WriteLine("Peek: " + myQueue.Peek()); 
        }
    }

}
