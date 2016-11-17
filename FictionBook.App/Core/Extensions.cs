using System.Collections.Generic;
using Caliburn.Micro;

namespace FictionBook.App.Core
{
    public static class Extensions
    {
        public static BindableCollection<T> ToBindableCollection<T>(this IEnumerable<T> source)
        {
            return new BindableCollection<T>(source);
        }
    }
}