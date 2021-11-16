using System;
using LABA_2.ClassesAndInterfaces;

namespace LABA_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stud1 = new Student();
            Student stud2 = new Student();
            Console.WriteLine(stud1.Equals(stud2));
            Console.WriteLine(stud1==stud2);
            Console.WriteLine(stud1.GetHashCode());
            Console.WriteLine(stud2.GetHashCode());
            Console.WriteLine();

            Student stud3 = new Student();
            stud3.AddExam(new Exam(), new Exam("Math", 5, 2000, 1, 1));
            stud3.AddTest(new Test(), new Test("Math",true));
            Console.WriteLine(stud3.ToString());
            Console.WriteLine();
            
            Console.WriteLine(stud3.PersonData);
            Console.WriteLine();

            Student stud4 = (Student)stud3.DeepCopy();
            stud3.AddExam(new Exam("Proga",5,2000,2,2));
            Console.WriteLine(stud3.ToString());
            Console.WriteLine();
            Console.WriteLine(stud4.ToString());

            try
            {
                stud3.Group = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            foreach (object examsAndTest in stud3.GetExamsAndTests())
            {
                Console.WriteLine(examsAndTest.ToString());
            }
            Console.WriteLine();

            foreach (object exams in stud3.GetExamsMore(3))
            {
                Console.WriteLine(exams.ToString());
            }
        }
    }
}