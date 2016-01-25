using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace tud.mci.tangram.TangramLector.Classes
{
    /// <summary>
    /// A Dictionary that can be sorted
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class OrderedConcurrentDictionary<TKey, TValue> : IDictionary<TKey, TValue>,
    ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>,
    IDictionary, ICollection, IEnumerable, IComparer<KeyValuePair<TKey, TValue>>
    {
        #region Member

        private readonly IComparer<KeyValuePair<TKey, TValue>> comparer;

        private ConcurrentDictionary<TKey, TValue> dic;

        private readonly ConcurrentDictionary<TKey, long> timedic = new ConcurrentDictionary<TKey, long>();

        #endregion

        public OrderedConcurrentDictionary(IComparer<KeyValuePair<TKey, TValue>> comparer)
        {
            dic = new ConcurrentDictionary<TKey, TValue>();
            this.comparer = comparer;
        }

        #region timeStamp list

        volatile int z = 0;

        private void addToTimeDic(TKey key) { timedic[key] = z++; }
        private void updateInTimeDic(TKey key) { timedic[key] = z++; }
        private void removeFromTimeDic(TKey key)
        {
            long trash;
            timedic.TryRemove(key, out trash);
        }

        public List<KeyValuePair<TKey, TValue>> GetSortedValues()
        {
            List<KeyValuePair<TKey, TValue>> myList = dic.ToArray().ToList();
            myList.Sort(this);
            return myList;
        }

        #endregion

        #region interface implementations

        public bool ContainsKey(TKey key)
        {
            return dic.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get
            {
                //TODO: sort
                return dic.Keys;
            }
        }

        public bool Remove(TKey key)
        {
            TValue trash;
            return dic.TryRemove(key, out trash);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return dic.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get
            {
                //TODO: sort

                //SortedList<

                return dic.Values;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return dic[key];
            }
            set
            {
                dic[key] = value;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            addToTimeDic(item.Key);
            dic.AddOrUpdate(item.Key, item.Value, (k, oldValue) => oldValue = item.Value);
        }

        public void Clear()
        {
            dic.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (dic.ContainsKey(item.Key))
            {
                return dic[item.Key].Equals(item.Value);
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            //TODO:
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return dic.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((IDictionary)dic).IsReadOnly; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (Contains(item))
            {
                TValue trash;
                return dic.TryRemove(item.Key, out trash);
            }
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return dic.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dic.GetEnumerator();
        }

        public void Add(object key, object value)
        {
            if (key is TKey && value is TValue)
            {
                Add(new KeyValuePair<TKey, TValue>((TKey)key, (TValue)value));
            }
        }

        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool Contains(object key)
        {
            return ((IDictionary)dic).Contains(key);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return ((IDictionary)dic).GetEnumerator();
        }

        public bool IsFixedSize
        {
            get { return ((IDictionary)dic).IsFixedSize; }
        }

        ICollection IDictionary.Keys
        {
            get
            {
                //TODO: sort
                return ((IDictionary)dic).Keys;
            }
        }

        public void Remove(object key)
        {
            if (key is TKey) { Remove((TKey)key); }
        }

        ICollection IDictionary.Values
        {
            get
            {
                //TODO: sort
                return ((IDictionary)dic).Values;
            }
        }

        public object this[object key]
        {
            get
            {
                if (key is TKey) return dic[(TKey)key];
                else return null;
            }
            set
            {
                if (key is TKey && value is TValue) dic[(TKey)key] = (TValue)value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            //TODO:
            throw new NotImplementedException();
        }

        public bool IsSynchronized
        {
            get
            {
                //TODO
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                //TODO:
                return null;
            }
        }

        #endregion

        #region internal sorter


        public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
        {
            int result = this.comparer.Compare(x, y);

            if (result == 0)
            {
                // try find the tstamps
                long tx = 0;
                long ty = 0;

                if (timedic.ContainsKey(x.Key)) { tx = timedic[x.Key]; }
                if (timedic.ContainsKey(y.Key)) { ty = timedic[y.Key]; }

                try { return (int)(tx - ty); }
                catch { }
            }

            return result;
        }

        #endregion

    }




}
