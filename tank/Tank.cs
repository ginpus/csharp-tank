using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tank
{
    internal class Person
    {
        public int VericalPosition;
        public int HorizontalPosition;
        public int Ammo;
        public int ShotsMade;

        //statinis kintamasis. STATIC YRA KLASES SAVYBE. ne static yra per klase sukurto objekto savybe
        public static int PersonCount;

        public void Info()
        {
            Console.WriteLine($"{Name} {SurName} {Age}");
        }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Age = age;
            SurName = surname;
            PersonCount++;
        }

        public Person(string Name)
        {
            this.Name = Name;
        }
    }
}