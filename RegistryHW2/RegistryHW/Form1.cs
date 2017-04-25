﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using Microsoft.Win32;
using LibraryToFile;
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
            //_foreColor = lbHelloWord.ForeColor;
            //_backgroundColor = lbHelloWord.BackColor;
        }


        private void RegTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LibForXML xml = new LibForXML();
            xml.FontFamily = tbFont.Text;
            xml.FontSize = Convert.ToDouble(numUpDown.Value);
            xml.ForeColor = _foreColor.Name;
            xml.BackgroundColor = _backgroundColor.Name;
            xml.Save();


            //LibForRegistry.FontFamily = tbFont.Text;
            //LibForRegistry.FontSize = Convert.ToDouble(numUpDown.Value);
            //LibForRegistry.ForeColor = _foreColor.Name;
            //LibForRegistry.BackgroundColor = _backgroundColor.Name;
            //LibForRegistry.SaveToRegistry();
            //RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
            //RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            ////RegistryKey itStep = hkSoftware.OpenSubKey("itStep");
            //var itStep = hkSoftware.CreateSubKey("ITStep");
            //itStep.SetValue("FontFamily", tbFont.Text);
            //itStep.SetValue("FontSize", numUpDown.Value);
            //itStep.SetValue("ForeColor", cdColor.Color.Name);
            //itStep.SetValue("BackgroundColor", cdBackgroundColor.Color.Name);

            //lbHelloWord.Size = ()tbTextSize.Text;
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
            LibForXML file = new LibForXML();
            file.Load();
            lbHelloWord.Font = new Font(file.FontFamily, (float)file.FontSize);
            lbHelloWord.BackColor = Color.FromName(file.BackgroundColor);
            lbHelloWord.ForeColor = Color.FromName(file.ForeColor);
            tbFont.Text = file.FontFamily;
            numUpDown.Value = Convert.ToDecimal(file.FontSize);


            ////////////////////////////////
            //LibForRegistry.LoadFromRegistry();
            //lbHelloWord.Font = new Font(LibForRegistry.FontFamily, (float)LibForRegistry.FontSize);
            //lbHelloWord.BackColor = Color.FromName(LibForRegistry.BackgroundColor);
            //lbHelloWord.ForeColor = Color.FromName(LibForRegistry.ForeColor);
            //tbFont.Text = LibForRegistry.FontFamily;
            //numUpDown.Value = Convert.ToDecimal(LibForRegistry.FontSize);

            //_foreColor = lbHelloWord.ForeColor;
            //_backgroundColor = lbHelloWord.BackColor;
            //RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
            //RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            ////RegistryKey itStep = hkSoftware.OpenSubKey("itStep");
            //var itStep = hkSoftware.CreateSubKey("ITStep");
            //itStep.GetValue().SetValue("FontName", "Delete this");
            //itStep.SetValue("NumberValue", 234);
            //RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
            //RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            ////RegistryKey itStep = hkSoftware.OpenSubKey("itStep");
            //var itStep = hkSoftware.CreateSubKey("ITStep");
            //string fontFamily = "Arial";
            //double fontSize=15;
            //string foreColor="Black";
            //string backgroundColor="White";
            //if (itStep.GetValue("FontFamily")!=null)
            //{
            //    fontFamily = itStep.GetValue("FontFamily").ToString();
            //}
            //else
            //{
            //    itStep.SetValue("FontFamily", fontFamily);
            //}
            //if (itStep.GetValue("FontSize") != null)
            //{
            //    fontSize = Convert.ToDouble(itStep.GetValue("FontSize"));
            //}
            //else
            //{
            //    itStep.SetValue("FontSize", fontSize);
            //}
            //if (itStep.GetValue("ForeColor") != null)
            //{
            //    foreColor = itStep.GetValue("ForeColor").ToString();
            //}
            //else
            //{
            //    itStep.SetValue("ForeColor", foreColor);
            //}
            //if (itStep.GetValue("BackgroundColor") != null)
            //{
            //    backgroundColor = itStep.GetValue("BackgroundColor").ToString();
            //}
            //else
            //{
            //    itStep.SetValue("BackgroundColor", backgroundColor);
            //}
            //itStep.SetValue("FontFamily", lbHelloWord.Font.FontFamily);
            //itStep.SetValue("FontSize", lbHelloWord.Font.Size);
            //itStep.SetValue("ForeColor", lbHelloWord.ForeColor.Name);
            //itStep.SetValue("BackgroundColor", lbHelloWord.BackColor.Name);

            //lbHelloWord.Font = new Font(new FontFamily(fontFamily), (float)fontSize);
            //lbHelloWord.ForeColor = new Color(foreColor);


            //var regString = itStep.GetValue("MyString");
            //var numValue = itStep.GetValue("NumberValue");



            //lbHelloWord.Font= new Font(new FontFamily(tbFont.Text), (float)numUpDown.Value);
        }

        private void btTest_Click(object sender, EventArgs e)
        {

        }
    }
}
