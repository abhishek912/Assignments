using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static bool CustomAll(this IEnumerable<int> list)
        {
            var result = (from ele in list
                         where ele>=0 && ele<=50
                         select ele);
            return result.Count() == list.Count();
        }

        public static bool CustomAny(this IEnumerable<int> list)
        {
            var result = (from ele in list
                          where ele >= 25 && ele <= 50
                          select ele);
            return result.Count() > 0;
        }

        public static int CustomMax(this IEnumerable<int> list)
        {
            int result = int.MinValue;
            foreach(var ele in list)
            {
                result = Math.Max(result, ele);
            }
            return result;
        }

        public static int CustomMin(this IEnumerable<int> list)
        {
            int result = int.MaxValue;
            foreach (var ele in list)
            {
                result = Math.Min(result, ele);
            }
            return result;
        }

        public static IEnumerable<int> CustomWhere(this IEnumerable<int> list, Func<int, bool> inBetween)
        {
            var result = from ele in list
                         where inBetween(ele)
                         select ele;
            return result;
        }

        public static IEnumerable<int> CustomSelect(this IEnumerable<int> list, Func<int, bool> inBetween)
        {
            List<int> newList = new List<int>();
            foreach(var ele in list)
            {
                if (inBetween(ele))
                {
                    newList.Add(ele);
                }
            }
            return newList;
        }
    }
}
