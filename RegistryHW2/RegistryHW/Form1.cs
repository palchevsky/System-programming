//using Library;
//using LibraryToFile;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

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
        private string _foreColorStr;
        private string _backgroundColorStr;
        private double _fontSize;
        private string _fontFamily;

        public RegTestForm()
        {
            InitializeComponent();
        }

        private void RegTestForm_Load(object sender, EventArgs e)
        {
            if (IsInRegistry())
            {
                try
                {
                    //Загрузка из реестра
                    LoadViaLib("Library.dll", "Library.LibForRegistry");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SetParameters();
                rbSaveToRegistry.Checked = true;
            }
            else
            {
                try
                {
                    //Загрузка из файла XML
                    LoadViaLib("LibraryToFile.dll", "LibraryToFile.LibForXML");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SetParameters();
                rbSaveToXML.Checked = true;
            }
        }

        private void LoadViaLib(string assemblyName, string typeName)
        {
            try
            {
                Assembly asm = Assembly.LoadFrom(assemblyName);
                Type lib = asm.GetType(typeName, true, true);
                object instObj = Activator.CreateInstance(lib);
                MethodInfo Load = instObj.GetType().GetMethod("Load");
                object[] outParameters = new object[] { _fontFamily, _foreColorStr,
                     _backgroundColorStr, _fontSize};
                object result = Load.Invoke(instObj, outParameters);
                _fontFamily = (string)outParameters[0];
                _foreColorStr = (string)outParameters[1];
                _backgroundColorStr = (string)outParameters[2];
                _fontSize = (double)outParameters[3];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetParameters()
        {
            _foreColor = Color.FromName(_foreColorStr);
            _backgroundColor = Color.FromName(_backgroundColorStr);
            lbHelloWord.Font = new Font(_fontFamily, (float)_fontSize);
            lbHelloWord.BackColor = _backgroundColor;
            lbHelloWord.ForeColor = _foreColor;
            tbFont.Text = _fontFamily;
            numUpDown.Value = Convert.ToDecimal(_fontSize);
        }

        private static bool IsInRegistry()
        {
            RegistryKey hklm = Registry.CurrentUser;
            RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            var itStep = hkSoftware.CreateSubKey("ITStep");
            if (itStep.GetValue("IsRegistry") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RegTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rbSaveToXML.Checked == true)
            {
                RegistryKey hklm = Registry.CurrentUser;
                RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
                var itStep = hkSoftware.CreateSubKey("ITStep");
                if (itStep.GetValue("IsRegistry") != null)
                {
                    itStep.DeleteValue("IsRegistry");//Сохраняем в файл, а не в реестр
                }
                SaveViaLib("LibraryToFile.dll", "LibraryToFile.LibForXML");
            }
            else
            {
                RegistryKey hklm = Registry.CurrentUser;
                RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
                var itStep = hkSoftware.CreateSubKey("ITStep");
                itStep.SetValue("IsRegistry", "1");//Будем проверять при загрузке
                SaveViaLib("Library.dll", "Library.LibForRegistry");
            }
        }

        private void SaveViaLib(string assemblyName, string typeName)
        {
            try
            {
                Assembly asm = Assembly.LoadFrom(assemblyName);
                Type lib = asm.GetType(typeName, true, true);
                object instObj = Activator.CreateInstance(lib);
                MethodInfo Save = instObj.GetType().GetMethod("Save");
                object result = Save.Invoke(instObj, new object[] {
                tbFont.Text, _foreColor.Name,
                     _backgroundColor.Name, Convert.ToDouble(numUpDown.Value)});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
