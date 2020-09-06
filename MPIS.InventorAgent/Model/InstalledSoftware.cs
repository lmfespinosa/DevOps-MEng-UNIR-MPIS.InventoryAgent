using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.InventorAgent.Model
{
    public class InstalledSoftware
    {
        public List<SoftwareDetail> ListSoftware { get; set; }
    }

    public class SoftwareDetail { 
    
    public string Name { get; set; }
    }
}
