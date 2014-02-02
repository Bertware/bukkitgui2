using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.MinecraftInterop.OutputHandler
{
	enum  MessageType
	{
		Info,
		Warning,
		Severe,
		JavaStackTrace,
		JavaStatus,
		PlayerJoin,
		PlayerLeave,
		PlayerKick,
		PlayerBan,
		PlayerIpBan,
		Unknown=0
	}
}
