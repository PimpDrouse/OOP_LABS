using System;
using System.Collections;
using System.Collections.Generic;
using LABA_3.ClassesAndInterfaces;

namespace LABA_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Exam[] exams = new Exam[]
            {
                new Exam("D",2,1,1,1),
                new Exam("B",5,45,1,12),
                new Exam("A",3,2021,11,10),
                new Exam("F",4,2222,5,31),
                new Exam("C",1,2,2,2)
            };
            
            Student student = new Student(new Person(), Education.Bacherol, 101, new List<Exam>(), new List<Test>());
            student.AddExam(exams);
            
            foreach (var exam in student.Exams)
            {
                Console.WriteLine(exam.ToString());
            }
            Console.WriteLine();
            
            student.SortBySubject();
            foreach (var exam in student.Exams)
            {
                Console.WriteLine(exam.ToString());
            }
            Console.WriteLine();
            
            student.SortByMark();
            foreach (var exam in student.Exams)
            {
                Console.WriteLine(exam.ToString());
            }
            Console.WriteLine();
            
            student.SortByDateOfPass();
            foreach (var exam in student.Exams)
            {
                Console.WriteLine(exam.ToString());
            }


            Student student1 = new Student();
            Student student2 = new Student(new Person(),Education.Bacherol,105,new List<Exam>(){new Exam("24",5,1,1,1)},new List<Test>(){new Test()});
            Student[] students = new Student[] { student1, student2 };
            
            StudentCollection<string> studentCollection = new StudentCollection<string>(KeySelector);
            studentCollection.AddDefaults();
            studentCollection.AddStudents(students);
            Console.WriteLine(studentCollection.ToShortString());
            Console.WriteLine(studentCollection.ToString());
            Console.WriteLine();
            
            Console.WriteLine(studentCollection.Max);
            Console.WriteLine();

            foreach (var VARIABLE in studentCollection.EducationForm(Education.Bacherol))
            {
                Console.WriteLine(VARIABLE.Value);
            }
            Console.WriteLine();
            
            foreach (var VARIABLE in studentCollection.EdGroup)
            {
                Console.WriteLine(VARIABLE.Key);
            }
            Console.WriteLine();

            TestCollections<Person, Student> testCollections = new TestCollections<Person, Student>(400000, ElementGen);
            testCollections.TimeListKey();
            Console.WriteLine();
            testCollections.TimeListString();
            Console.WriteLine();
            testCollections.TimeDictionaryString();
            Console.WriteLine();
            testCollections.TimeDictionaryKey();
            //
        }
        

        internal static string KeySelector(Student st)
        {
            Console.WriteLine(st.SID);
            return st.SID.ToString();
        }

        internal static KeyValuePair<Person, Student> ElementGen(int i)
        {
            Person pers = new Person(i.ToString(), i.ToString(), 1+i%3000, 1+i % 12, 1+i%30);
            Student stud = new Student(pers, Education.Specialist, 101 + i%498,
                new List<Exam>() { new Exam(i.ToString(), i, 1+i%3000, 1+i % 12, 1+i % 30) },
                new List<Test>() { new Test(i.ToString(), true)});
            return new KeyValuePair<Person, Student>(pers, stud);
        }
    }
}
