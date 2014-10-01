// ListViewDateSort.cs in bukkitgui2/bukkitgui2
// Created 2014/09/01
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.Controls.SortableListView
{
    public class ListViewDateSort : IComparer
    {
        private readonly int _sortColumn;

        private readonly SortOrder _sortOrder;

        public ListViewDateSort(int sortColumn, SortOrder sortOrder)
        {
            _sortColumn = sortColumn;
            _sortOrder = sortOrder;
        }

        public int Compare(object x, object y)
        {
            int result;
            ListViewItem itemX = (ListViewItem) x;
            ListViewItem itemY = (ListViewItem) y;
            if (_sortColumn == 0)
            {
                result = DateTime.Compare(DateTime.Parse(itemX.Text), DateTime.Parse(itemY.Text));
            }
            else
            {
                result = DateTime.Compare(DateTime.Parse(itemX.SubItems[_sortColumn].Text),
                    DateTime.Parse(itemY.SubItems[_sortColumn].Text));
            }
            if (_sortOrder == SortOrder.Descending)
            {
                result = -result;
            }
            return result;
        }
    }
}