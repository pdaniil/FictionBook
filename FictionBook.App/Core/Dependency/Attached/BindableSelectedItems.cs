namespace Books.App.Core.Dependency.Attached
{
    using System.Collections.Generic;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using Microsoft.Xaml.Interactivity;
    using Microsoft.Toolkit.Uwp.UI.Controls;

    public class BindableSelectedItems 
        : Behavior<AdaptiveGridView>
    {
        public IList<object> SelectedItems
        {
            get { return (IList<object>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IList<object>), typeof(BindableSelectedItems), new PropertyMetadata(null, null));

        #region Overrides of Behavior<AdaptiveGridView>

        protected override void OnAttached()
        {
            AssociatedObject.SelectionChanged += AssociatedObjectOnSelectionChanged;
        }
        
        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObjectOnSelectionChanged;
        }

        private void AssociatedObjectOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            var adaptiveGridView = sender as AdaptiveGridView;
            if (adaptiveGridView != null) this.SelectedItems = adaptiveGridView.SelectedItems;
        }

        #endregion
    }
}