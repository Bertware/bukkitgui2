using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bukkitgui2.MinecraftInterop.OutputHandler;

namespace Bukkitgui2.AddOn.Console
{
    public partial class ConsoleTab : UserControl, IAddonTab
    {
        public ConsoleTab()
        {
            InitializeComponent();
	        MinecraftOutputHandler.OutputParsed += PrintOutput;
        }

	    public IAddon ParentAddon { get; set; }

		private void PrintOutput(string text, OutputParseResult outputParseResult)
	    {
		   MCCOut.WriteOutput(outputParseResult.Type,outputParseResult.Message);
	    }
    }
}
