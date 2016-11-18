using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using FictionBook.App.Core.UI;
using FictionBook.App.Providers.Contracts;
using FictionBook.App.ViewModels;

namespace FictionBook.App.Providers
{
    public class ShellMenuProvider : IMenuProvider
    {
        #region Implementation of IMenuProvider

        public IEnumerable<MenuItem> GetMainMenuItems()
        {
            yield return new MenuItem() { Icon = Symbol.Library, Name = "Home", Page = typeof(LibraryPageViewModel)};
            yield return new MenuItem() { Icon = Symbol.Send, Name = "Favorite", Page = typeof(ShellPageViewModel) };
        }

        public IEnumerable<MenuItem> GetOptionsMenuItems()
        {
            yield return new MenuItem() { Icon = Symbol.Setting, Name = "Settings", Page = typeof(ShellPageViewModel) };

            var symbol = Symbol.Library;
        }

        #endregion
    }
}