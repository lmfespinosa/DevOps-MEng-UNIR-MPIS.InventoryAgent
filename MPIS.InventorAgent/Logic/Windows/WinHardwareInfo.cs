using MPIS.InventorAgent.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace MPIS.InventorAgent.Logic.Windows
{
    public static class WinHardwareInfo
    {
        public static Hardware GetHardwareInfo()
        {
            Hardware dev = new Hardware();
            List<HardwareDetails> list = new List<HardwareDetails>();
            AddHarwareDevices(ref list);
            dev.ListHardwareItems = list;

            return dev;
        }

        public static void AddHarwareDevices(ref List<HardwareDetails> hardwarelist) {
            var hard = GetInformation("Win32_SystemDevices"); //GetInformation("Win32_OperatingSystem");
            foreach (System.Management.PropertyData i in hard)
            {
                //Console.WriteLine(i.Name.ToString() + ":" + i.Value);
                if (i.Name.Contains("PartComponent")) {
                    hardwarelist.Add(new HardwareDetails()
                    {
                        Path = i.Value.ToString(),
                    });
                }

            }
        }

        private static ArrayList GetInformation(string qry)
        {
            ManagementObjectSearcher searcher;
            int i = 0;
            ArrayList arrayListInformationCollactor = new ArrayList();
            try
            {
                searcher = new ManagementObjectSearcher("SELECT * FROM " + qry);
                foreach (ManagementObject mo in searcher.Get())
                {
                    i++;
                    PropertyDataCollection searcherProperties = mo.Properties;
                    foreach (PropertyData sp in searcherProperties)
                    {
                        arrayListInformationCollactor.Add(sp);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            return arrayListInformationCollactor;
        }
    }
}
