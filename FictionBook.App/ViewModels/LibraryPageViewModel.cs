using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Books.App.Core.Storage.Models;
using Books.App.Providers.Contracts;
using Caliburn.Micro;

namespace Books.App.ViewModels
{
    public sealed class LibraryPageViewModel
        : Screen
    {
        #region Private Members

        private readonly IBookProvider _bookProvider;
        private readonly IDbBookProvider _localDbProvider;

        private BindableCollection<BookModel> _recentLibrary;
        private BindableCollection<BookModel> _allLibrary;

        #endregion

        public BindableCollection<BookModel> RecentLibrary => _recentLibrary;
        public BindableCollection<BookModel> AllLibrary => _allLibrary;

        public LibraryPageViewModel(IBookProvider bookProvider, IDbBookProvider localDbProvider)
        {
            _bookProvider = bookProvider;
            _localDbProvider = localDbProvider;

            UpdateLibraries();
        }

        public async void UpdateRecentLibrary()
        {
            _recentLibrary = new BindableCollection<BookModel>(await _localDbProvider.GetRecentBooks(7));
        }
        public async void UpdateAllLibrary()
        {
            _allLibrary = new BindableCollection<BookModel>(await _localDbProvider.GetAllBooks());
        }

        public void UpdateLibraries()
        {
            UpdateRecentLibrary();
            UpdateAllLibrary();
        }


        public async void AddFromFile(object sender, RoutedEventArgs eventArgs)
        {
            await _bookProvider.LoadBookFromFile();

            UpdateRecentLibrary();
            NotifyOfPropertyChange(nameof(RecentLibrary));
        }
        public async void AddFromFolder(object sender, RoutedEventArgs eventArgs)
        {
            await _bookProvider.LoadBooksFromFolder();

            UpdateRecentLibrary();
            NotifyOfPropertyChange(nameof(RecentLibrary));
        }

        public async void BookClick(object sender, ItemClickEventArgs eventArgs)
        {
            
        }
    }
}