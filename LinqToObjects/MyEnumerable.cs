using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static class MyEnumerable
    {
        public static Boolean Any<T>(this IEnumerable<T> source)
        {
            return Any(source, p => true);
        }

        public static Boolean Any<T>(this IEnumerable<T> source, Func<T, Boolean> predicate)
        {
            Check.NotNull(source);
            Check.NotNull(predicate);

            foreach (var item in source)
                if (predicate(item))
                    return true;

            return false;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, Boolean> predicate)
        {
            Check.NotNull(source);
            Check.NotNull(predicate);

            return WhereHelper(source, (t, i) => predicate(t));
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, Int32, Boolean> predicate)
        {
            Check.NotNull(source);
            Check.NotNull(predicate);

            return WhereHelper(source, predicate);
        }

        private static IEnumerable<T> WhereHelper<T>(this IEnumerable<T> source, Func<T, Int32, Boolean> predicate)
        {
            var index = 0;

            foreach (var item in source)
                if (predicate(item, index++))
                    yield return item;
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source)
        {
            Check.NotNull(source);
            return DistinctHelper(source);
        }

        private static IEnumerable<T> DistinctHelper<T>(this IEnumerable<T> source)
        {
            var list = new HashSet<T>();
            foreach (var item in source)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                    yield return item;
                }
            }
        }

        public static Int32 Count<T>(IEnumerable<T> source)
        {
            Check.NotNull(source);

            var count = 0;

            foreach (var item in source)
                count = checked(count + 1);

            return count;
        }

        public static class Check
        {
            public static void NotNull(Object obj)
            {
                if (obj == null)
                    throw new ArgumentNullException();
            }
        }

        public static IEnumerable<R> Select<T, R>(this IEnumerable<T> source, Func<T, R> selector)
        {
            Check.NotNull(source);
            return SelectHelper(source, selector);
        }

        private static IEnumerable<R> SelectHelper<T, R>(this IEnumerable<T> source, Func<T, R> selector)
        {
            foreach (var item in source)
                yield return selector(item);
        }
    }
}
