/*
    *Comparer Exam по дате
*/
using System.Collections.Generic;

namespace LABA_4.ClassesAndInterfaces
{
    internal class HelperExam : IComparer<Exam>
    {
        public int Compare(Exam ex1, Exam ex2)
        {
            if (ex1.DateOfPass > ex2.DateOfPass) return 1; 
            if (ex1.DateOfPass.Equals(ex2.DateOfPass)) return 0;
            return -1;
        }
    }
}