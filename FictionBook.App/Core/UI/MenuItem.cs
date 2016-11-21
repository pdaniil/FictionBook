using System;
using Windows.UI.Xaml.Controls;

namespace Books.App.Core.UI
{
    public class MenuItem
    {
        public Symbol Icon { get; set; }
        public string Name { get; set; }
        public Type Page { get; set; }
    }
}