/*
    *Переопределить Equals
    *Определить операции == и !=
    *Переопределить GetHashCode
    *Реализация интерфейса IDateCopy
    *Определить virtual object DeepCopy
*/

using System;

namespace LABA_4.ClassesAndInterfaces
{
    internal class Person : IDateAndCopy
    {
        protected string _firstName;
        protected string _lastName;
        protected DateTime _dateOfBirth;

        public DateTime DateOfCreation { get; set; }
        
        internal string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        internal string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        internal DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value;
        }

        internal int YearOfBirth
        {
            get => _dateOfBirth.Year;
            set
            {
                _dateOfBirth = _dateOfBirth.AddYears(-_dateOfBirth.Year + 1);
                _dateOfBirth = _dateOfBirth.AddYears(value - 1);
            }
        }


        internal Person() : this("FAnon", "LAnon", 2021, 1, 1){}
        internal Person(string firstName, string lastName, int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
            DateOfCreation = DateTime.Now;
        }
        
        
        public virtual object DeepCopy()
        {
            Person persCopy = new Person(FirstName, LastName, DateOfBirth.Year, DateOfBirth.Month, DateOfBirth.Day);
            return persCopy;
        }
        
        public virtual string ToShortString()
        {
            string shortInformationAboutClass = $"Имя: {FirstName} | Фамилия: {LastName}";
            return shortInformationAboutClass;
        }

        public override string ToString()
        {
            string informationAboutClass = $"Имя: {FirstName} | Фамилия: {LastName} | Дата рождения: {DateOfBirth.ToShortDateString()}";
            return informationAboutClass;
        }
        
        public override bool Equals(object obj)
        {
            return this.FirstName == ((Person)obj).FirstName &&
                   this.LastName == ((Person)obj).LastName && 
                   this.DateOfBirth == ((Person)obj).DateOfBirth;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode() + DateOfBirth.GetHashCode();
        }
        
        public static bool operator ==(Person p1, Person p2)
        {
            return ReferenceEquals(p1,p2);
        }
        
        public static bool operator !=(Person p1, Person p2)
        {
            return !ReferenceEquals(p1,p2);
        }
    }
}