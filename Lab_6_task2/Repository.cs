using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6_task2
{
    public delegate bool Criteria<T>(T item);
    public class Repository<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }

            items.Add(item);
        }

        public IEnumerable<T> Find(Criteria<T> criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null");
            }

            return items.Where(criteria.Invoke);
        }
    }
}