using System;
using System.Collections.Generic;

namespace SL.Domain
{
    /// <summary>
    /// Lista con elementos únicos, es decir, irrepetibles.
    /// No lanza excepción al agregar elementos existentes, solamente impide que se agreguen los mismos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UniqueList<T> : List<T>
    {
        HashSet<T> unique = new HashSet<T>();
        public UniqueList()
        {
        }
        public UniqueList(IEnumerable<T> collection)
        {
            this.AddRange(collection);
        }

        public new void Add(T Item)
        {
            int unique_count_old = unique.Count;
            unique.Add(Item);

            if (unique_count_old < unique.Count)
                base.Add(Item);
        }
        public new void AddRange(IEnumerable<T> Collection)
        {
            foreach (var item in Collection)
                this.Add(item);
        }
        public new void Remove(T Item)
        {
            unique.Remove(Item);
            base.Remove(Item);
        }
        public new void RemoveAll(Predicate<T> match)
        {
            unique.RemoveWhere(match);
            base.RemoveAll(match);
        }
        public new void Clear()
        {
            unique.Clear();
            base.Clear();
        }
    }
}
