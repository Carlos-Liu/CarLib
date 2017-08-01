using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfUtilities
{
  // Refer to https://stackoverflow.com/questions/2189053/disable-mouse-wheel-on-itemscontrol-in-wpf
  // It is not ignoring the MouseWheel event, but 'forwarding' the event back up and out the DataGrid control.
  //
  // e.g. PassthroughMouseWheelAttachedProperty.SetPassthroughMouseWheel(DataGridInstance, true);
  public sealed class PassthroughMouseWheelAttachedProperty
  {
    /// <summary>
    /// Gets the PassthroughMouseWheelProperty property for the specified Data Grid.
    /// </summary>
    /// <param name="gridItem">The data grid instance.</param>
    /// <returns>The PassthroughMouseWheelProperty property for the specified Data Grid.</returns>
    public static bool GetPassthroughMouseWheel(DataGrid gridItem)
    {
      return (bool)gridItem.GetValue(PassthroughMouseWheelProperty);
    }

    /// <summary>
    /// Sets the PassthroughMouseWheelProperty property for the specified Data Grid.
    /// </summary>
    /// <param name="gridItem">The data grid instance.</param>
    /// <param name="value">If pass through the mouse wheel event.</param>
    public static void SetPassthroughMouseWheel(DataGrid gridItem, bool value)
    {
      gridItem.SetValue(PassthroughMouseWheelProperty, value);
    }

    /// <summary>
    /// Attached property to pass through the mouse wheel event.
    /// </summary>
    public static readonly DependencyProperty PassthroughMouseWheelProperty =
      DependencyProperty.RegisterAttached(
      "PassthroughMouseWheel",
      typeof(bool),
      typeof(PassthroughMouseWheelAttachedProperty),
      new UIPropertyMetadata(false, OnPassthroughMouseWheelChanged));

    private static void OnPassthroughMouseWheelChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
    {
      var item = depObj as DataGrid;
      if (item == null)
      {
        return;
      }

      if (!(e.NewValue is bool))
      {
        return;
      }

      if ((bool)e.NewValue)
        item.PreviewMouseWheel += OnPreviewMouseWheel;
      else
        item.PreviewMouseWheel -= OnPreviewMouseWheel;
    }

    // It is not ignoring the MouseWheel event, but 'forwarding' the event back up 
    // and out the DataGrid control. And do nothing if there is vertical scroll bar
    // for the DataGrid, so it still can scroll in the DataGrid in this case.
    private static void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
      var dataGrid = sender as DataGrid;
      if (dataGrid == null)
      {
        return;
      }

      ScrollViewer scrollview = VisualTreeHelperEx.GetVisualChild<ScrollViewer>(dataGrid);
      Visibility verticalVisibility = scrollview.ComputedVerticalScrollBarVisibility;
      if (verticalVisibility == Visibility.Visible)
      {
        // do nothing if there is vertical scroll bar, so can still scroll inside the DataGrid.
        return;
      }

      e.Handled = true;

      var newEvent = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
      {
        RoutedEvent = UIElement.MouseWheelEvent
      };

      dataGrid.RaiseEvent(newEvent);
    }
  }
}
