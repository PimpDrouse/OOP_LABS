using System;
using System.Collections;
using System.Threading;
using LABA_2.ClassesAndInterfaces;

namespace LABA_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student pers1 = new Student();
            Console.WriteLine(pers1.GetHashCode());
            Console.WriteLine(pers1.ToShortString());
            Thread.Sleep(5000);
            Student pers2 = (Student)pers1.DeepCopy();
            Console.WriteLine(pers2.GetHashCode());
            Console.WriteLine(pers2.ToShortString());
            if(pers1.Equals(pers2))
                if (pers1.GetHashCode() == pers2.GetHashCode())
                    if (pers1 == pers2)
                        Console.WriteLine("ABOBA");
        }
    }
}