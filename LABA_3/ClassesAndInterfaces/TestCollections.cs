using System;
using System.Collections.Generic;
using System.Reflection;

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
    }
}