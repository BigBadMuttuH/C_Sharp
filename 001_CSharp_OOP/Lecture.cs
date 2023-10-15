using System;


namespace _001_CSharp_OOP;

public class Lecture
{
    public static void Person()
    {
        var person1 = new Person("John", "01.01.2000", height: 123);
        Console.WriteLine(person1);
        var person2 = new Person("Mark", "01.01.2040", height: 223);
        Console.WriteLine(person2);
        var person3 = new Person("Merry", "01.01.2020", height: 150);
        Console.WriteLine(person3.IsAdult(1));
        Console.WriteLine(person3);
    }
}