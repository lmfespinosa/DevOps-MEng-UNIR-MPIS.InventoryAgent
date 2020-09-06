using Microsoft.Win32;
using MPIS.InventorAgent.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.InventorAgent.Logic.Windows
{
    public static class WinInstalledSoftwareInfo
    {
        public static InstalledSoftware GetInstalledSoftwareInfo()
        {
            InstalledSoftware dev = new InstalledSoftware();
            List<SoftwareDetail> list = new List<SoftwareDetail>();
            AddHarwareDevices(ref list);
            dev.ListSoftware = list;

            return dev;
        }

        public static void AddHarwareDevices(ref List<SoftwareDetail> hardwarelist)
        {
            /*var hard = GetInformation("Win32_SystemDevices"); //GetInformation("Win32_OperatingSystem");
            foreach (System.Management.PropertyData i in hard)
            {
                //Console.WriteLine(i.Name.ToString() + ":" + i.Value);
                if (i.Name.Contains("PartComponent"))
                {
                    hardwarelist.Add(new HardwareDetails()
                    {
                        Path = i.Value.ToString(),
                    });
                }

            }*/



            string p_name = "";
            string displayName;
            RegistryKey key;

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                /*if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }*/
                //Console.WriteLine(displayName.ToString());
                hardwarelist.Add(new SoftwareDetail()
                {
                    Name = displayName != null ? displayName.ToString() : "",
                });

            }

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                /*if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }*/
                //Console.WriteLine(displayName != null ? displayName.ToString() : "");

                hardwarelist.Add(new SoftwareDetail()
                {
                    Name = displayName != null ? displayName.ToString() : "",
                });
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                /*if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }*/
                hardwarelist.Add(new SoftwareDetail()
                {
                    Name = displayName != null ? displayName.ToString() : "",
                });
            }

            
        }

       
    }
}
