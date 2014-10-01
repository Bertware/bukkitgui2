// ListViewStringSort.cs in bukkitgui2/bukkitgui2
// Created 2014/09/01
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.Controls.SortableListView
{
    public class ListViewStringSort : IComparer
    {
        private readonly int _sortColumn;
        private readonly SortOrder _sortOrder;

        public ListViewStringSort(int sortColumn, SortOrder sortOrder)
        {
            _sortColumn = sortColumn;
            _sortOrder = sortOrder;
        }

        public int Compare(object x, object y)
        {
            try
            {
                int result;
                ListViewItem itemX = (ListViewItem) x;
                ListViewItem itemY = (ListViewItem) y;

                if (_sortColumn == 0)
                {
                    result = String.Compare(itemX.Text.ToLower(), itemY.Text.ToLower(), StringComparison.Ordinal);
                }
                else
                {
                    result = String.Compare(itemX.SubItems[_sortColumn].Text.ToLower(),
                        itemY.SubItems[_sortColumn].Text.ToLower(),
                        StringComparison.Ordinal);
                }
                if (_sortOrder == SortOrder.Descending)
                {
                    result = -result;
                }
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception while sorting listview!" + ex.Message);
                return 1;
            }
        }
    }
}