using System;

namespace LABA_3.ClassesAndInterfaces
{
    internal class Test : IDateAndCopy
    {
        internal string Subject { get; set; }
        internal bool Pass { get; set; }
        public DateTime DateOfCreation { get; set;}

        
        internal Test() : this("None", false){}
        internal Test(string subject, bool pass)
        {
            Subject = subject;
            Pass = pass;
        }


        public object DeepCopy()
        {
            Test testCopy = new Test(Subject, Pass);
            return testCopy;
        }
        public override string ToString()
        {
            string informationAboutTest = $"Предмет: {Subject} | Результат: {Pass}";
            return informationAboutTest;
        }
    }
}