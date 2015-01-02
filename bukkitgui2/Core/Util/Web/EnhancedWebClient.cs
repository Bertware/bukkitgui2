using System;
using System.Net;

namespace Net.Bertware.Bukkitgui2.Core.Util.Web
{
	public class EnhancedWebClient : WebClient
	{
		protected override WebRequest GetWebRequest(Uri uri)
		{
			WebRequest w = base.GetWebRequest(uri);
			w.Timeout = 10*60*1000;
			return w;
		}
	}
}