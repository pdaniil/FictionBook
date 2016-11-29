using System;

namespace Books.App.ViewModels
{
    using Windows.UI.Xaml.Controls;

    using Core;
    using Models.Controls;
    using Providers.Contracts;

    using Caliburn.Micro;

    public sealed class ShellPageViewModel :
        Screen
    {

        #region Private Members

        private readonly WinRTContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private readonly IMenuProvider _menuProvider;

        private INavigationService _navigation;
        private bool _paneOpen;

        private Type _currentViewModel;

        #endregion

        public ShellPageViewModel(WinRTContainer container, IEventAggregator eventAggregator, IMenuProvider menuProvider)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _menuProvider = menuProvider;

            _eventAggregator.Subscribe(this);

            NotifyOfPropertyChange(nameof(MainMenuItems));
            NotifyOfPropertyChange(nameof(OptionsMenuItems));
        }

        #region Pane

        public BindableCollection<MenuItem> MainMenuItems => _menuProvider.GetMainMenuItems().ToBindableCollection();
        public BindableCollection<MenuItem> OptionsMenuItems => _menuProvider.GetOptionsMenuItems().ToBindableCollection();

        public bool PaneOpen
        {
            get { return _paneOpen; }
            set
            {
                _paneOpen = value;
                NotifyOfPropertyChange();
            }
        }
 
        private void MainMenuItemClick(object sender, ItemClickEventArgs eventArgs)
        {
            var menuItem = eventArgs.ClickedItem as MenuItem;

            if (menuItem.Page == typeof(LibraryPageViewModel) && 
                _currentViewModel != typeof(LibraryPageViewModel))
            {
                _navigation.For<LibraryPageViewModel>()
                    .Navigate();

                _currentViewModel = typeof(LibraryPageViewModel);
            }

            PaneBehavior();
        }
        private void OptionMenuItemClick(object sender, ItemClickEventArgs eventArgs)
        {
            PaneBehavior();
        }

        private void PaneBehavior()
        {
            PaneOpen = PaneOpen && !PaneOpen;
        }

        #endregion

        #region Configuring Screen

        private void SetupNavigation(Frame frame)
        {
            _navigation = _container.RegisterNavigationService(frame);
            _navigation.BackRequested += (sender, args) =>
            {
                if (_navigation.CanGoBack)
                    _navigation.GoBack();
                else
                    TryClose();
            };
        }

        #endregion
    }
}