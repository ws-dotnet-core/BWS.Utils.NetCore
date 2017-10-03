using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BWS.Utils.NetCore.Collections {

    [JsonObject]
    class EnumEntry<T> {

        public EnumEntry(T entry) => _entry = entry;

        readonly T _entry;

        [JsonProperty("key")]
        public int Key { get => _entry.GetHashCode(); }

        [JsonProperty("value")]
        public string Value { get => _entry.ToString(); }
    }

    class EnumCollection<T> : IList<EnumEntry<T>> {

        IList<EnumEntry<T>> list;

        public EnumCollection() => list = new List<EnumEntry<T>>();

        public EnumCollection(IList<EnumEntry<T>> list) => this.list = list;

        public EnumEntry<T> this[int index] {
            get => list[index];
            set => list[index] = value;
        }

        public int Count => list.Count;

        public bool IsReadOnly => list.IsReadOnly;

        public void Add(EnumEntry<T> item) => list.Add(item);

        public void Clear() => list.Clear();

        public bool Contains(EnumEntry<T> item) => list.Contains(item);

        public void CopyTo(EnumEntry<T>[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        public IEnumerator<EnumEntry<T>> GetEnumerator() => list.GetEnumerator();

        public int IndexOf(EnumEntry<T> item) => list.IndexOf(item);

        public void Insert(int index, EnumEntry<T> item) => list.Insert(index, item);

        public bool Remove(EnumEntry<T> item) => list.Remove(item);

        public void RemoveAt(int index) => list.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

    }


}
