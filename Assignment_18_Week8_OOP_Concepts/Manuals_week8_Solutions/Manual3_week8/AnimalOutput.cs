using System;

class Animal
{
    public void sound()
    {
        Console.WriteLine("This is parent class");
    }
}

class Dog : Animal
{
    public new void sound()
    {
        Console.WriteLine("Dog bark");
    }
}

class Cat : Animal
{
    public new void sound()
    {
        base.sound();
        Console.WriteLine("Cat meow");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dog d = new Dog();
        Cat c = new Cat();

        d.sound();
        c.sound();

        Console.ReadKey();
    }
}