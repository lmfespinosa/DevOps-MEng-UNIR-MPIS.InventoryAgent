#region "Libraries"

using MPIS.InventorAgent.Logic.Windows;
using MPIS.InventorAgent.Model;
using System.Runtime.InteropServices;

#endregion

namespace MPIS.InventorAgent.Logic
{
    public static class CompleteDeviceInfo
    {
        public static CompleteDevice GetCompleteInfo() {
            CompleteDevice cpd = new CompleteDevice();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                cpd.Device = WinDeviceInfo.GetDeviceInfo();
                cpd.OperativeSystem = WinOperativeSystemInfo.GetOperativeSystemInfo();
                cpd.Hardware = WinHardwareInfo.GetHardwareInfo();
                cpd.InstalledSoftware = WinInstalledSoftwareInfo.GetInstalledSoftwareInfo();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {

            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {

            }


            return cpd;
        }
    }
}
