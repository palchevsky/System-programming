using Microsoft.Win32;
using System;

namespace Library
{
    public class LibForRegistry
    {
        public void Load(ref string fontFamily, ref string foreColor, ref string backgroundColor, ref double fontSize)
        {
            fontFamily = "Arial";
            foreColor = "Navy";
            backgroundColor = "Black";
            fontSize = 15;
            RegistryKey hklm = Microsoft.Win32.Registry.CurrentUser;
            RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            var itStep = hkSoftware.CreateSubKey("ITStep");
            if (itStep.GetValue("FontFamily") != null)
            {
                fontFamily = itStep.GetValue("FontFamily").ToString();
            }
            if (itStep.GetValue("FontSize") != null)
            {
                fontSize = Convert.ToDouble(itStep.GetValue("FontSize"));
            }
            if (itStep.GetValue("ForeColor") != null)
            {
                foreColor = itStep.GetValue("ForeColor").ToString();
            }
            if (itStep.GetValue("BackgroundColor") != null)
            {
                backgroundColor = itStep.GetValue("BackgroundColor").ToString();
            }
        }

        public void Save(string fontFamily, string foreColor, string backgroundColor, double fontSize)
        {
            RegistryKey hklm = Microsoft.Win32.Registry.CurrentUser;//LocalMachine;
            RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            var itStep = hkSoftware.CreateSubKey("ITStep");
            itStep.SetValue("FontFamily", fontFamily);
            itStep.SetValue("FontSize", fontSize);
            itStep.SetValue("ForeColor", foreColor);
            itStep.SetValue("BackgroundColor", backgroundColor);
        }
    }
}
