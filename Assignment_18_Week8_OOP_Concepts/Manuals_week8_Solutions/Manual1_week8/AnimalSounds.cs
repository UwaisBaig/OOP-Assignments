using System;

public class Animal
{
    public void sound()
    {
        Console.WriteLine("This is parent class");
    }
}

public class Dog : Animal
{
    public new void sound()
    {
        Console.WriteLine("Dog bark");
    }
}

public class Cat : Animal
{
    public new void sound()
    {
        base.sound();
        Console.WriteLine("Cat meow");
    }
}

class Program
{
    static void Main1(string[] args)
    {
        Dog d = new Dog();
        d.sound();

        Cat c = new Cat();
        c.sound();

        Console.ReadKey();
    }
}