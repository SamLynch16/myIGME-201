using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    internal class Program
    {
        public class Pets
        {
            public int petEl;
            public int count;

            List<Pet> petList = new List<Pet>();

            public Pet this[int nPetEl]


            {
                get
                {
                    Pet returnVal;
                    try
                    {
                        returnVal = (Pet)petList[nPetEl];
                    }
                    catch
                    {
                        returnVal = null;
                    }

                    return (returnVal);
                }

                set
                {
                    // if the index is less than the number of list elements
                    if (nPetEl < petList.Count)
                    {
                        // update the existing value at that index
                        petList[nPetEl] = value;
                    }
                    else
                    {
                        // add the value to the list
                        petList.Add(value);
                    }
                }
            }

        }

        public interface ICat
        {
            void Eat();
            void Play();
            void Scratch();
            void Purr();


        }

        public interface IDog
        {
            void Eat();
            void Play();
            void Bark();
            void GotoVet();
            void NeedWalk();


        }

        public abstract class Pet : Pets
        {
            string name;
            int age;
            public string Name;

            public abstract void Eat();
            public abstract void Play();
            public abstract void GotoVet();
        }

        public class Cat : Pet, ICat
        {
            public override void Eat()
            {
               
            }

            public override void Play()
            {
                
            }

            public override void GotoVet()
            {
                
            }

            public void Scratch()
            {
                
            }

            public void Purr()
            {
                
            }
        }

        public class Dog : Pet, IDog
        {

            string license;
            
            public override void Eat()
            {
                
            }

            public override void Play()
            {
               
            }

            public override void GotoVet()
            {
                
            }

            public void NeedWalk()
            {
                
            }

            public void Bark()
            {
                
            }
        }


    }

}

