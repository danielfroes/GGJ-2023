using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty(this ICollection collection)
        {
            return collection == null || collection.Count == 0;
        }


        public static T GetLast<T>(this IReadOnlyList<T> list)
        {
            if(list.Count == 0) 
                return default;

            int lastIndex = list.Count - 1;
            T element = list[lastIndex];
            return element;
        }
    }
}
