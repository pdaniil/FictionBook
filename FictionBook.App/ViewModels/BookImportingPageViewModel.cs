using System;
using Books.App.Core.Messages;
using Books.App.Managers.Contracts;
using Caliburn.Micro;

namespace Books.App.ViewModels
{
    public class BookImportingPageViewModel
        : Screen
    {
        private readonly IBookManager _bookManager;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public BookImportingPageViewModel(IBookManager bookManager, INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _bookManager = bookManager;
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
        }

        protected override async void OnViewReady(object view)
        {
            try
            {
                var importedBook = await _bookManager.ImportBook();

                _eventAggregator.PublishOnUIThread(new BooksImported(importedBook));
                _navigationService.GoBack();

            }
            catch (Exception ex)
            {

            }
        }
    }
}