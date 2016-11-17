using System;
using Windows.ApplicationModel.Store;
using FictionBook.App.Providers.Contracts;

namespace FictionBook.App.Providers
{
    public class SimulatorInAppPurchase
        : IInAppPurchase
    {
        #region Private Members
        
        private readonly LicenseInformation _licenseInformation = CurrentAppSimulator.LicenseInformation;

        #endregion
        
        #region Implementation of IInAppPurchase

        public async void Purchase(string productId)
        {
            if (!_licenseInformation.ProductLicenses[productId].IsActive)
            {
                try
                {
                    var purchaseResult = await CurrentAppSimulator.RequestProductPurchaseAsync(productId);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        #endregion
    }
}