using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTASASettingsChanger.Classes;
namespace GTASASettingsChanger
{
    public partial class AppWindow : Form
    {

        private bool allowshowdisplay = false;
        private GTAFinder finder;
        private RegistryKey rkApp;
        private bool isInRegistry;
        private GTASettingsSwitcher settingsSwitcher;
        public AppWindow()
        {
            rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            isInRegistry = rkApp.GetValue("GTASASettingsChanger") != null ? true : false;
            InitializeComponent();
            buttonAutoStart.Text = getAutoStartText(isInRegistry);
            loadSettings();



            finder = new GTAFinder();
            finder.GTAFound += OnGTAFound;
            finder.GTAExited += OnGTAExited;
            finder.lookForGTA();
            settingsSwitcher = new GTASettingsSwitcher();
            labelSPPath.Text = cutPath(settingsSwitcher.SettingsLayout.SpSettings);
            labelMTAPath.Text = cutPath(settingsSwitcher.SettingsLayout.MtaSettings);
            labelSAMPPath.Text = cutPath(settingsSwitcher.SettingsLayout.SampSettings);
            labelSecondVersion.Text = cutPath(settingsSwitcher.SettingsLayout.PatchSettings);
        }



        private string cutPath(string fullpath)
        {
            int directories = fullpath.Count(f => f == '\\');
            string newpath = fullpath;
            if (directories > 3)
            {
                string[] split = fullpath.Split('\\');
                newpath = split[0] + "\\" + split[1] + "\\(...)\\" + split[split.Length - 1];
            }
            return newpath;
        }
        private string getAutoStartText(bool val)
        {
            if(val)
            {
                return "Remove from Autostart";
            }
            else
            {
                return "Add to Autostart";
            }
        }

        private void OnGTAExited(GTAProcess process)
        {
            if (process.GameType.Equals("MTA"))
            {
                settingsSwitcher.saveMTASetting();
            }
            else if (process.GameType.Equals("SAMP"))
            {
                settingsSwitcher.saveSAMPSetting();
            }
            else if (process.GameType.Equals("1.00"))
            {
                settingsSwitcher.saveSinglePlayerSetting();
            }
            else if (process.GameType.Equals("1.01"))
            {
                settingsSwitcher.saveSecondVersionSetting();
            }
            else if (process.GameType.Equals("SinglePlayer"))
            {
                settingsSwitcher.saveSinglePlayerSetting();
            }
        }
        private void OnGTAFound(GTAProcess process)
        {
            new ToastContentBuilder()
                .AddText("Your GTA San Andreas Settings have changed.")
                .AddText("Game Version: " + process.GameType + " has been detected!")
                .AddText("Your In-Game settings have been adjusted to set file you selected!")
                .AddHeroImage(new Uri("https://picsum.photos/364/180?image=1043"))
                .Show();

            if(process.GameType.Equals("MTA"))
            {
                settingsSwitcher.loadMTASetting();
            }
            else if (process.GameType.Equals("SAMP"))
            {
                settingsSwitcher.loadSAMPSetting();
            }
            else if (process.GameType.Equals("1.00"))
            {
                settingsSwitcher.loadFirstVersionSetting();
            }
            else if (process.GameType.Equals("1.01"))
            {
                settingsSwitcher.loadSecondVersionSetting();
            }
            else if (process.GameType.Equals("SinglePlayer"))
            {
                settingsSwitcher.loadSinglePlayerSetting();
            }



        }


        private void loadSettings()
        {
            this.CenterToScreen();

            // To provide your own custom icon image, go to:
            //   1. Project > Properties... > Resources
            //   2. Change the resource filter to icons
            //   3. Remove the Default resource and add your own
            //   4. Modify the next line to Properties.Resources.<YourResource>
            this.Icon = GTASASettingsSwitcher.Properties.Resources.Default;
            this.SystemTrayIcon.Icon = GTASASettingsSwitcher.Properties.Resources.Default;
            // sdfhjasdasasd
            // Change the Text property to the name of your application
            this.SystemTrayIcon.Text = "GTA SA Settings Changer";
            this.SystemTrayIcon.Visible = true;

            // Modify the right-click menu of your system tray icon here
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Exit", ContextMenuExit);
            this.SystemTrayIcon.ContextMenu = menu;

            this.Resize += WindowResize;
            this.FormClosing += WindowClosing;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        private void SystemTrayIconDoubleClick(object sender, MouseEventArgs e)
        {
            this.allowshowdisplay = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ContextMenuExit(object sender, EventArgs e)
        {
            this.SystemTrayIcon.Visible = false;
            Application.Exit();
            Environment.Exit(0);
        }

        private void WindowResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void WindowClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!isInRegistry)
            {
                rkApp.SetValue("GTASASettingsChanger", Application.ExecutablePath);
                isInRegistry = true;
            }
            else
            {
                rkApp.DeleteValue("GTASASettingsChanger", false);
                isInRegistry = false;
            }

            buttonAutoStart.Text = isInRegistry == true ? "Remove from AutoStart" : "Add to AutoStart";
        }

        private void buttonSP_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog upload = new OpenFileDialog())
            {
                upload.Filter = "SET Files|*.set";
                upload.Title = "Select Singleplayer Settings File";
                if (upload.ShowDialog() != DialogResult.OK)
                    return;
                settingsSwitcher.setSinglePlayerSetting(upload.FileName);
                labelSPPath.Text = cutPath(upload.FileName);
            }
        }

        private void buttonSAMP_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog upload = new OpenFileDialog())
            {
                upload.Filter = "SET Files|*.set";
                upload.Title = "Select SAMP Settings File";
                if (upload.ShowDialog() != DialogResult.OK)
                    return;
                settingsSwitcher.setSAMPSetting(upload.FileName);
                labelSAMPPath.Text = cutPath(upload.FileName);
            }
        }

        private void buttonMTA_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog upload = new OpenFileDialog())
            {
                upload.Filter = "SET Files|*.set";
                upload.Title = "Select MTA Settings File";
                if (upload.ShowDialog() != DialogResult.OK)
                    return;
                settingsSwitcher.setMTASetting(upload.FileName);
                labelMTAPath.Text = cutPath(upload.FileName);
            }
        }

        private void buttonSecondVersion_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog upload = new OpenFileDialog())
            {
                upload.Filter = "SET Files|*.set";
                upload.Title = "Select MTA Settings File";
                if (upload.ShowDialog() != DialogResult.OK)
                    return;
                settingsSwitcher.setSecondVersionSetting(upload.FileName);
                labelSecondVersion.Text = cutPath(upload.FileName);
            }
        }
    }
}
