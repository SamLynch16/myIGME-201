using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aclass aclassobj = new Aclass();
            Bclass bclassobj = new Bclass();

            aclassobj.Method();
            bclassobj.Method();
        }

        public abstract class AbClass
        {
            private string privstring;

            public string readWrite
            {
                get { return privstring; }
                set { privstring = value; }
            }
        }
        
        public interface IMyInterface
        {
            void Method();
        }

        public class Aclass : IMyInterface {
            public void Method()
            {
                Console.WriteLine("Class A");
            }
        }

        public class Bclass : IMyInterface
        {
            public void Method()
            {
                Console.WriteLine("Class B");
            }
        }


        public static void MyMethod(object myObject)
        {
            if (myObject is IMyInterface myInterfaceObject)
            {
                myInterfaceObject.Method();
            }
            else
            {
                Console.WriteLine("Object does not implement the IMyInterface.");
            }
        }
        public static void CallMyMethod(object Obj)
        {
            MyMethod(Obj);
        }
    }
}
