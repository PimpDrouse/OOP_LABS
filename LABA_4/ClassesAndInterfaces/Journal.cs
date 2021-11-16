/*
    * Закрытое поле типа List<JournalEntry>
    * Оброботчики событий StudentCountChanged и StudentReferenceChanged добавляющее объект типа journalEntry в список
    * Перегруженная версия ToString() для формирования строки из элементов списка
 */
using System.Collections.Generic;

namespace LABA_4.ClassesAndInterfaces
{
    public class Journal
    {
        private List<JournalEntry> journaList;

        internal Journal()
        {
            journaList = new List<JournalEntry>();
        }

        public void Event(object source, StudentListHandlerEventArgs args)
        {
            journaList.Add(new JournalEntry(args.CollectionName, args.ChangeName,args.ObjectReference));
        }
        
        public override string ToString()
        {
            string journalStr = "Журнал изменений:\n";
            foreach (var journalEntry in journaList)
            {
                journalStr += journalEntry.ToString() + "\n";
            }

            return journalStr;
        }
    }
}