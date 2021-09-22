using System;
using System.Collections.Generic;

namespace Excercise_3
{
    public interface IAnimal
    {
        DateTime Birthday { get; set; }
        void Move(string Move);
        void Speak(string Speak);
        void Move();
        void Speak();
    }
    public abstract class BaseAnimal : IAnimal
    {
        public DateTime Birthday { get; set; }
        public abstract void Move();

        public void Move(string Move)
        {
            throw new NotImplementedException();
        }

        public abstract void Speak();

        public void Speak(string Speak)
        {
            throw new NotImplementedException();
        }
    }
    public class Monkey : BaseAnimal
    {
        public DateTime  Birthday { get; set; }
        public override void Move()
        {
            Console.WriteLine("Monke is walking.");
        }
        public override void Speak()
        {
            Console.WriteLine("Monke say kih kih kah kah.");
        }
        public void Jump()
        {
            Console.WriteLine( "climb tree");
        }
    }
    public class Pets : BaseAnimal
    {
        public DateTime Birthday { get; set; }
        public string name { get; set; }
        public Pets(String name)
        {
            this.name = name;
        }
        public override void Move()
        {
            Console.WriteLine(" is walking. ");
        }
        public override void Speak()
        {
            Console.WriteLine(" is speaking");
        }
        
    }
    public class Dogs : Pets
    {
        public Dogs(String name) : base(name)
        {

        }
        public override void Move()
        {
            Console.WriteLine(name + " dog is walking with 4 legs.");
        }
        public override void Speak()
        {
            Console.WriteLine(name + " dog say woof woof");
        }
    }
    public class Cats : Pets
    {
        public Cats(string name) : base(name)
        {

        }
        public override void Move()
        {
            Console.WriteLine(name + " cat is walking with 4 legs.");
        }
        public override void Speak()
        {
            Console.WriteLine(name + " cat say meow meow");
        }
        public void Jump()
        {
            Console.WriteLine(name + " Jump high");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
           List<IAnimal> animals = new List<IAnimal> ();
            animals.Add(new Dogs("Alaska"));
            animals.Add(new Monkey());
            animals.Add(new Cats("Sugar"));

            foreach (IAnimal animal in animals)
            {
                animal.Move();
                animal.Speak();
                //if animal.name
            }
            Console.ReadLine();
        }
    }
}
