using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Nocksoft.IO.ConfigFiles;

namespace UplaySwitcher
{
    public partial class Form1 : Form
    {

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UplaySwitcher");
        string filePath = "cache.txt";
        INIFile iniFile = new INIFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UplaySwitcher") + "\\settings.ini");
        public Form1()
        {
            InitializeComponent();
            InitializeSettings();
        }

        //Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            string nr = "1";
            CreateLocalUser("UplaySwitcher" + nr);
            button1.Enabled = false;
            button2.Enabled = true;
            button11.Enabled = true;
            iniFile.SetValue("Settings", "profile" + nr, "1");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string nr = "1";
            RemoveLocalUser("UplaySwitcher" + nr);
            button1.Enabled = true;
            button2.Enabled = false;
            button11.Enabled = false;
            iniFile.SetValue("Settings", "profile" + nr, "0");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string nr = "2";
            CreateLocalUser("UplaySwitcher" + nr);
            button3.Enabled = false;
            button7.Enabled = true;
            button12.Enabled = true;
            iniFile.SetValue("Settings", "profile" + nr, "1");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string nr = "2";
            RemoveLocalUser("UplaySwitcher" + nr);
            button3.Enabled = true;
            button7.Enabled = false;
            button12.Enabled = false;
            iniFile.SetValue("Settings", "profile" + nr, "0");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nr = "3";
            CreateLocalUser("UplaySwitcher" + nr);
            button4.Enabled = false;
            button8.Enabled = true;
            button13.Enabled = true;
            iniFile.SetValue("Settings", "profile" + nr, "1");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string nr = "3";
            RemoveLocalUser("UplaySwitcher" + nr);
            button4.Enabled = true;
            button8.Enabled = false;
            button13.Enabled = false;
            iniFile.SetValue("Settings", "profile" + nr, "0");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string nr = "4";
            CreateLocalUser("UplaySwitcher" + nr);
            button5.Enabled = false;
            button9.Enabled = true;
            button14.Enabled = true;
            iniFile.SetValue("Settings", "profile" + nr, "1");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string nr = "4";
            RemoveLocalUser("UplaySwitcher" + nr);
            button5.Enabled = true;
            button9.Enabled = false;
            button14.Enabled = false;
            iniFile.SetValue("Settings", "profile" + nr, "0");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string nr = "5";
            CreateLocalUser("UplaySwitcher" + nr);
            button6.Enabled = false;
            button10.Enabled = true;
            button15.Enabled = true;
            iniFile.SetValue("Settings", "profile" + nr, "1");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string nr = "5";
            RemoveLocalUser("UplaySwitcher" + nr);
            button6.Enabled = true;
            button10.Enabled = false;
            button15.Enabled = false;
            iniFile.SetValue("Settings", "profile" + nr, "0");
        }



        //Methods

        public void CreateLocalUser(string username)
        {
            using (TextWriter TW = new StreamWriter(path + "\\cache.txt"))
            {
                TW.WriteLine(username);
                TW.Close();
            }
            Process.Start("createUser.bat");
        }
        public void RemoveLocalUser(string username)
        {
            using (TextWriter TW = new StreamWriter(path + "\\cache.txt"))
            {
                TW.WriteLine(username);
                TW.Close();
            }
            Process.Start("removeUser.bat");
        }
        public void startUplay(string username)
        {
            using (TextWriter TW = new StreamWriter(path + "\\cache2.txt"))
            {
                TW.WriteLine(username);
                TW.Close();
            }
            Process.Start("startUplay.bat");
        }
        public void InitializeSettings()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + "\\settings.ini"))
            {
                using (StreamWriter sw = File.CreateText(path + "\\settings.ini"))
                {
                    sw.WriteLine("[Settings]");
                    sw.WriteLine("profile1=0");
                    sw.WriteLine("profile2=0");
                    sw.WriteLine("profile3=0");
                    sw.WriteLine("profile4=0");
                    sw.WriteLine("profile5=0");
                    sw.WriteLine("[Info]");
                    sw.WriteLine("version=1.0");

                }
            }
            
            if (Convert.ToInt32(iniFile.GetValue("Settings", "profile1")) == 1)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                button11.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button11.Enabled = false;
            }
            if (Convert.ToInt32(iniFile.GetValue("Settings", "profile2")) == 1)
            {
                button3.Enabled = false;
                button7.Enabled = true;
                button12.Enabled = true;
            }
            else
            {
                button3.Enabled = true;
                button7.Enabled = false;
                button12.Enabled = false;
            }
            if (Convert.ToInt32(iniFile.GetValue("Settings", "profile3")) == 1)
            {
                button4.Enabled = false;
                button8.Enabled = true;
                button13.Enabled = true;
            }
            else
            {
                button4.Enabled = true;
                button8.Enabled = false;
                button13.Enabled = false;
            }
            if (Convert.ToInt32(iniFile.GetValue("Settings", "profile4")) == 1)
            {
                button5.Enabled = false;
                button9.Enabled = true;
                button14.Enabled = true;
            }
            else
            {
                button5.Enabled = true;
                button9.Enabled = false;
                button14.Enabled = false;
            }
            if (Convert.ToInt32(iniFile.GetValue("Settings", "profile5")) == 1)
            {
                button6.Enabled = false;
                button10.Enabled = true;
                button15.Enabled = true;
            }
            else
            {
                button6.Enabled = true;
                button10.Enabled = false;
                button15.Enabled = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("upc"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("UplayWebCore"))
            {
                process.Kill();
            }
            startUplay("UplaySwitcher1");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("upc"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("UplayWebCore"))
            {
                process.Kill();
            }
            startUplay("UplaySwitcher2");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("upc"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("UplayWebCore"))
            {
                process.Kill();
            }
            startUplay("UplaySwitcher3");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("upc"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("UplayWebCore"))
            {
                process.Kill();
            }
            startUplay("UplaySwitcher4");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("upc"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("UplayWebCore"))
            {
                process.Kill();
            }
            startUplay("UplaySwitcher5");
        }
    }
}
