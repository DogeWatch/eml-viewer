using System;
using System.Collections.Generic;

namespace EmlViewer.Wpf
{
    public static class Extensions
    {
        #region Public Methods

        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        #endregion
    }
}