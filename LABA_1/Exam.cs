using System;

namespace LABA_1
{
    public class Exam
    {
        internal string Subjects { get; set; }
        internal int Mark { get; set; }
        internal DateTime DateOfPass { get; set; }
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
            DateOfPass = new DateTime(0,0,0);
        }
        //


        
        public override string ToString()
        {
            string informationAboutExam = $"Предмет: {Subjects} | Оценка: {Mark} | Дата сдачи: {DateOfPass.ToShortDateString()}";
            Console.WriteLine(informationAboutExam);
            return informationAboutExam;
        }
    }
}