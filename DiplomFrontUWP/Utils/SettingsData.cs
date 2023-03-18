using DiplomFrontUWP.Utils.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomFrontUWP.Utils
{
    public static class SettingsData
    {
        public static List<USBPortsResponse> COMPorts;
        public static string SelectedComPort = "COM1";
    }
}
