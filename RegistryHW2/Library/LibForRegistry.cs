using Microsoft.Win32;
using System;

namespace Library
{
    public static class LibForRegistry
    {
        private static string _fontFamily;
        public static string FontFamily
        {
            get
            {
                if (_fontFamily == null)
                {
                    return "Arial";
                }
                else
                {
                    return _fontFamily;
                }
            }
            set { _fontFamily = value; }
        }

        private static string _foreColor;

        public static string ForeColor
        {
            get
            {
                if (_foreColor == null)
                {
                    return "Black";
                }
                else
                {
                    return _foreColor;
                }
            }
            set { _foreColor = value; }
        }

        private static string _backgroundColor;
        public static string BackgroundColor
        {
            get
            {
                if (_backgroundColor == null)
                {
                    return "White";
                }
                else
                {
                    return _backgroundColor;
                }
            }
            set { _backgroundColor = value; }
        }

        private static double _fontSize;
        public static double FontSize
        {
            get
            {
                if (_fontSize <= 0 || _fontSize >= 100)
                {
                    return 15;
                }
                else
                {
                    return _fontSize;
                }
            }
            set { _fontSize = value; }
        }

        public static void LoadFromRegistry()
        {
            RegistryKey hklm = Microsoft.Win32.Registry.CurrentUser;
            RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            var itStep = hkSoftware.CreateSubKey("ITStep");
            if (itStep.GetValue("FontFamily") != null)
            {
                _fontFamily = itStep.GetValue("FontFamily").ToString();
            }
            if (itStep.GetValue("FontSize") != null)
            {
                _fontSize = Convert.ToDouble(itStep.GetValue("FontSize"));
            }
            if (itStep.GetValue("ForeColor") != null)
            {
                _foreColor = itStep.GetValue("ForeColor").ToString();
            }
            if (itStep.GetValue("BackgroundColor") != null)
            {
                _backgroundColor = itStep.GetValue("BackgroundColor").ToString();
            }
        }

        public static void SaveToRegistry()
        {
            RegistryKey hklm = Microsoft.Win32.Registry.CurrentUser;//LocalMachine;
            RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            var itStep = hkSoftware.CreateSubKey("ITStep");
            itStep.SetValue("FontFamily", _fontFamily);
            itStep.SetValue("FontSize", _fontSize);
            itStep.SetValue("ForeColor", _foreColor);
            itStep.SetValue("BackgroundColor", _backgroundColor);
        }
    }
}
