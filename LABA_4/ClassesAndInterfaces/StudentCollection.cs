/*
    * Добавить делегат void StudentListHandler(object source, StudentListHandlerEventArgs args)
    * Автосвойство string с названием коллекции
    * Метод bool Remove(int j) для удаления элемента из списка Students, если в списке нет элемента верни false
    * Индексатор для доступа к элементу списка
    * Событие StudentListHandelrEventArgs StudentCountChanged, происходящее при выборе или удалении элемента из списка и выдает Имя коллекции, информации о удалении или добавлении и ссылку на элемент
    * Событие StudentListhandlerEventArgs StudentReferenceChanged, происходящее когда одной из ссылок из списка присваивается новое значение(set в индексаторе) 
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace LABA_4.ClassesAndInterfaces
{

    internal class StudentCollection
    {
        internal delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
        private List<Student> Students;
        internal string CollectionName { get; set; }
        internal event StudentListHandler StudentCountChanged;
        internal event StudentListHandler StudentsReferenceChanged;
        
        internal Student this[int index]
        {
            get => Students[index];
            set
            {
                StudentsReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(CollectionName,"Изменена ссылка на эдемент", Students[index]));
                Students[index] = value;
            }
        }

        internal StudentCollection(StudentListHandler studentListHandler, string collectionName)
        {
            CollectionName = collectionName;
            StudentCountChanged += studentListHandler;
            StudentsReferenceChanged += studentListHandler;
            Students = new List<Student>();
        }

        internal bool Remove(int i)
        {
            if (i < Students.Count)
            {
                StudentCountChanged?.Invoke(this,
                    new StudentListHandlerEventArgs(CollectionName, "Элемент удален", Students[i]));
                Students.RemoveAt(i);
                return true;
            }
            else return false;
        }

        internal void AddDefaults()
        {
            Student student = new Student();
            StudentCountChanged?.Invoke(this,
                new StudentListHandlerEventArgs(CollectionName, "Добавлен элемент по умолчанию", student));
            Students.Add(student);
        }

        internal void AddStudents(params Student[] students)
        {
            foreach (Student student in students)
            {
                StudentCountChanged?.Invoke(this,
                    new StudentListHandlerEventArgs(CollectionName, "Добавлен элемент", student));
                Students.Add(student);
            }
        }
        
        internal string ToShortString()
        {
            string ListShStr = "";
            foreach (var student in Students)
            {
                ListShStr += student.ToShortString() + "\n";
            }
            return ListShStr;
        }
        public override string ToString()
        {
            string ListStr = "";
            foreach (var student in Students)
            {
                ListStr += student.ToString() + "\n";
            }
            return ListStr;
        }
    }
}