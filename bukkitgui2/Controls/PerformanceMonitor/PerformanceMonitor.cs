using System;
using System.Timers;
using System.Windows.Forms;

namespace Net.Bertware.Bukkitgui2.Controls.PerformanceMonitor
{
	public partial class PerformanceMonitor : UserControl
	{

        private System.Timers.Timer _tmrRefresh = new System.Timers.Timer(1000);
        
		public PerformanceMonitor()
		{
			InitializeComponent();
		}

        private void PerformanceMonitor_Load(object sender, EventArgs e)
        {
            _tmrRefresh = new System.Timers.Timer(1000);
            _tmrRefresh.Elapsed += RefreshData;
        }

        private void PerformanceMonitor_VisibleChanged(object sender, EventArgs e)
        {
            if (_tmrRefresh != null) _tmrRefresh.Enabled = this.Visible; //Do not refresh if invisible
        }

	    private void RefreshData(object sender, ElapsedEventArgs e)
	    {
	        
	    }

	}
}