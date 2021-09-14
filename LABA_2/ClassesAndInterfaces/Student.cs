using System;
using System.Collections;

namespace LABA_2.ClassesAndInterfaces
{
    internal class Student : IDateAndCopy

    {
        //



        private Person _personData;
        private Education _education;
        private int _group;
        private ArrayList _tests;
        private ArrayList _exams;
        public DateTime Date { get; set; }
        //



        internal Person PersonData
        {
            get { return _personData; }
            set { _personData = value; }
        }

        internal Education Education
        {
            get { return _education; }
            set { _education = value; }
        }

        internal int Group
        {
            get { return _group; }
            set { _group = value; }
        }

        internal ArrayList Exams
        {
            get { return _exams; }
            set { _exams = value; }
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
        //



        internal Student(Person personData, Education education, int group)
        {
            PersonData = personData;
            Education = education;
            Group = group;
        }
        internal Student()
        {
            PersonData = new Person();
            Education = Education.None;
            Group = -1;
            //Exams = new Exam[1]{new Exam()};
        }
        //



        public void AddExam(Exam[] addedExams)
        {
          
            for (int i = 0; i < addedExams.Length; i++)
            {
                Exams.Add(addedExams[i]);
            }
        }
        
        public override string ToString()
        {
            string informationAboutStudent = $"{PersonData.ToString()} | Образование: {Education.ToString()} | Группа: {Group} | Средняя оценка: {Avg}";
            Console.WriteLine(informationAboutStudent);
            Console.WriteLine("Список экзаменов: ");
            foreach (Exam exam in Exams)
            {
                exam.ToString();
            }
            
            Console.WriteLine();
            return informationAboutStudent;
        }

        public virtual string ToShortString()
        {
            string shortInformationAboutStudent = $"{PersonData.ToString()} | Образование: {Education.ToString()} | Группа: {Group}";
            
            Console.WriteLine(shortInformationAboutStudent+"\n");
            return shortInformationAboutStudent;
        }
        
        public object DeepCopy()
        {
            Student studCopy = new Student(PersonData, Education, Group);
            studCopy.Date = DateTime.Today;
            return studCopy;
        }
    }
}