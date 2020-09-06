using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.InventorAgent.Model
{
    public class CompleteDevice
    {
        public Device Device { get; set; }
        public Hardware Hardware { get; set; }
        public OperativeSystem OperativeSystem { get; set; }
        public InstalledSoftware InstalledSoftware { get; set; }
    }
}
