namespace Books.App.Providers
{
    using System;

    using Windows.ApplicationModel.Store;

    using Contracts;

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
