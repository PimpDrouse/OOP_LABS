using System;

namespace LABA_2.ClassesAndInterfaces
{
    internal class Person : IDateAndCopy
    {
        //Поля
        
        
        
        protected string _firstName;
        protected string _lastName;
        protected DateTime _dateOfBirth;
        public DateTime Date { get; set; }
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


        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person pers = obj as Person;
                if (pers == this) return true;
                else return false;
            }
            else return false;
        }
        
        

        public static bool operator ==(Person p1, Person p2)
        {
            if (p1.FirstName == p2.FirstName &&
                p1.LastName == p2.LastName &&
                p1.DateOfBirth == p2.DateOfBirth) return true;
            else return false;
        }
        
        public static bool operator !=(Person p1, Person p2)
        {
            if (p1.FirstName == p2.FirstName &&
                p1.LastName == p2.LastName &&
                p1.DateOfBirth == p2.DateOfBirth) return false;
            else return true;
        }

        public override string ToString()
        {
            string informationAboutClass = $"Имя: {FirstName} | Фамилия: {LastName} | Дата рождения: {DateOfBirth.ToShortDateString()}";
            //Console.WriteLine(informationAboutClass);
            return informationAboutClass;
        }

        public virtual string ToShortString()
        {
            string shortInformationAboutClass = $"Имя: {FirstName} | Фамилия: {LastName}";
            //Console.WriteLine(shortInformationAboutClass);
            return shortInformationAboutClass;
        }

        public object DeepCopy()
        {
            Person persCopy = new Person(FirstName, LastName, DateOfBirth.Year, DateOfBirth.Month, DateOfBirth.Day);
            persCopy.Date = DateTime.Today;
            return persCopy;
        }
    }
}