using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paint
{
    public class Table<T, T2>
    {
        List<T> keys;
        List<T2> values;
        public Table()
        {
            keys = new List<T>();
            values = new List<T2>();
        }
        public T2 this[T key]
        {
            get
            {
                if (!keys.Contains(key)) return default(T2);
                return values[keys.IndexOf(key)];
            }
        }
        public void Add(T key,T2 value)
        {
            keys.Add(key);
            values.Add(value);
        }
        public void Remove(T key)
        {
            if (keys.Contains(key))
            {
                int ind = keys.IndexOf(key);
                keys.RemoveAt(ind);
                values.RemoveAt(ind);
            }
        }
        public void RemoveAt(int index)
        {
            if (index < keys.Count && index < values.Count)
            {
                keys.RemoveAt(index);
                values.RemoveAt(index);
            }
        }
        public bool ContainsKey(T key)
        {
            return keys.Contains(key);
        }
        public int IndexOfKey(T key)
        {
            return keys.IndexOf(key);
        }
    }
}
