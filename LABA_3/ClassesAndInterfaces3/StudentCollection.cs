/*
    * Делегат TKey KeySelector<TKey>(Student st)
    * Поле KeySelector<TKey> для хранения делегата
    * Конструктор с параметром KeySelector<TKey>
    * Метод void AddDefaults для инициализации Dictionary по умолчанию
    * Метод void AddStudents(params Student[]) для добавления студентов в Dictionary
    * Перегрузить виртуальный метод ToString() для перевода Dictionary в string(со списком зачетов и экзаменов)
    * Метод ToShortString() для перевода Dictionary в string(без списка зачетов и экзаменов)
    * Свойство double с get, возвращающее максмальное значение среднего балла Dictionary, если таковых элементов нет, то вывести значение по умолчанию(исп Linq.Enumerable,Max)
    * етод IEnumerable<KeyValuePair<TKey,Student>>EducationForm(Education value) для возвращения подмножества элементов с заданой формой обучения(для подм исп Where) 
    * Свойство IEnumerable<IGrouping<Education, KeyValuePair<TKey,Student>>> с get для группировки элементов по форме обучения  при помощи Group
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace LABA_3.ClassesAndInterfaces
{
    internal delegate TKey KeySelector<TKey>(Student st);

    internal class StudentCollection<TKey>
    {
        private Dictionary<TKey, Student> _students;
        private KeySelector<TKey> _keySelector;

        internal double Max
        {
            get
            {
                return _students.Values.Select(x => x.Avg).DefaultIfEmpty(-1.00001).Max();
            }
        }

        internal IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> EdGroup
        {
            get
            {
                return _students.GroupBy(x => x.Value.Education);
            }
        }

        internal StudentCollection(KeySelector<TKey> keySelector)
        {
            _keySelector = keySelector;
            _students = new Dictionary<TKey, Student>();
        }

        internal void AddDefaults()
        {
            Student student = new Student();
            _students.Add(_keySelector(student),student);
        }

        internal void AddStudents(params Student[] students)
        {
            foreach (Student student in students)
            {
                _students.Add(_keySelector(student),student);
            }
        }

        internal IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value)
        {
            return _students.Where(x => x.Value.Education.Equals(value));
        }

        internal string ToShortString()
        {
            string DictShStr = "";
            foreach (var student in _students.Values)
            {
                DictShStr += student.ToShortString() + "\n";
            }
            return DictShStr;
        }
        public override string ToString()
        {
            string DictStr = "";
            foreach (var student in _students.Values)
            {
                DictStr += student.ToString() + "\n";
            }
            return DictStr;
        }
    }
}