using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BWS.Utils.NetCore.Collections {

    /// <summary>
    /// The entry item of EnumCollection, support for seriailzations./> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [JsonObject]
    public class EnumEntry<T> {

        /// <summary>
        /// Create an item with an enum instance.
        /// </summary>
        /// <param name="entry"></param>
        public EnumEntry(T entry) => _entry = entry;

        readonly T _entry;

        /// <summary>
        /// Key of entry, seriailze to 'key'.
        /// </summary>
        [JsonProperty("key")]
        public int Key { get => _entry.GetHashCode(); }

        /// <summary>
        /// Value of entry, seriailze to 'value'.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get => _entry.ToString(); }
    }

    /// <summary>
    /// Enum instance key-value collections.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumCollection<T> : IList<EnumEntry<T>> {

        IList<EnumEntry<T>> list;

        /// <summary>
        /// Create an empty collection.
        /// </summary>
        public EnumCollection() => list = new List<EnumEntry<T>>();

        /// <summary>
        /// Create a collection by exist enums array.
        /// </summary>
        /// <param name="list"></param>
        public EnumCollection(IList<EnumEntry<T>> list) => this.list = list;

        public EnumEntry<T> this[int index] {
            get => list[index];
            set => list[index] = value;
        }

        /// <summary>
        /// Count of collection.
        /// </summary>
        public int Count => list.Count;

        /// <summary>
        /// If the collection is readonly.
        /// </summary>
        public bool IsReadOnly => list.IsReadOnly;

        /// <summary>
        /// Add entry.
        /// </summary>
        /// <param name="item"></param>
        public void Add(EnumEntry<T> item) => list.Add(item);

        /// <summary>
        /// Clear collection.
        /// </summary>
        public void Clear() => list.Clear();

        /// <summary>
        /// Check the collection if contains the item entry.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(EnumEntry<T> item) => list.Contains(item);

        /// <summary>
        /// Deep copy.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(EnumEntry<T>[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<EnumEntry<T>> GetEnumerator() => list.GetEnumerator();

        /// <summary>
        /// IndexOf
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(EnumEntry<T> item) => list.IndexOf(item);

        /// <summary>
        /// Add an entry into the position you want.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, EnumEntry<T> item) => list.Insert(index, item);

        /// <summary>
        /// Remove an entry.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(EnumEntry<T> item) => list.Remove(item);

        /// <summary>
        /// Remove an entry where you want.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) => list.RemoveAt(index);

        /// <summary>
        /// IEnumerable.GetEnumerator()
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

    }


}
