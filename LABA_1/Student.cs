using System;
using System.Net.Sockets;

namespace LABA_1
{
    public class Student
    {
        //
        
        
        
        
        private Person _personData;
        private Education _education;
        private int _group;
        private Exam[] _exams;
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

        internal Exam[] Exams
        {
            get { return Exams; }
            set { Exams = value; }
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
            Exams = new Exam[1]{new Exam()};
        }
        //



        public void AddExam(Exam[] addedExams)
        {
            Exam[] tempExams = new Exam[Exams.Length + addedExams.Length];

            for (int i = 0; i < Exams.Length; i++)
            {
                tempExams[i] = Exams[i];
            }

            for (int i = 0; i < addedExams.Length; i++)
            {
                Exams[Exams.Length + i] = addedExams[i];
            }
            
            Exams = tempExams;
        }
        
        public override string ToString()
        {
            string informationAboutStudent = $"{PersonData.ToString()} | Образование: {Education.ToString()} | Группа: {Group}";
            
            Console.WriteLine("Список экзаменов: ");
            foreach (var exam in Exams)
            {
                exam.ToString();
            }
            
            Console.WriteLine(informationAboutStudent);
            return informationAboutStudent;
        }

        public virtual string ToShortString()
        {
            string shortInformationAboutStudent = $"{PersonData.ToString()} | Образование: {Education.ToString()} | Группа: {Group}";
            
            Console.WriteLine(shortInformationAboutStudent);
            return shortInformationAboutStudent;
        }
    }
}