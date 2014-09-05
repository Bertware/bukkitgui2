// ColorPicker.cs in bukkitgui2/bukkitgui2
// Created 2014/06/26
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.Controls.ColorPicker
{
	public partial class ColorPicker : UserControl
	{
		public ColorPicker()
		{
			InitializeComponent();
		}

		public delegate void ColorChangedEventHandler(Color color);

		/// <summary>
		///     Raised when the color is changed
		/// </summary>
		public event ColorChangedEventHandler ColorChanged;

		private void RaiseColorChangedEvent()
		{
			ColorChangedEventHandler handler = ColorChanged;
			if (handler != null) handler.Invoke(Color);
		}

		private Color _color;

		/// <summary>
		///     The selected color
		/// </summary>
		public Color Color
		{
			get { return _color; }
			set
			{
				_color = value;
				BackColor = value;
			}
		}

		private void ColorPicker_Click(object sender, EventArgs e)
		{
			PickColor();
		}

		private void PickColor()
		{
			ColorDialog cd = new ColorDialog {Color = Color};
			cd.ShowDialog();
			Color = cd.Color;
			RaiseColorChangedEvent();
		}
	}
}