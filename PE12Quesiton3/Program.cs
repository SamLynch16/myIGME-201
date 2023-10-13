using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PE12Question3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass dclassobject = new MyDerivedClass("iValue");
            string result = dclassobject.GetString();

            Console.WriteLine(result);
        }

        public class MyClass {
            private string myString;

            public MyClass(string iValue) {
                myString = iValue;
            }
            
            public virtual string GetString()
            {
                return myString;
            }
        }

        public class MyDerivedClass : MyClass
        {
            public MyDerivedClass(string iValue) : base(iValue)
            {

            }

            public override string GetString() {
                string baseString = base.GetString();
                return baseString + "(output from the derived class)";
            }
        }
    }
}
