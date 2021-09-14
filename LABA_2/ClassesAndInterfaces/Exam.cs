using System;

namespace LABA_2.ClassesAndInterfaces
{
    internal class Exam : IDateAndCopy
    {
        //
        
        
        
        internal string Subjects { get; set; }
        internal int Mark { get; set; }
        internal DateTime DateOfPass { get; set; }
        public DateTime Date { get; set; }
        //



        internal Exam(string subjects, int mark, int yearOfPass, int monthOfPass, int dayOfPass)
        {
            Subjects = subjects;
            Mark = mark;
            DateOfPass = new DateTime(yearOfPass, monthOfPass, dayOfPass);
        }
        internal Exam()
        {
            Subjects = "None";
            Mark = -1;
            DateOfPass = new DateTime(1,1,1);
        }
        //


        
        public override string ToString()
        {
            string informationAboutExam = $"Предмет: {Subjects} | Оценка: {Mark} | Дата сдачи: {DateOfPass.ToShortDateString()}";
            Console.WriteLine(informationAboutExam);
            return informationAboutExam;
        }

        public object DeepCopy()
        {
            Exam examCopy = new Exam(Subjects, Mark, DateOfPass.Year, DateOfPass.Month, DateOfPass.Day);
            examCopy.Date = DateTime.Today;
            return examCopy;
        }
    }
}