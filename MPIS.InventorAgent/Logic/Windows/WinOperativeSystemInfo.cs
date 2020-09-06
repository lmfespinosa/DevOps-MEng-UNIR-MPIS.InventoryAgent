using MPIS.InventorAgent.Model;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MPIS.InventorAgent.Logic.Windows
{
    public static class WinOperativeSystemInfo
    {
        public static OperativeSystem GetOperativeSystemInfo()
        {
            OperativeSystem op = new OperativeSystem()
            {
                Name = RuntimeInformation.OSDescription
            };

            return op;
        }
    }
}
