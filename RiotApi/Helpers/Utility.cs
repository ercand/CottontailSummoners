using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Helpers
{
    public static class Utility
    {
        public static List<List<T>> Split<T>(this List<T> items, int sliceSize)
        {
            List<List<T>> list = new List<List<T>>();
            for (int i = 0; i < items.Count; i += sliceSize)
                list.Add(items.GetRange(i, Math.Min(sliceSize, items.Count - i)));
            return list;
        }

        public static List<List<T>> Split<T>(this IEnumerable<T> items, int sliceSize)
        {
            List<List<T>> list = new List<List<T>>();
            for (int i = 0; i < items.Count(); i += sliceSize)
                list.Add(items.Skip(i).Take(Math.Min(sliceSize, items.Count() - i)).ToList<T>());
            return list;
        }
    }
}
