using System;

namespace LABA_1
{
    internal class Exam
    {
        //
        
        
        
        internal string Subjects { get; set; }
        internal int Mark { get; set; }
        internal DateTime DateOfPass { get; set; }
        //


        internal Exam() : this("None", -1, 0,0,0) { }
        internal Exam(string subjects, int mark, int yearOfPass, int monthOfPass, int dayOfPass)
        {
            Subjects = subjects;
            Mark = mark;
            DateOfPass = new DateTime(yearOfPass, monthOfPass, dayOfPass);
        }
        
        //


        
        public override string ToString()
        {
            string informationAboutExam = $"Предмет: {Subjects} | Оценка: {Mark} | Дата сдачи: {DateOfPass.ToShortDateString()}";
            //Console.WriteLine(informationAboutExam);
            return informationAboutExam;
        }
    }
}