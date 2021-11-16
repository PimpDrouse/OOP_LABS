using System;
using LABA_4.ClassesAndInterfaces;

namespace LABA_4
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection1 = new StudentCollection(StudentsCount, "WOW");
            StudentCollection studentCollection2 = new StudentCollection(StudentsCount, "HEHE");

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            studentCollection1.StudentCountChanged += journal1.Event;
            studentCollection1.StudentsReferenceChanged += journal1.Event;
            studentCollection1.StudentsReferenceChanged += journal2.Event;
            studentCollection2.StudentsReferenceChanged += journal2.Event;
            
            studentCollection1.AddDefaults();
            studentCollection1.Remove(0);
            studentCollection1.Remove(0);
            studentCollection1.AddStudents(new Student());
            studentCollection1[0] = new Student();
            
            studentCollection2.AddDefaults();
            studentCollection2.Remove(0);
            studentCollection2.Remove(0);
            studentCollection2.AddStudents(new Student());
            studentCollection2[0] = new Student();
            
            Console.WriteLine(journal1.ToString() + "\n");
            Console.WriteLine(journal2.ToString());
        }
        
        
        private static void StudentsCount(object source, StudentListHandlerEventArgs args)
        {
            //Console.WriteLine(args.ToString());
        }
    }
}