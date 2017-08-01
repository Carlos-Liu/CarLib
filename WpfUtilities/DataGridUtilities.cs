using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WpfUtilities
{
  /// <summary>
  /// Utilities class for DataGrid.
  /// </summary>
  public class DataGridUtilities
  {
    /// <summary>
    /// Get row information instance
    /// </summary>
    /// <param name="grid">Data-grid object</param>
    /// <param name="index">Row index</param>
    /// <returns>Row object information</returns>
    public static DataGridRow GetRow(DataGrid grid, int index)
    {
      var row = grid.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;

      if (row == null)
      {
        // may be visualized, bring into view and try again
        grid.UpdateLayout();
        grid.ScrollIntoView(grid.Items[index]);
        row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
      }
      return row;
    }

    /// <summary>
    /// Get the data grid cell based on the specified row index and column index.
    /// </summary>
    /// <param name="host">The data grid instance to be searched.</param>
    /// <param name="rowIndex">The row index of the cell.</param>
    /// <param name="columnIndex">The column index of the cell.</param>
    /// <returns>The cell object to be searched, or return null if it cannot be find.</returns>
    public static DataGridCell GetCell(DataGrid host, int rowIndex, int columnIndex)
    {
      var row = GetRow(host, rowIndex);
      if (row == null)
      {
        return null;
      }

      var cell = GetCell(host, row, columnIndex);
      return cell;
    }

    /// <summary>
    /// Get cell information
    /// </summary>
    /// <param name="host">Data grid object</param>
    /// <param name="row">Row object</param>
    /// <param name="columnIndex">Column index</param>
    /// <returns></returns>
    public static DataGridCell GetCell(DataGrid host, DataGridRow row, int columnIndex)
    {
      if (row == null) return null;

      var presenter = VisualTreeHelperEx.GetVisualChild<DataGridCellsPresenter>(row);
      if (presenter == null)
      {
        row.ApplyTemplate();
        presenter = VisualTreeHelperEx.GetVisualChild<DataGridCellsPresenter>(row);
      }

      // try to get the cell but it may possibly be visualized
      var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
      if (cell == null)
      {
        // now try to bring into view and retrieve the cell
        host.UpdateLayout();
        host.ScrollIntoView(row, host.Columns[columnIndex]);
        cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
      }
      return cell;
    }

    /// <summary>
    /// Get the row index and column index for the editing cell in specified data grid control.
    /// </summary>
    /// <param name="dataGrid">The data grid control to find editing cell.</param>
    /// <param name="rowIndex">The row index of the editing cell.</param>
    /// <param name="columnIndex">The column index of the editing cell.</param>
    /// <returns>Return True if get the cell information, else return false.</returns>
    public static bool GetEditingCellInfo(DataGrid dataGrid, out int rowIndex, out int columnIndex)
    {
      rowIndex = -1;
      columnIndex = -1;

      if (dataGrid == null)
      {
        return false;
      }

      // Get the row and column index of the focused cell.
      var currentFocusedCell = dataGrid.CurrentCell;
      var row = dataGrid.ItemContainerGenerator.ContainerFromItem(currentFocusedCell.Item) as DataGridRow;
      if (row == null)
      {
        return false;
      }

      columnIndex = currentFocusedCell.Column.DisplayIndex;
      rowIndex = row.GetIndex();
      return true;
    }
  }
}
