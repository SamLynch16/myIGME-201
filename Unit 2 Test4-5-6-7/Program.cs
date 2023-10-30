using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Unit_2_Test4_5_6_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tardis tardis = new Tardis
            {
                whichDrWho = 10
            };

            PhoneBooth pBooth = new PhoneBooth
            {
                costPerCall = 5.0
            };

            UsePhone(tardis);
            UsePhone(pBooth);
        }
        

        static void UsePhone(object obj)
        {
            if (obj is IPhoneInterface phone)
            {
                phone.MakeCall();
                phone.HangUp();
            }
           
            if (obj is PhoneBooth pbooth)
            {
                pbooth.MakeCall();
            }
            else if (obj is Tardis tard)
            {
                tard.TimeTravel();
            }
        }

        public interface IPhoneInterface
        {
            void Answer();
            void MakeCall();
            void HangUp();

        }
        public abstract class Phone
        {
            private string phoneNumber;
            public string address;

            public string PhoneNumber;
            public abstract void Connect();
            public abstract void Disconnect();
            
        }
        public class RotaryPhone: Phone, IPhoneInterface
        {
            public void Answer()
            {

            }
            public void MakeCall()
            {

            }
            public void HangUp()
            {

            }
            public override void Connect()
            {

            }
            public override void Disconnect()
            {
                
            }
        }
        public class PushButtonPhone : Phone, IPhoneInterface
        {
            public void Answer()
            {

            }
            public void MakeCall()
            {

            }
            public void HangUp()
            {

            }
            public override void Connect()
            {

            }
            public override void Disconnect()
            {

            }
        }

        public class PhoneBooth : PushButtonPhone
        {
            private bool superMan;
            public double costPerCall;
            public bool phoneBook;

            public void OpenDoor()
            {

            }
            public void CloseDoor()
            {

            }
        }
        public class Tardis : PushButtonPhone
        {
            private bool sonicScrewdriver;
            
            private string femaleSideKick;
            public double exteriorSurfaceArea;
            public double interiorVolume;

            public byte WhichDrWho { get;}
            public string FemaleSideKick { get;}

            public void TimeTravel()
            {

            }
            public byte whichDrWho { get; set; }

            public static bool operator ==(Tardis t1, Tardis t2)
            {
                if (t1 is null && t2 is null)
                {
                    return true;
                }
                if (t1 is null || t2 is null)
                {
                    return false;
                }
                if (t1.whichDrWho == 10)
                {
                    return true;
                }
                if (t2.whichDrWho == 10)
                {
                    return false;
                }
                return t1.whichDrWho == t2.whichDrWho;
            }

            public static bool operator !=(Tardis t1, Tardis t2)
            {
                return !(t1 == t2);
            }

            public static bool operator <(Tardis t1, Tardis t2)
            {
                if (t1 is null)
                {
                    return t2 != null;
                }
                if (t2 is null)
                {
                    return false;
                }
                if (t1.whichDrWho == 10)
                {
                    return false;
                }
                if (t2.whichDrWho == 10)
                {
                    return true;
                }
                return t1.whichDrWho < t2.whichDrWho;
            }
            public static bool operator >(Tardis t1, Tardis t2)
            {
                return t2 < t1; 
            }

            public static bool operator <=(Tardis t1, Tardis t2)
            {
                return t2 < t1 || t1 == t2;
            }
            public static bool operator >=(Tardis t1, Tardis t2)
            {
                return t2 > t1 || t1 == t2;
            }

        }


    }
}


