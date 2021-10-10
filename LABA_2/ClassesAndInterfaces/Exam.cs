/*
    Реализация интерфейса IDateCopy
    Определить virtual object DeepCopy
*/
using System;

namespace LABA_2.ClassesAndInterfaces
{
    internal class Exam : IDateAndCopy
    {
        internal string Subjects { get; set; }
        internal int Mark { get; set; }
        internal DateTime DateOfPass { get; set; }
        public DateTime DateOfCreation { get; set; }

        
        internal Exam() : this( "None",-1,1,1,1){}
        internal Exam(string subjects, int mark, int yearOfPass, int monthOfPass, int dayOfPass)
        {
            Subjects = subjects;
            Mark = mark;
            DateOfPass = new DateTime(yearOfPass, monthOfPass, dayOfPass);
            DateOfCreation = DateTime.Now;
        }

        
        public override string ToString()
        {
            string informationAboutExam = $"Предмет: {Subjects} | Оценка: {Mark} | Дата сдачи: {DateOfPass.ToShortDateString()}";
            return informationAboutExam;
        }

        public virtual object DeepCopy()
        {
            Exam examCopy = new Exam(Subjects, Mark, DateOfPass.Year, DateOfPass.Month, DateOfPass.Day);
            return examCopy;
        }
    }
}