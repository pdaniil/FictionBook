namespace Books.App.ViewModels
{
    using System.Linq;
    using System.Collections.Generic;
    
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using Models.Database;
    using Providers.Contracts;

    using Caliburn.Micro;

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

        public ListViewSelectionMode RecentBooksSelectionMode { get; set; } = ListViewSelectionMode.None;

        public IList<object> SelectedRecentBooks { get; set; }

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

        #region Overrides of Screen
        
        protected override void OnActivate()
        {
            UpdateLibraries();
        }
        
        protected override void OnDeactivate(bool close)
        {
            _recentLibrary = null;
            _allLibrary = null;
            SelectedRecentBooks = null;
        }

        #endregion

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

        public void BookClick(object sender, ItemClickEventArgs eventArgs)
        {
            
        }
        public void SelectionMode()
        {
            var selectedBooks = SelectedRecentBooks?.Cast<BookModel>();
            if (selectedBooks?.Count() > 1)
            {
                
            } 

            RecentBooksSelectionMode = RecentBooksSelectionMode == ListViewSelectionMode.None ? ListViewSelectionMode.Multiple : ListViewSelectionMode.None;
            NotifyOfPropertyChange(nameof(RecentBooksSelectionMode));
        }
    }
}