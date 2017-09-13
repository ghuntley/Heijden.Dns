using System;
using System.Net;
using System.Net.Sockets;

namespace Heijden.DNS
{
	internal static class IpV6Extensions
	{
		public static void DisableIpV6Only(this Socket socket)
		{
			try
			{
				// This operation throws when running on mono since it is off by default
				socket.SetSocketOption(SocketOptionLevel.IPv6, (SocketOptionName)27, false);
			}
			catch { }
		}

		public static IPAddress ConvertIpToUnifiedIpv6(IPAddress address)
		{
			if (address.AddressFamily == AddressFamily.InterNetworkV6)
				return address;
			else if (address.AddressFamily == AddressFamily.InterNetwork)
				return IPAddress.Parse("::FFFF:" + address.ToString());
			else
				throw new InvalidOperationException("This AddressFamily is not supported.");
		}

	}
}
