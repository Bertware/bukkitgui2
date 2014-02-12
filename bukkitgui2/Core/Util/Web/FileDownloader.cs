using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bukkitgui2.Core.Util.Web
{
	public partial class FileDownloader : Form
	{

		private Dictionary<string, string> _files; 
		
		public FileDownloader()
		{
			InitializeComponent();
			_files=new Dictionary<string, string>();
		}

		public Boolean AddFile(string url, string targetlocation)
		{
			_files.Add(url,targetlocation);
			return true;
		}

		public void StartDownload()
		{
			
		}
	}
}
