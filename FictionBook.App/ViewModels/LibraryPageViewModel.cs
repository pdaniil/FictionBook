namespace Books.App.ViewModels
{
    using System.Linq;
    using System.Collections.Generic;

    using Windows.UI.Xaml.Controls;

    using Caliburn.Micro;

    using Models.Database;
    using Managers.Contracts;

    public sealed class LibraryPageViewModel
        : Screen
    {
        private readonly IBookManager _bookManager;

        #region Private Members

        private BindableCollection<BookModel> _recentLibrary;
        private BindableCollection<BookModel> _allLibrary;
        private bool _bookClickEnabled = true;
        private ListViewSelectionMode _recentBooksSelectionMode = ListViewSelectionMode.None;

        #endregion

        #region Properties

        public BindableCollection<BookModel> RecentLibrary => _recentLibrary;
        public BindableCollection<BookModel> AllLibrary => _allLibrary;

        public IList<object> SelectedRecentBooks { get; set; }

        public ListViewSelectionMode RecentBooksSelectionMode
        {
            get { return _recentBooksSelectionMode; }
            set
            {
                _recentBooksSelectionMode = value;
                NotifyOfPropertyChange();
            }
        }

        public BookModel SelectedRecentBook { get; set; }
        public bool BookClickEnabled
        {
            get { return _bookClickEnabled; }
            set
            {
                _bookClickEnabled = value; 
                NotifyOfPropertyChange();
            }
        }

        #endregion

        public LibraryPageViewModel(IBookManager bookManager)
        {
            _bookManager = bookManager;

            UpdateLibraries();
        }


        public async void UpdateRecentLibrary()
        {
            _recentLibrary = new BindableCollection<BookModel>(await _bookManager.GetBooks(7));
        }
        public async void UpdateAllLibrary()
        {
            _allLibrary = new BindableCollection<BookModel>(await _bookManager.GetBooks());
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

        public async void AddFromFile()
        {
            await _bookManager.ImportBook();

            UpdateRecentLibrary();
            NotifyOfPropertyChange(nameof(RecentLibrary));
        }
        public async void AddFromFolder()
        {
            await _bookManager.ImportBooks();

            UpdateRecentLibrary();
            NotifyOfPropertyChange(nameof(RecentLibrary));
        }

        public void OpenBook(ItemClickEventArgs eventArgs)
        {
            
        }

        public void SelectionMode()
        {
            BookClickEnabled = false;

            BookClickEnabled = RecentBooksSelectionMode != ListViewSelectionMode.Multiple;
            RecentBooksSelectionMode = RecentBooksSelectionMode == ListViewSelectionMode.None ? ListViewSelectionMode.Multiple : ListViewSelectionMode.None;
            
            NotifyOfPropertyChange(nameof(RecentBooksSelectionMode));
        }
        public async void DeleteBooks()
        {
            var selectedBooks = SelectedRecentBooks?.Cast<BookModel>();
            if (selectedBooks?.Count() > 1)
                await _bookManager.DeleteBooks(selectedBooks);
            else
                await _bookManager.DeleteBook(SelectedRecentBook);

            UpdateLibraries();
        }
    }
}