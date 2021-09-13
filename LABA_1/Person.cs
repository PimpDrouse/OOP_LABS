using System;

namespace LABA_1
{
    public class Person
    {
        //Поля
        
        
        
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        //Свойства и индексаторы



        internal string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        internal string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        internal DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        internal int YearOfBirth
        {
            get { return _dateOfBirth.Year; }
            set
            {
                _dateOfBirth = _dateOfBirth.AddYears(-_dateOfBirth.Year + 1);
                _dateOfBirth = _dateOfBirth.AddYears(value - 1);
            }
        }
        //Конструкторы
        
        
        
        internal Person(string firstName, string lastName, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
        }
        internal Person()
        {
            FirstName = "FAnon";
            LastName = "LAnon";
            DateOfBirth = new DateTime(2021, 1, 1);
        }
        //Методы
        
        
        
        public override string ToString()
        {
            string informationAboutClass = $"Имя: {FirstName} | Фамилия: {LastName} | Дата рождения: {DateOfBirth.ToShortDateString()}";
            Console.WriteLine(informationAboutClass);
            return informationAboutClass;
        }

        public virtual string ToShortString()
        {
            string shortInformationAboutClass = $"Имя: {FirstName} | Фамилия: {LastName}";
            Console.WriteLine(shortInformationAboutClass);
            return shortInformationAboutClass;
        }
    }
}