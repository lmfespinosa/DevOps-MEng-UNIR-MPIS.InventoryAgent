using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.InventorAgent.Model
{
    public class Hardware
    {
        public List<HardwareDetails> ListHardwareItems { get; set; }
    }

    public class HardwareDetails {
        public string Path { get; set; }
        public string Device { get; set; }
        public TypeHardware TypeHardware { get; set; }
        public string Description { get; set; }
    }
}
