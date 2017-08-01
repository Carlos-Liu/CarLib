using System.Windows;
using System.Windows.Media;

namespace WpfUtilities
{
  /// <summary>
  /// Extension class for the visual tree helper.
  /// </summary>
  public class VisualTreeHelperEx
  {
    /// <summary>
    /// Get visual child of some visual object
    /// </summary>
    /// <typeparam name="T">Type of return value</typeparam>
    /// <param name="parent">Parent object</param>
    /// <returns>Child object</returns>
    public static T GetVisualChild<T>(Visual parent) where T : Visual
    {
      T child = default(T);
      int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
      for (int i = 0; i < childrenCount; i++)
      {
        var visualChild = (Visual)VisualTreeHelper.GetChild(parent, i);
        child = visualChild as T ?? GetVisualChild<T>(visualChild);
        if (child != null)
        {
          break;
        }
      }
      return child;
    }

    /// <summary>
    /// Get the specified type of parent.
    /// </summary>
    /// <typeparam name="T">The type of the parent of the dependency object.</typeparam>
    /// <param name="d">The dependency object to find parent.</param>
    /// <returns>The parent of the dependency object.</returns>
    public static T GetParent<T>(DependencyObject d) where T : class
    {
      while (d != null && !(d is T))
      {
        d = VisualTreeHelper.GetParent(d);
      }
      return d as T;
    }
  }
}
