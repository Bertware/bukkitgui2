// ListViewNumericSort.cs in bukkitgui2/bukkitgui2
// Created 2014/09/01
// ©Bertware, visit http://bertware.net

using System;
using System.Collections;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.Controls.SortableListView
{
	public class ListViewNumericSort : IComparer
	{
		private readonly int _sortColumn;
		private SortOrder _sortOrder;

		public ListViewNumericSort(int sortColumn, SortOrder sortOrder)
		{
			_sortColumn = sortColumn;
			_sortOrder = sortOrder;
		}

		public int Compare(object x, object y)
		{
			int result = 0;
			ListViewItem itemX = (ListViewItem) x;
			ListViewItem itemY = (ListViewItem) y;

			if (_sortColumn == 0)
			{
				result = decimal.Compare(Convert.ToDecimal(itemX.Text), Convert.ToDecimal(itemY.Text));
			}
			else
			{
				result = decimal.Compare(Convert.ToDecimal(itemX.SubItems[_sortColumn].Text),
					Convert.ToDecimal(itemY.SubItems[_sortColumn].Text));
			}
			if (_sortOrder == SortOrder.Descending)
			{
				result = -result;
			}
			return result;
		}
	}
}