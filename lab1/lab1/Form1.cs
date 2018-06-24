using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using BussLogic;
using Moq;

namespace lab1
{
    public partial class Form1 : Form
    {
        Interactor interctr = new Interactor();
        public Form1()
        {
            InitializeComponent();
            SetWebBrowserCompatiblityLevel();
            //string curDir = Directory.GetCurrentDirectory();
            //this.webBrowser2.Url = new Uri(String.Format("file:///{0}/mapbasics.html", curDir));
            string appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            webBrowser2.Url = new Uri(Path.Combine(appDir, @"mapbasics.html"));
            webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(runWebScripts);
            webBrowser2.Document.InvokeScript("mapbasics.js");
            textBox_ll.Text = interctr.latitude + "," + interctr.longitude;
            textBox_radius.Text = interctr.radius.ToString();
            textBox_res.ScrollBars = ScrollBars.Vertical;
            comboBox1.SelectedIndex = 1;
        }


        void runWebScripts(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser2.Document.InvokeScript("mapbasics.js", new object[] { });
        }

        private static void SetWebBrowserCompatiblityLevel()
        {
            string appName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            int lvl = 1000 * GetBrowserVersion();
            bool fixVShost = File.Exists(Path.ChangeExtension(Application.ExecutablePath, ".vshost.exe"));

            WriteCompatiblityLevel("HKEY_LOCAL_MACHINE", appName + ".exe", lvl);
            if (fixVShost) WriteCompatiblityLevel("HKEY_LOCAL_MACHINE", appName + ".vshost.exe", lvl);

            WriteCompatiblityLevel("HKEY_CURRENT_USER", appName + ".exe", lvl);
            if (fixVShost) WriteCompatiblityLevel("HKEY_CURRENT_USER", appName + ".vshost.exe", lvl);
        }

        private static void WriteCompatiblityLevel(string root, string appName, int lvl)
        {
            try
            {
                Microsoft.Win32.Registry.SetValue(root + @"\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, lvl);
            }
            catch (Exception)
            {
            }
        }

        public static int GetBrowserVersion()
        {
            string strKeyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer";
            string[] ls = new string[] { "svcVersion", "svcUpdateVersion", "Version", "W2kVersion" };

            int maxVer = 0;
            for (int i = 0; i < ls.Length; ++i)
            {
                object objVal = Microsoft.Win32.Registry.GetValue(strKeyPath, ls[i], "0");
                string strVal = Convert.ToString(objVal);
                if (strVal != null)
                {
                    int iPos = strVal.IndexOf('.');
                    if (iPos > 0)
                        strVal = strVal.Substring(0, iPos);

                    int res = 0;
                    if (int.TryParse(strVal, out res))
                        maxVer = Math.Max(maxVer, res);
                }
            }

            return maxVer;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            HtmlElementCollection document = webBrowser2.Document.All;
            for (int i = 0; i < document.Count; i++)
            {
                if (document[i].InnerText != null && document[i].InnerText.Contains("Координаты щелчка:"))
                {
                    int index = document[i].InnerText.IndexOf("Координаты щелчка:") + 19;
                    textBox_ll.Text = document[i].InnerText.Substring(index, 16).Trim();
                    textBox_ll.Text.Replace(" ", "");
                    interctr.latitude = textBox_ll.Text.GetUntilOrEmpty(false);
                    interctr.longitude = textBox_ll.Text.GetUntilOrEmpty(true);
                    break;
                }
            }
            IEnumerable<Foursquare.Venue> list = interctr.get_json();
            string results = interctr.get_info(list);

            textBox_res.Text = results;
        }

        private void textBox_radius_TextChanged(object sender, EventArgs e)
        {
            int radius = 1000;
            Int32.TryParse(textBox_radius.Text, out radius);
            interctr.radius = radius;
        }

        private void textBox_radius_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox_ll_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox_ll_TextChanged(object sender, EventArgs e)
        {
            interctr.latitude = textBox_ll.Text.GetUntilOrEmpty(false);
            interctr.longitude = textBox_ll.Text.GetUntilOrEmpty(true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
                interctr.selectCategory = comboBox1.SelectedIndex - 1;
        }

    }
}
