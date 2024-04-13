using System.Collections.Generic;

namespace Cm.Core
{
    public static class ListOrderInsertExt
    {
        public static void OrderInsertLast<T>(this List<T> list, T item, IComparer<T> comparer = null)
        {
            comparer ??= Comparer<T>.Default;
            var count = list.Count;
            int low = -1, high = count - 1;
            while (low < high)
            {
                var mid = low + ((high - low + 1) >> 1);
                var compare = comparer.Compare(item, list[mid]);
                if (compare >= 0)
                {
                    low = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }

            list.Insert(low + 1, item);
        }

        public static void OrderInsertFirst<T>(this List<T> list, T item, IComparer<T> comparer = null)
        {
            comparer ??= Comparer<T>.Default;
            var count = list.Count;
            int low = 0, high = count;
            while (low < high) 
            {
                var mid = low + (high - low) >> 1;
                var compare = comparer.Compare(item, list[mid]);
                if (compare <= 0)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            
            list.Insert(low, item);
        }
    }
    
    public class OrderList<T>
    {
        public readonly List<T> ListValue;
        public readonly IComparer<T> OrderComparer;

        public OrderList(List<T> listValue, IComparer<T> orderComparer)
        {
            ListValue = listValue;
            OrderComparer = orderComparer;
        }

        public void OrderInsertFirst(T item) => ListValue.OrderInsertFirst(item, OrderComparer);
        public void OrderInsertLast(T item) => ListValue.OrderInsertLast(item, OrderComparer);
    }
}