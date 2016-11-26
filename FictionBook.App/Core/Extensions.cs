namespace Books.App.Core
{
    using System.Collections.Generic;

    using Caliburn.Micro;

    public static class Extensions
    {
        public static BindableCollection<T> ToBindableCollection<T>(this IEnumerable<T> source)
        {
            return new BindableCollection<T>(source);
        }
    }
}