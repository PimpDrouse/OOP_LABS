/*
    *Автосвойство типа string Subject
    *Автосвойство типа bool Pass
    *Конструкторы с параметрами и без
    *Переопределение ToString
*/


using System;

namespace LABA_2.ClassesAndInterfaces
{
    internal class Test
    {
        internal string Subject { get; set; }
        internal bool Pass { get; set; }

        
        internal Test() : this("None", false){}
        internal Test(string subject, bool pass)
        {
            Subject = subject;
            Pass = pass;
        }

        
        public override string ToString()
        {
            string informationAboutTest = $"Предмет: {Subject} | Результат: {Pass}";
            return informationAboutTest;
        }
    }
}