using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PE16_Classiest
{
    public interface ITakeOrder 
    {
        void TakeOrder();
    }

    public interface IMood
    {
        string Mood { get; }
    }

    public abstract class HotDrink
    {
        bool instant;
        bool milk;
        byte sugar;
        string size;
        Customer customer;

        public virtual void AddSugar(byte amount)
        {

        }
        public abstract void Steam();
      
        public void Method(string brand) {
        }

    }

    public class Customer:IMood
    {
        string name;
        string creditCardNumber;

        public string Mood { get; }
    }
    public class Waiter : IMood
    {
        string name;

        public string Mood { get; }
        
        public void ServeCustomer(HotDrink cup)
        {

        }
    }

    public class CupOfCoffee:HotDrink, ITakeOrder
    {
        string beanType;

        public override void Steam()
        {

        }
        public void TakeOrder()
        {

        }


    }

    public class CupOfTea : HotDrink, ITakeOrder
    {
        string leafType;

        public override void Steam()
        {

        }
        public void TakeOrder()
        {

        }
    }

    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        bool marshmallows;
        string source;

        public string Source { get; set; }
        public override void Steam()
        {

        }

        public override void AddSugar(byte amount)
        {
           
        }
        public void TakeOrder()
        {

        }
    }
}
