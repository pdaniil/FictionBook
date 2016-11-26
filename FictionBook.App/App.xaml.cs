using Books.App.Core.Database;
using Books.App.Managers;
using Books.App.Managers.Contracts;

namespace Books.App
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Windows.UI.Core;
    using Windows.Globalization;
    using Windows.ApplicationModel;
    using Windows.System.UserProfile;
    using Windows.ApplicationModel.Activation;

    using Microsoft.EntityFrameworkCore;

    using Caliburn.Micro;

    using Providers;
    using ViewModels;
    using Providers.Contracts;

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App
    {
        #region Private Members

        private WinRTContainer _container;
        private IEventAggregator _eventAggregator;

        #endregion

        public App()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        #region Overrides of CaliburnApplication

        protected override void Configure()
        {
            ApplicationLanguages.PrimaryLanguageOverride = GlobalizationPreferences.Languages[0];

            #region Migrations

            using (var db = new LocalDbContext())
            {
                db.Database.Migrate();
            }

            #endregion

            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container
                .PerRequest<ShellPageViewModel>()
                .PerRequest<LibraryPageViewModel>()
                .Singleton<LocalDbContext>()
                .Singleton<IMenuProvider, ShellMenuProvider>()
                .Singleton<IDbBookProvider, LocalDbBookProvider>()
                .Singleton<IStorageBookProvider, LocalStorageBookProvider>()
                .Singleton<IBookManager, BookManager>()
#if DEBUG
                .Singleton<IInAppPurchase, SimulatorInAppPurchase>();
#else
                .Singleton<IInAppPurchase, MarketInAppPurchase>();
#endif

            _eventAggregator = _container.GetInstance<IEventAggregator>();

            var navigation = SystemNavigationManager.GetForCurrentView();
            navigation.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootViewFor<ShellPageViewModel>();

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //_eventAggregator.PublishOnUIThread(new ResumeMessage());
            }
        }

        protected override void OnSuspending(object sender, SuspendingEventArgs e)
        {
            //_eventAggregator.PublishOnUIThread(new SuspendMessage());
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        #endregion

        #region Overrides of Application

        protected override void OnFileActivated(FileActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootViewFor<ShellPageViewModel>();

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //_eventAggregator.PublishOnUIThread(new ResumeMessage());
            }
        }

        #endregion
    }
}
