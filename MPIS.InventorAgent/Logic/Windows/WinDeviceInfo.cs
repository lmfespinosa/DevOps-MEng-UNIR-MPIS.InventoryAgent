#region "Libraries"

using MPIS.InventorAgent.Configuration;
using MPIS.InventorAgent.Model;
using System;
using System.Net.NetworkInformation;

#endregion

namespace MPIS.InventorAgent.Logic.Windows
{
    public static class WinDeviceInfo
    {
        public static Device GetDeviceInfo()
        {
            Device dev = new Device()
            {
                MAC = GetMACComputer(),
                ComputerName = Environment.MachineName,
                NameUser = Conf.Configuration.GetSection("NameUser").Value,
            TypeSO = TypeSO.Windows
                
            };

            return dev;
        }


        private static string GetMACComputer() {
            string addr = "";
            foreach (NetworkInterface n in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (n.OperationalStatus == OperationalStatus.Up)
                {
                    addr += n.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return addr;
        }
    }
}
