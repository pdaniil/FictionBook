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
        #region Private Members

        private readonly IBookManager _bookManager;

        private BindableCollection<BookModel> _recentBooks;
        private BindableCollection<BookModel> _allBooks;

        private bool _booksClickEnabled = true;

        private ListViewSelectionMode _booksSelectionMode = ListViewSelectionMode.None;

        #endregion

        public BindableCollection<BookModel> RecentBooks => _recentBooks;
        public BindableCollection<BookModel> AllBooks => _allBooks;

        public BookModel SelectedBook { get; set; }
        public IList<object> SelectedBooks { get; set; }

        public bool BooksClickEnabled
        {
            get { return _booksClickEnabled; }
            set
            {
                _booksClickEnabled = value;
                NotifyOfPropertyChange();
            }
        }
        public ListViewSelectionMode BooksSelectionMode
        {
            get { return _booksSelectionMode; }
            set
            {
                _booksSelectionMode = value;
                NotifyOfPropertyChange();
            }
        }

        public LibraryPageViewModel(IBookManager bookManager)
        {
            _bookManager = bookManager;

            UpdateLibraries();
        }

        public async void UpdateLibraries()
        {
            _recentBooks = new BindableCollection<BookModel>(await _bookManager.GetBooks(7));
            _allBooks = new BindableCollection<BookModel>(await _bookManager.GetBooks());
        }

        public async void AddBook()
        {
            var importedBook = await _bookManager.ImportBook();

            _recentBooks.Insert(0, importedBook);
            _allBooks.Add(importedBook);

            NotifyOfPropertyChange(nameof(RecentBooks));
            NotifyOfPropertyChange(nameof(AllBooks));
        }
        public async void DeleteBooks()
        {
            var selectedBooks = SelectedBooks?.Cast<BookModel>();
            if (selectedBooks?.Count() > 1)
            {
                await _bookManager.DeleteBooks(selectedBooks);


                _allBooks.RemoveRange(selectedBooks);
                _recentBooks.RemoveRange(selectedBooks);
            }
            else
            {
                await _bookManager.DeleteBook(SelectedBook);

                _allBooks.Remove(SelectedBook);
                _recentBooks.Remove(SelectedBook);
            }

            BooksSelectionMode = ListViewSelectionMode.None;
            BooksClickEnabled = true;

            NotifyOfPropertyChange(nameof(RecentBooks));
            NotifyOfPropertyChange(nameof(AllBooks));
        }
        public void SelectionMode()
        {
            BooksClickEnabled = false;

            BooksClickEnabled = BooksSelectionMode != ListViewSelectionMode.Multiple;
            BooksSelectionMode = BooksSelectionMode == ListViewSelectionMode.None ? ListViewSelectionMode.Multiple : ListViewSelectionMode.None;

            NotifyOfPropertyChange(nameof(BooksSelectionMode));
        }

        public void OpenBook(ItemClickEventArgs eventArgs)
        {
            
        }
    }
}