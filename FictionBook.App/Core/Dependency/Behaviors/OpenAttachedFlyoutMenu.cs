namespace Books.App.Core.Dependency.Behaviors
{
    using Windows.UI.Xaml;
    using Windows.Devices.Input;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;

    using Microsoft.Xaml.Interactivity;

    public class OpenAttachedFlyoutMenu 
        : Behavior<Grid>
    {
        #region Overrides of Behavior<Grid>

        protected override void OnAttached()
        {
            AssociatedObject.Holding += AssociatedObjectOnHolding;
            AssociatedObject.RightTapped += AssociatedObjectOnRightTapped;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.Holding -= AssociatedObjectOnHolding;
            AssociatedObject.RightTapped -= AssociatedObjectOnRightTapped;
        }

        private void AssociatedObjectOnRightTapped(object sender, RightTappedRoutedEventArgs rightTappedRoutedEventArgs)
        {
            if (rightTappedRoutedEventArgs.PointerDeviceType == PointerDeviceType.Mouse)
            {
                
                FlyoutBase.ShowAttachedFlyout((FrameworkElement) sender);
            }
        }
        private void AssociatedObjectOnHolding(object sender, HoldingRoutedEventArgs holdingRoutedEventArgs)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        #endregion
    }
}