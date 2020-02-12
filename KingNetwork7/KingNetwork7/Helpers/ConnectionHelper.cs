using System;
using System.Collections.Generic;
using System.Text;

namespace KingNetwork7.Helpers
{
    public static class ConnectionHelper
    {
        public static bool HaveConnection()
        {
            return Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
        }
    }
}
