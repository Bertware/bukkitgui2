namespace Bukkitgui2.MinecraftServers.Servers
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
            get
            {
                return "http://bukkit.org";
            }
        }

        public override Image Logo
        {
            get { return Properties.Resources.bukkit_logo; }
        }

        public override bool CanDownloadRecommendedVersion
        {
            get
            {
                return true;
            }
        }

        public override bool CanDownloadBetaVersion
        {
            get
            {
                return true;
            }
        }

        public override bool CanDownloadDevVersion
        {
            get
            {
                return true;
            }
        }
	}
}
