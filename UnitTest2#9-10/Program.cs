using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static UnitTest2_9_10.Program;
using System.Xml.Linq;

namespace UnitTest2_9_10
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Footballer footballer = new Footballer
            {
                name = "Francis Bacon",
                position = "Foward",
                age = 22,
                team = "Barcelona"

            };

            NationalTeam natTeam = new NationalTeam
            {
                natname = "Spain"
            };

            Tickets ticket = new Tickets
            {
                ticketprice = 19.99
            };

            MyMethod(footballer);
            MyMethod(natTeam);
            MyMethod(ticket);
        }
        
        static void MyMethod(object obj)
        {
            if (obj is ITeam team)
            {
                team.getPlayers();
            }

            if (obj is IStadium stadium)
            {
                stadium.getTickets();
            }
        }

        public interface ITeam
        {
            void getPlayers();


        }
        public interface IStadium
        {
            void getTickets();
        }

        public abstract class Player
        {
            public string name;
            public string position;
            public int age;

            public virtual void play()
            {

            }


            public abstract void transfer();
        }
        public class Footballer : Player, ITeam
        {
            public string team;


            public override void transfer()
            {

            }

            public void getPlayers()
            {
            }
        }

        public class Tickets : IStadium
        {
            public double ticketprice; 

            public void getTickets()
            {
            }
        }

        public class NationalTeam : ITeam
        {
            public string natname;

            public void getPlayers()
            {
            }
        }




    }    
}
