namespace Net.Bertware.Bukkitgui2.MinecraftServers.Servers
{
    using System.Drawing;

    class BukkitServer : MinecraftServerBase
	{
        public override string Name
        {
            get { return "Bukkit"; }
        }

        public override string Site
        {
            get{return "http://bukkit.org";}
        }

        public override Image Logo
        {
            get { return Properties.Resources.bukkit_logo; }
        }

	    public override bool CanFetchRecommendedVersion
	    {
		    get { return true; }
	    }

		public override bool CanFetchBetaVersion
		{
			get { return true; }
		}

		public override bool CanFetchDevVersion
		{
			get { return true; }
		}

	    public override bool CanDownloadRecommendedVersion
        {
            get{return true;}
        }

        public override bool CanDownloadBetaVersion
        {
            get{return true;}
        }

        public override bool CanDownloadDevVersion
        {
            get{return true;}
        }

	    public override bool CanGetCurrentVersion
	    {
		    get { return true; }
	    }

	    public override bool SupportsPlugins
	    {
		    get { return true; }
	    }

		public override string GetLaunchFlags(string defaultFlags = "")
		{
			return "-nojline" + defaultFlags;
		}


	}
}
