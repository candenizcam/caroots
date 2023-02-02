using System.Collections.Generic;
using System.Linq;

namespace Punity.tools
{
    public static class EnumerationTools
    {

        
        /** Splits a list by an element, 
         * first list contains up to the element
         * second list contains after the element
         * if element is not in the list, second list is empty
         */
        public static (List<T> first,List<T> second, bool anyMatch) SplitBy<T>(this List<T> enumerable, T element) where T : class
        {
            var l1 = new List<T>();
            var l2 = new List<T>();
            bool split = false;
            foreach (var x1 in enumerable)
            {
                if (split)
                {
                    l2.Add(x1);
                    continue;
                }

                if (x1 == element)
                {
                    split = true;
                }
                
                l1.Add(x1);
            }

            return (l1, l2,split);
        }
        
        
        public static IEnumerable<(int i, T arg2)> NumberedList<T>(this List<T> enumerable)
        {
            var c = enumerable.Count;
            var r = Enumerable.Range(0, c);
            return r.Zip(enumerable, (i, arg2) => (i, arg2));
        }
        
        public static IEnumerable<T> Shuffled<T>(this List<T> enumerable)
        {
            var rng = new System.Random();
            return enumerable.OrderBy(a => rng.Next());
        }
        
        public static T PickRandom<T>(this List<T> enumerable)
        {
            var rng = new System.Random();
            var index = rng.Next(0, enumerable.Count());
            return enumerable[index];
        }

        public static T PickRandom<T>(this T[] enumerable)
        {
            var rng = new System.Random();
            var index = rng.Next(0, enumerable.Length);
            return enumerable[index];
        }
        
    }
}