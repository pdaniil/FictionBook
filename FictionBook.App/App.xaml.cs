using System;
using System.Collections.Generic;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.System.UserProfile;
using Windows.UI.Core;
using Books.App.Providers;
using Books.App.Providers.Contracts;
using Books.App.ViewModels;
using Caliburn.Micro;

namespace Books.App
{
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
        }

        #region Overrides of CaliburnApplication

        protected override void Configure()
        {
            ApplicationLanguages.PrimaryLanguageOverride = GlobalizationPreferences.Languages[0];

            #region Apply Migrations

            //using (var db = new LocalDatabaseContext())
            //{
            //    db.Database.Migrate();
            //}

            #endregion

            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container

            #region PerRequest
                .PerRequest<ShellPageViewModel>()
                .PerRequest<LibraryPageViewModel>()
            #endregion

            #region Singleton
                //.Singleton<LocalDatabaseContext>()
                .Singleton<IMenuProvider, ShellMenuProvider>()
                //.Singleton<IDatabaseProvider, LocalDatabaseProvider>()
            #endregion
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
    }
}
