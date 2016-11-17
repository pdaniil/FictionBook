using System;
using Windows.ApplicationModel.Store;
using FictionBook.App.Providers.Contracts;

namespace FictionBook.App.Providers
{
    public class MarketInAppPurchase
        : IInAppPurchase
    {
        #region Private Members

        private readonly LicenseInformation _licenseInformation = CurrentApp.LicenseInformation;

        #endregion

        #region Implementation of IInAppPurchase

        public async void Purchase(string productId)
        {
            if (!_licenseInformation.ProductLicenses[productId].IsActive)
            {
                try
                {

                    var purchaseResult = await CurrentApp.RequestProductPurchaseAsync(productId);
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
