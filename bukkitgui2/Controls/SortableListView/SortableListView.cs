// SortableListView.cs in bukkitgui2/bukkitgui2
// Created 2014/01/17
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.Controls.SortableListView
{
	internal class SortableListView : ListView
	{
		private int _lastSortColumn = -1;
		private SortOrder _lastSortOrder = SortOrder.Ascending;

		public SortableListView()
		{
			ColumnClick += HandleColumnClick;
		}

		private void HandleColumnClick(object sender, ColumnClickEventArgs e)
		{
			Sort(e.Column, true);
		}

		/// <summary>
		///     Sorts a list view column by string, number, or date.
		/// </summary>
		/// <param name="columnNumber">The column number to sort by</param>
		/// <param name="forceSort">Forces a sort even if no listview tag data exists and assumes a string sort.</param>
		internal void Sort(int columnNumber, bool forceSort = false)
		{
			SortOrder sortOrder;

			if (_lastSortColumn == columnNumber)
			{
				if (_lastSortOrder == SortOrder.Ascending)
				{
					sortOrder = SortOrder.Descending;
				}
				else
				{
					sortOrder = SortOrder.Ascending;
				}
			}
			else
			{
				sortOrder = SortOrder.Ascending;
			}


			for (int i = 0; i <= Columns.Count - 1; i++)
			{
				ColumnHeader c = Columns[i];

				if (i == columnNumber)
				{
					if (sortOrder == SortOrder.Ascending)
					{
						if (!Equals(c.Tag, "nosort"))
							c.Text = '▼' + c.Text.Trim('▲').Trim('▼');
						else
							c.Text = c.Text.Trim('▲').Trim('▼');
					}
					else
					{
						if (!Equals(c.Tag, "nosort"))
							c.Text = '▲' + c.Text.Trim('▲').Trim('▼');
						else
							c.Text = c.Text.Trim('▲').Trim('▼');
					}
				}
				else
				{
					c.Text = c.Text.Trim('▲').Trim('▼');
				}
			}


			// In case a tag wasn't specified check if we should force a string sort
			if (string.IsNullOrEmpty(Convert.ToString(Columns[columnNumber].Tag)))
			{
				Columns[columnNumber].Tag = "String";
				//if (ForceSort)
				//{
				//	this.Columns[ColumnNumber].Tag = "String";
				//}
				//else
				//{
				//	return;
				//}
			}

			switch (Columns[columnNumber].Tag.ToString().ToLower())
			{
				case "numeric":
					ListViewItemSorter = new ListViewNumericSort(columnNumber, sortOrder);
					break;
				case "date":
					ListViewItemSorter = new ListViewDateSort(columnNumber, sortOrder);
					break;
				case "string":
					ListViewItemSorter = new ListViewStringSort(columnNumber, sortOrder);
					break;
				case "nosort":
					ListViewItemSorter = null;
					break;
			}
			_lastSortColumn = columnNumber;
			_lastSortOrder = sortOrder;
			ListViewItemSorter = null;
		}
	}
}