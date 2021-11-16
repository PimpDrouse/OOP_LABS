using System;
using System.Collections.Generic;

namespace LABA_2.ClassesAndInterfaces
{
    internal delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    internal class TestCollections<TKey,TValue>
    {
        private List<TKey> ListKey;
        private List<string> ListString;
        private Dictionary<TKey, TValue> DictionaryTKey;
        private Dictionary<string, TValue> DictionaryString;
        private GenerateElement<TKey, TValue> GenerateElement;

        internal TestCollections(int i, GenerateElement<TKey, TValue> keyValuePair)
        {
            GenerateElement = keyValuePair;
            ListKey = new List<TKey>();
            ListString = new List<string>();
            DictionaryTKey = new Dictionary<TKey, TValue>();
            DictionaryString = new Dictionary<string, TValue>();
            GenerateElements(i);
        }

        internal void GenerateElements(int k)
        {
            for (int i = 1; i < k; i++)
            {
                ListKey.Add(GenerateElement(i).Key);
                ListString.Add(i.ToString());
                DictionaryTKey.Add(GenerateElement(i).Key, GenerateElement(i).Value);
                DictionaryString.Add(i.ToString(), GenerateElement(i).Value);
            }
        }

        internal void TimeListKey()
        {
            long[] i = new long[4];
            long startTick = Environment.TickCount64;
            
            ListKey.Contains(GenerateElement(1).Key);
            i[0] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            ListKey.Contains(GenerateElement(ListKey.Count/2).Key);
            i[1] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            ListKey.Contains(GenerateElement(ListKey.Count).Key);
            i[2] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            ListKey.Contains(GenerateElement(ListKey.Count+1).Key);
            i[3] = Environment.TickCount64 - startTick;
            Console.WriteLine("Время ListKey: ");
            Console.WriteLine("First: " + i[0] + " Central: " + i[1] + " Last: " + i[2] + " NoExist: " + i[3] + " ");
        }
        
        internal void TimeListString()
        {
            long[] i = new long[4];
            long startTick = Environment.TickCount64;
            
            ListString.Contains(GenerateElement(1).Key.ToString());
            i[0] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            ListString.Contains(GenerateElement(ListString.Count/2).Key.ToString());
            i[1] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            ListString.Contains(GenerateElement(ListString.Count).Key.ToString());
            i[2] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            ListString.Contains(GenerateElement(ListString.Count+1).Key.ToString());
            i[3] = Environment.TickCount64 - startTick;
            Console.WriteLine("Время ListString: ");
            Console.WriteLine("First: " + i[0] + " Central: " + i[1] + " Last: " + i[2] + " NoExist: " + i[3] + " ");
        }
        
        internal void TimeDictionaryString()
        {
            long[] i = new long[4];
            long startTick = Environment.TickCount64;
            
            DictionaryString.ContainsKey(GenerateElement(1).Key.ToString());
            i[0] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            DictionaryString.ContainsKey(GenerateElement(DictionaryString.Count/2).Key.ToString());
            i[1] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            DictionaryString.ContainsKey(GenerateElement(DictionaryString.Count).Key.ToString());
            i[2] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            DictionaryString.ContainsKey(GenerateElement(DictionaryString.Count+1).Key.ToString());
            i[3] = Environment.TickCount64 - startTick;
            Console.WriteLine("Время DictionaryString: ");
            Console.WriteLine("First: " + i[0] + " Central: " + i[1] + " Last: " + i[2] + " NoExist: " + i[3] + " ");
        }
        
        internal void TimeDictionaryKey()
        {
            long[] i = new long[8];
            long startTick = Environment.TickCount64;
            
            DictionaryTKey.ContainsKey(GenerateElement(1).Key);
            i[0] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            DictionaryTKey.ContainsKey(GenerateElement(ListKey.Count/2).Key);
            i[1] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            DictionaryTKey.ContainsKey(GenerateElement(ListKey.Count).Key);
            i[2] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            DictionaryTKey.ContainsKey(GenerateElement(ListKey.Count+1).Key);
            i[3] = Environment.TickCount64 - startTick;
            Console.WriteLine("Время DictionaryTKey/Key: ");
            Console.WriteLine("First: " + i[0] + " Central: " + i[1] + " Last: " + i[2] + " NoExist: " + i[3] + " ");
            Console.WriteLine();
            startTick = Environment.TickCount64;
            
            DictionaryTKey.ContainsValue(GenerateElement(1).Value);
            i[4] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            DictionaryTKey.ContainsValue(GenerateElement(ListKey.Count/2).Value);
            i[5] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            DictionaryTKey.ContainsValue(GenerateElement(ListKey.Count).Value);
            i[6] = Environment.TickCount64 - startTick;
            startTick = Environment.TickCount64;
            
            DictionaryTKey.ContainsValue(GenerateElement(ListKey.Count+1).Value);
            i[7] = Environment.TickCount64 - startTick;
            Console.WriteLine("Время DictionaryTKey/Value: ");
            Console.WriteLine("First: " + i[0] + " Central: " + i[1] + " Last: " + i[2] + " NoExist: " + i[3] + " ");
        }
    }
}