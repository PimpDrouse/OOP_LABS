using System;

namespace LABA_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(2);
            int ticks;
            int[] result = new int[3];

            Person personData = new Person("Артем", "Волегов", 2002, 5, 6);
            Student student = new Student(personData, Education.None, 15);
            student.ToShortString();

            Console.WriteLine(student[Education.None]);
            Console.WriteLine(student[Education.Bacherol]);
            Console.WriteLine(student[Education.Specialist]);
            Console.WriteLine(student[Education.SecondEducation]);
            Console.WriteLine();

            
            student.Exams = new Exam[1] { new Exam("Математика", 5, 2020, 7, 5) };
            student.Education = Education.Bacherol;
            student.Group = 7;
            student.PersonData = new Person();
            student.ToString();
            
            student.AddExam(new Exam[2]{new Exam("Программирование", 2, 2020, 7, 2), new Exam("Практика", 3, 2020, 7, 5)});
            student.ToString();
            
            Console.WriteLine("Введите количество строк и столбцов через ' ' или  |: ");
            string[] data = Console.ReadLine().Split(new char[] {'|', ' '}, 2);
            int nRow = Convert.ToInt32(data[0]);
            int nColumn = Convert.ToInt32(data[1]);
            Console.WriteLine("\n");

            ticks = Environment.TickCount;
            Exam[] singleArray = new Exam[nRow * nColumn];
            for (int i = 0; i < nColumn*nRow; i++)
            {
                singleArray[i] = new Exam("Single",i,1,2,3);
                singleArray[i].ToString();
                Console.WriteLine();
            }

            result[0] = Environment.TickCount - ticks;
            Console.WriteLine("\n");
            
            ticks = Environment.TickCount;
            Exam[,] dualArray = new Exam[nRow, nColumn];
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nColumn; j++)
                {
                    dualArray[i, j] = new Exam("Dual",i*nRow+j,1,2,3);
                    dualArray[i,j].ToString();
                    Console.WriteLine();
                }
            }
            
            result[1] = Environment.TickCount - ticks;
            Console.WriteLine("\n");
            
            ticks = Environment.TickCount;
            Exam[][] jaggedArray = new Exam[nRow][];
            for (int i = 0; i < nRow; i++)
            {
                jaggedArray[i] = new Exam[nColumn];
                for (int j = 0; j < nColumn; j++)
                {
                    jaggedArray[i][j] = new Exam("Jugged",i*nRow+j,1,2,3);
                    jaggedArray[i][j].ToString();
                    Console.WriteLine();
                }
            }
            
            result[2] = Environment.TickCount - ticks;
            Console.WriteLine("\n");
            
            Console.WriteLine("Результаты: ");
            foreach (var resul in result)
            {
                Console.WriteLine(resul);
            }
        }
    }
}