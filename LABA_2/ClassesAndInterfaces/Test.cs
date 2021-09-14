using System;

namespace LABA_2.ClassesAndInterfaces
{
    internal class Test
    {
        //
        
        
        
        internal string Subject { get; set; }
        internal bool Pass { get; set; }
        //
        


        internal Test(string subject, bool pass)
        {
            Subject = subject;
            Pass = pass;
        }
        internal Test()
        {
            Subject = "None";
            Pass = false;
        }
        //


        
        public override string ToString()
        {
            string informationAboutTest = $"Предмет: {Subject} | Результат: {Pass}";
            return informationAboutTest;
        }
    }
}