using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegistryHW
{
    public partial class RegTestForm : Form
    {
        public RegTestForm()
        {
            InitializeComponent();
        }


        private void RegTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
            RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            //RegistryKey itStep = hkSoftware.OpenSubKey("itStep");
            var itStep = hkSoftware.CreateSubKey("ITStep");
            itStep.SetValue("FontFamily", tbFont.Text);
            itStep.SetValue("FontSize", numUpDown.Value);
            itStep.SetValue("ForeColor", cdColor.Color.Name);
            itStep.SetValue("BackgroundColor", cdBackgroundColor.Color.Name);







            //lbHelloWord.Font = new Font(new FontFamily(lbHelloWord.Text), 1);
            //lbHelloWord.Size = ()tbTextSize.Text;
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            cdColor.AllowFullOpen = false;
            cdColor.ShowHelp = true;
            cdColor.Color = lbHelloWord.ForeColor;
            if (cdColor.ShowDialog() == DialogResult.OK)
                lbHelloWord.ForeColor = cdColor.Color;
        }

        private void btBackgroundColor_Click(object sender, EventArgs e)
        {

            cdBackgroundColor.AllowFullOpen = false;
            cdBackgroundColor.ShowHelp = true;
            cdBackgroundColor.Color = lbHelloWord.ForeColor;
            if (cdBackgroundColor.ShowDialog() == DialogResult.OK)
                lbHelloWord.ForeColor = cdBackgroundColor.Color;
        }

        private void RegTestForm_Load(object sender, EventArgs e)
        {
            //RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
            //RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            ////RegistryKey itStep = hkSoftware.OpenSubKey("itStep");
            //var itStep = hkSoftware.CreateSubKey("ITStep");
            //itStep.GetValue().SetValue("FontName", "Delete this");
            //itStep.SetValue("NumberValue", 234);

            RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
            RegistryKey hkSoftware = hklm.OpenSubKey("Software", true);
            //RegistryKey itStep = hkSoftware.OpenSubKey("itStep");
            var itStep = hkSoftware.CreateSubKey("ITStep");
            string fontFamily = "Arial";
            double fontSize=15;
            string foreColor="Black";
            string backgroundColor="White";

            if (itStep.GetValue("FontFamily")!=null)
            {
                fontFamily = itStep.GetValue("FontFamily").ToString();
            }
            else
            {
                itStep.SetValue("FontFamily", fontFamily);
            }

            if (itStep.GetValue("FontSize") != null)
            {
                fontSize = Convert.ToDouble(itStep.GetValue("FontSize"));
            }
            else
            {
                itStep.SetValue("FontSize", fontSize);
            }

            if (itStep.GetValue("ForeColor") != null)
            {
                foreColor = itStep.GetValue("ForeColor").ToString();
            }
            else
            {
                itStep.SetValue("ForeColor", foreColor);
            }

            if (itStep.GetValue("BackgroundColor") != null)
            {
                backgroundColor = itStep.GetValue("BackgroundColor").ToString();
            }
            else
            {
                itStep.SetValue("BackgroundColor", backgroundColor);
            }




            //itStep.SetValue("FontFamily", lbHelloWord.Font.FontFamily);
            //itStep.SetValue("FontSize", lbHelloWord.Font.Size);
            //itStep.SetValue("ForeColor", lbHelloWord.ForeColor.Name);
            //itStep.SetValue("BackgroundColor", lbHelloWord.BackColor.Name);

            lbHelloWord.Font = new Font(new FontFamily(fontFamily), (float)fontSize);
            //lbHelloWord.ForeColor = new Color(foreColor);


            //var regString = itStep.GetValue("MyString");
            //var numValue = itStep.GetValue("NumberValue");



            //lbHelloWord.Font= new Font(new FontFamily(tbFont.Text), (float)numUpDown.Value);
        }
    }
}
