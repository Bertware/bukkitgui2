using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bukkitgui2.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            Core.Share.MainFormHandle = this.Handle; //Immediatly set the handle for form operations, tray issues, etc...

            // We need to load all the background stuff before we can start running the application
            // This can take a couple of seconds, so show a splashscreen
            // We have a splashscreen class that loads everything multithreaded, we just need it to show and wait until it's finished.
            SplashScreen Splash = new SplashScreen(); // Create splashscreen
            Splash.ShowDialog(); // Call ShowDialog(). This will show the splashscreen on foreground until it closes.

            // Start loading everything to the UI
            InitializeComponent();

        }
    }
}
