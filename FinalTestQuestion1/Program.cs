using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyStack
    {
        private List<int> stackList;

        public MyStack()
        {
            stackList = new List<int>();
        }

        
        public void Push(int n)
        {
            stackList.Add(n);
        }

        
        public int Pop()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            int poppedItem = stackList[stackList.Count - 1];
            stackList.RemoveAt(stackList.Count - 1);
            return poppedItem;
        }

        public int Peek()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return stackList[stackList.Count - 1];
        }
    }

    class Program
    {
        static void Main()
        {
            MyStack myStack = new MyStack();

            myStack.Push(5);
            myStack.Push(7);
            myStack.Push(3);

            Console.WriteLine("Peek: " + myStack.Peek()); 

            Console.WriteLine("Pop: " + myStack.Pop());   
            Console.WriteLine("Pop: " + myStack.Pop());   

            myStack.Push(4);

            Console.WriteLine("Peek: " + myStack.Peek()); 
        }
    }
}
