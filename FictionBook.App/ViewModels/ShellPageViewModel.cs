using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Books.App.Core;
using Books.App.Core.UI;
using Books.App.Providers.Contracts;
using Caliburn.Micro;

namespace Books.App.ViewModels
{
    public sealed class ShellPageViewModel :
        Screen
    {

        #region Private Members

        private readonly WinRTContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private readonly IMenuProvider _menuProvider;

        private INavigationService _navigation;
        private bool _paneOpen;
        private Visibility _bookCommandBarVisibility = Visibility.Collapsed;

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
        private void PaneBehavior()
        {
            PaneOpen = PaneOpen && !PaneOpen;
        }

        private void MainMenuItemClick(object sender, ItemClickEventArgs eventArgs)
        {
            CollapseAllCommandBars();

            var menuItem = eventArgs.ClickedItem as MenuItem;

            //if (menuItem.Page == typeof(HomePageViewModel))
            //{
            //    _navigation.For<HomePageViewModel>()
            //            .WithParam(x => x.Home, "Passed")
            //            .Navigate();

            //    BookCommandBarVisibility = Visibility.Visible;
            //}

            PaneBehavior();
        }
        private void OptionMenuItemClick(object sender, ItemClickEventArgs eventArgs)
        {
            PaneBehavior();
        }

        #endregion

        #region CommandBars

        public Visibility BookCommandBarVisibility
        {
            get { return _bookCommandBarVisibility; }
            set
            {
                _bookCommandBarVisibility = value;
                NotifyOfPropertyChange();
            }
        }

        #endregion

        #region Configuring Screen

        private void SetupNavigation(Frame frame)
        {
            _navigation = _container.RegisterNavigationService(frame);
            _navigation.BackRequested += (sender, args) =>
            {
                if (_navigation.CanGoBack)
                {
                    _navigation.GoBack();
                }
                else
                    TryClose();
            };
        }

        private void CollapseAllCommandBars()
        {
            BookCommandBarVisibility = Visibility.Collapsed;
        }

        #endregion
    }
}