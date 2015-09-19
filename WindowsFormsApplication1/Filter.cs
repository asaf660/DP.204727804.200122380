using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Filter<T>
    {
        public Func<T, bool> Condition { get; set; }

        protected Filter<T> m_NextFilter;
        public void SetNextFilter(Filter<T> i_NextFilter)
        {
            this.m_NextFilter = i_NextFilter;
        }

        public void SetTrivialConditionTo(bool i_Trivial)
        {
            Condition = (item) => i_Trivial; 
        }

        public Filter()
        {
            SetTrivialConditionTo(true);
        }

        public void ProcessFilters(ref ICollection<T> io_Collection)
        {
            // Cloning the input collection
            T[] array = new T[io_Collection.Count];
            io_Collection.CopyTo(array, 0);
            List<T> editableList = array.ToList();

            foreach (T item in io_Collection)
            {
                // If the filter condition is not met
                if (!Condition(item))
                {
                    editableList.Remove(item);
                }
            }

            io_Collection = editableList;
            if (m_NextFilter != null)
            {
                m_NextFilter.ProcessFilters(ref io_Collection);
            }
        }
    }
}
