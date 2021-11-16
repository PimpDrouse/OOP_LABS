
using System;
using System.Collections;
using System.Collections.Generic;

namespace LABA_4.ClassesAndInterfaces
{
    internal struct ID
    {
        private static int id = 0;

        internal static int GetID()
        {
            id++;
            return id;
        } 
    }   //Костыль для создания ID
    
    internal class Student : Person,IDateAndCopy
    {
        private Person _personData;
        private Education _education;
        private int _group;
        private List<Test> _tests;
        private List<Exam> _exams;
        internal readonly int SID;

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

        internal List<Exam> Exams
        {
            get => _exams;
            set => _exams = value;
        }

        internal List<Test> Tests
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

        
        internal Student() : this(new Person(),Education.None,102,new List<Exam>(),new List<Test>()){}
        internal Student(Person personData, Education education, int group, List<Exam> exams, List<Test> tests)
        {
            PersonData = personData;
            Education = education;
            Group = group;
            Exams = exams;
            Tests = tests;
            DateOfCreation = DateTime.Now;
            SID = ID.GetID();
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

        public void SortBySubject()
        {
            Exams.Sort();
        }
        
        public void SortByDateOfPass()
        {
            Exams.Sort(new HelperExam().Compare);
        }
        
        public void SortByMark()
        {
            Exams.Sort(new Exam().Compare);
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
            List<Exam> copyExams = new List<Exam>();                          //Выглядит как костыль
            foreach (Exam exam in Exams)    
            {
                copyExams.Add((Exam)exam.DeepCopy());
            }
            
            List<Test> copyTests = new List<Test>();
            foreach (Test test in Tests)
            {
                copyTests.Add((Test)test.DeepCopy());
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