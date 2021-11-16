/*
    * Автосвойство string с названием коллекции в котороый произошло событие
    * Автосвойство string с названием изменения события
    * Автосвойство Student для ссылки на объект в котором произошли изменения
    * Конструктор для инициализации
    * Перегрузка ToString() для вывода инфы о изменения
*/
namespace LABA_4.ClassesAndInterfaces
{
    public class JournalEntry
    {
        internal string CollectionName { get; set; }
        internal string ChangeName { get; set; }
        internal Student ObjectReference { get; set; }

        internal JournalEntry(string collectionName, string changeName, Student objectReference)
        {
            CollectionName = collectionName;
            ChangeName = changeName;
            ObjectReference = objectReference;
        }

        public override string ToString()
        {
            return
                $"Название коллекции: {CollectionName} | Название изменения: {ChangeName}\n" +
                $" Объект:\n" +
                $"{ObjectReference.ToString()}";    //Не ссылка, но наверное сойдет
        }
    }
}