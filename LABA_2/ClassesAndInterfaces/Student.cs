/*
    *Закротое поле типа ArrayList хранящее Test
    *Закротое поле типа ArrayList хранящее Exam
    *Класс измененный под Person
    *Конструктор с параметрами и без
    *Свойство типа Person c get и set
    *Свойство типа double Avg с get
    *Свойство типа ArrayList с get и set
    *Метод void AddExam для добавления элементов
    *В свойстве Group оперделить set выкидывающий исключение при введенном значении от 100 до 500
    *Определить итератор для перебора всех элементов из списка зачетов и экзаменов 
    *Определить итератор для последовательного перебора экзаменов с оценкой больше заданного значения
    *Переопределить Equals
    *Определить операции == и !=
    *Переопределить GetHashCode
    *Реализация интерфейса IDateCopy
    *Определить override object DeepCopy
*/
using System;
using System.Collections;

namespace LABA_2.ClassesAndInterfaces
{
    internal class Student : Person,IDateAndCopy

    {
        private Person _personData;
        private Education _education;
        private int _group;
        private ArrayList _tests;
        private ArrayList _exams;

        public DateTime DateOfCreation { get; set; }

        internal Person PersonData
        {
            get => _personData;
            set => _personData = value;
        }

        internal Education Education
        {
            get => _education;
            set => _education = value;
        }

        internal int Group
        {
            get => _group;
            set
            {
                if (value <= 100 || value > 599)
                    throw new Exception("Введена группа выходящая из диапазона от 100 до 599");
                _group = value;
            }
        }

        internal ArrayList Exams
        {
            get => _exams;
            set => _exams = value;
        }

        internal ArrayList Tests
        {
            get => _tests;
            set => _tests = value;
        }

        internal double Avg
        {
            get
            {
                double avg = 0;
                foreach (Exam exam in Exams)
                {
                    avg += exam.Mark;
                }

                return avg / Exams.Count;
            }
        }

        internal bool this[Education ed]
        {
            get
            {
                if (ed == Education) return true;
                else return false;
            }
        }

        
        internal Student() : this(new Person(),Education.None,102,new ArrayList(),new ArrayList()){}
        internal Student(Person personData, Education education, int group, ArrayList exams, ArrayList tests)
        {
            PersonData = personData;
            Education = education;
            Group = group;
            Exams = exams;
            Tests = tests;
            DateOfCreation = DateTime.Now;
        }

        
        public void AddExam(params Exam[] addedExams)
        {
            for (int i = 0; i < addedExams.Length; i++)
            {
                Exams.Add(addedExams[i]);
            }
        }

        public void AddTest(params Test[] addedTests)
        {
            for (int i = 0; i < addedTests.Length; i++)
            {
                Tests.Add(addedTests[i]);
            }
        }

        public IEnumerable GetExamsAndTests()
        {
            for (int i = 0; i < Exams.Count; i++)
            {
                yield return Exams[i];
            }
            
            for (int i = 0; i < Tests.Count; i++)
            {
                yield return Tests[i];
            }
        }
        
        public IEnumerable GetExamsMore(int _mark)
        {
            for (int i = 0; i < Exams.Count; i++)
            {
                Exam _exam = Exams[i] as Exam;
                if (_exam.Mark > _mark) yield return Exams[i];
            }
        }
        
        public override object DeepCopy()
        {
            ArrayList copyExams = new ArrayList();                          //Выглядит как костыль
            foreach (Exam exam in Exams)
            {
                copyExams.Add(exam.DeepCopy());
            }
            
            ArrayList copyTests = new ArrayList();
            foreach (Test test in Tests)
            {
                copyTests.Add(test.DeepCopy());
            }
            
            Student studCopy = new Student((Person)PersonData.DeepCopy(), Education, Group, copyExams, copyTests);
            return studCopy;
        }
        
        public override string ToShortString()
        {
            string shortInformationAboutStudent = $"{PersonData.ToString()} | Образование: {Education.ToString()} | Группа: {Group}";
            return shortInformationAboutStudent;
        }
        
        public override string ToString()
        {
            string informationAboutStudent = $"{PersonData.ToString()} | Образование: {Education.ToString()} | Группа: {Group} | Средняя оценка: {Avg}";
            
            informationAboutStudent += "\nСписок экзаменов: ";
            foreach (Exam exam in Exams)
            {
                informationAboutStudent += "\n" + exam.ToString();
            }
            
            informationAboutStudent += "\nСписок зачетов: ";
            foreach (Test test in Tests)
            {
                informationAboutStudent += "\n" + test.ToString();
            }
            
            return informationAboutStudent;
        }

        public override bool Equals(object obj)
        {
            return this.PersonData == ((Student)obj).PersonData && 
                   this.Education == ((Student)obj).Education &&
                   this.Group == ((Student)obj).Group && 
                   this.Exams == ((Student)obj).Exams && 
                   this.Tests == ((Student)obj).Tests;
        }

        public override int GetHashCode()
        {
            return PersonData.GetHashCode() + Education.GetHashCode() + Group.GetHashCode();
        }

        public static bool operator ==(Student stud1, Student stud2)
        {
            return ReferenceEquals(stud1, stud2);
        }
        
        public static bool operator !=(Student stud1, Student stud2)
        {
            return ReferenceEquals(stud1, stud2);
        }
    }
}