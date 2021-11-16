using System;
using System.Collections.Generic;

namespace LABA_3.ClassesAndInterfaces
{
    internal class Exam : IDateAndCopy, IComparable, IComparer<Exam>
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

        
        public virtual object DeepCopy()
        {
            Exam examCopy = new Exam(Subjects, Mark, DateOfPass.Year, DateOfPass.Month, DateOfPass.Day);
            return examCopy;
        }

        public int CompareTo(object obj)
        {
            return String.Compare(this.Subjects, ((Exam) obj).Subjects, StringComparison.Ordinal);
        }

        public int Compare(Exam ex1, Exam ex2)
        {
            if (ex1.Mark > ex2.Mark) return 1;
            if (ex1.Mark == ex2.Mark) return 0;
            return -1;
        }
        
        public override string ToString()
        {
            string informationAboutExam = $"Предмет: {Subjects} | Оценка: {Mark} | Дата сдачи: {DateOfPass.ToShortDateString()}";
            return informationAboutExam;
        }
    }
}