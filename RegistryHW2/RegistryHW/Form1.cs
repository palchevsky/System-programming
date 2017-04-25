using Library;
using LibraryToFile;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;
/*
* 1. Вынести логику сохранения в реестре в отдельную сборку
* 2. Создать сборку с сохранением в файлы
* 3. Динамически загрузить способ сохранения
*/

namespace RegistryHW
{
    public partial class RegTestForm : Form
    {
        private Color _foreColor;
        private Color _backgroundColor;
        public RegTestForm()
        {
            InitializeComponent();
        }

        private void RegTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rbSaveToXML.Checked==true)
            {
                RegistryKey hklm = Microsoft.Win32.Registry.CurrentUser;
                RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
                var itStep = hkSoftware.CreateSubKey("ITStep");
                if (itStep.GetValue("IsRegistry")!=null)
                {
                    itStep.DeleteValue("IsRegistry");
                }
                LibForXML xml = new LibForXML();
                xml.FontFamily = tbFont.Text;
                xml.FontSize = Convert.ToDouble(numUpDown.Value);
                xml.ForeColor = _foreColor.Name;
                xml.BackgroundColor = _backgroundColor.Name;
                xml.Save();
            }
            else
            {
                RegistryKey hklm = Microsoft.Win32.Registry.CurrentUser;
                RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
                var itStep = hkSoftware.CreateSubKey("ITStep");
                itStep.SetValue("IsRegistry", "1");
                LibForRegistry.FontFamily = tbFont.Text;
                LibForRegistry.FontSize = Convert.ToDouble(numUpDown.Value);
                LibForRegistry.ForeColor = _foreColor.Name;
                LibForRegistry.BackgroundColor = _backgroundColor.Name;
                LibForRegistry.SaveToRegistry();
            }
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            cdColor.AllowFullOpen = false;
            cdColor.ShowHelp = true;
            cdColor.Color = lbHelloWord.ForeColor;
            if (cdColor.ShowDialog() == DialogResult.OK)
            {
                lbHelloWord.BackColor = cdColor.Color;
                _backgroundColor = cdColor.Color;
            }
        }

        private void btBackgroundColor_Click(object sender, EventArgs e)
        {

            cdBackgroundColor.AllowFullOpen = false;
            cdBackgroundColor.ShowHelp = true;
            cdBackgroundColor.Color = lbHelloWord.ForeColor;
            if (cdBackgroundColor.ShowDialog() == DialogResult.OK)
            {
                lbHelloWord.ForeColor = cdBackgroundColor.Color;
                _foreColor = cdBackgroundColor.Color;
            }
        }

        private void RegTestForm_Load(object sender, EventArgs e)
        {
            RegistryKey hklm = Microsoft.Win32.Registry.CurrentUser;
            RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            var itStep = hkSoftware.CreateSubKey("ITStep");
            var inRegistry=itStep.GetValue("IsRegistry");
            if (inRegistry!=null)
            {

                LibForRegistry.LoadFromRegistry();
                lbHelloWord.Font = new Font(LibForRegistry.FontFamily, (float)LibForRegistry.FontSize);
                lbHelloWord.BackColor = Color.FromName(LibForRegistry.BackgroundColor);
                _backgroundColor = Color.FromName(LibForRegistry.BackgroundColor);
                lbHelloWord.ForeColor = Color.FromName(LibForRegistry.ForeColor);
                _foreColor = Color.FromName(LibForRegistry.ForeColor);
                tbFont.Text = LibForRegistry.FontFamily;
                numUpDown.Value = Convert.ToDecimal(LibForRegistry.FontSize);
                rbSaveToRegistry.Checked = true;
            }
            else
            {
                LibForXML file = new LibForXML();
                file.Load();
                _foreColor = Color.FromName(file.ForeColor);
                _backgroundColor = Color.FromName(file.BackgroundColor);
                lbHelloWord.Font = new Font(file.FontFamily, (float)file.FontSize);
                lbHelloWord.BackColor = Color.FromName(file.BackgroundColor);
                lbHelloWord.ForeColor = Color.FromName(file.ForeColor);
                tbFont.Text = file.FontFamily;
                numUpDown.Value = Convert.ToDecimal(file.FontSize);
                rbSaveToXML.Checked = true;
            }
        }
    }
}
