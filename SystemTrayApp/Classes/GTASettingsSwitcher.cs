using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GTASASettingsChanger.Classes
{
    public class GTASettingsSwitcher
    {
        private string settingsDirectory;
        private string settingsFile;
        private SettingsLayout settingsLayout;

        public string SettingsDirectory { get => settingsDirectory; set => settingsDirectory = value; }
        public string SettingsFile { get => settingsFile; set => settingsFile = value; }
        public SettingsLayout SettingsLayout { get => settingsLayout; set => settingsLayout = value; }

        public GTASettingsSwitcher()
        {
            SettingsLayout = new SettingsLayout()
            {
                InitalPath = determineInitalPath(),
            };
            setSettingsDirectory();
        }
        public void saveMTASetting()
        {
            try
            {
                if (!(SettingsLayout.MtaSettings == (null)))
                {
                    File.Copy(SettingsLayout.InitalPath + "\\gta_sa.set", SettingsLayout.MtaSettings, true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.StackTrace);
            }
        }

        public void saveSAMPSetting()
        {
            try
            {
                if (!(SettingsLayout.SampSettings == (null)))
                {
                    File.Copy(SettingsLayout.InitalPath + "\\gta_sa.set", SettingsLayout.SampSettings, true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.StackTrace);
            }
        }

        public void saveSinglePlayerSetting()
        {
            try
            {
                if (!(SettingsLayout.SpSettings == (null)))
                {
                    File.Copy(SettingsLayout.InitalPath + "\\gta_sa.set", SettingsLayout.SpSettings, true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.StackTrace);
            }
        }

        public void saveSecondVersionSetting()
        {
            try
            {
                if (!(SettingsLayout.PatchSettings == (null)))
                {
                    File.Copy(SettingsLayout.InitalPath + "\\gta_sa.set", SettingsLayout.PatchSettings, true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.StackTrace);
            }
        }
        public void loadMTASetting()
        {
            try
            {
                if (!(SettingsLayout.MtaSettings == (null)))
                {
                    File.Copy(SettingsLayout.MtaSettings, SettingsLayout.InitalPath + "\\gta_sa.set", true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.StackTrace);
            }
        }

        public void loadSAMPSetting()
        {
            try
            {
                if (!(SettingsLayout.SampSettings == (null)))
                {
                    File.Copy(SettingsLayout.SampSettings, SettingsLayout.InitalPath + "\\gta_sa.set", true);
                }
            }
            catch(Exception error)
            {
                Console.WriteLine(error.StackTrace);
            }

        }

        public void loadSinglePlayerSetting()
        {
            try
            {
                if (!(SettingsLayout.SpSettings == (null)))
                {
                    File.Copy(SettingsLayout.SpSettings, SettingsLayout.InitalPath + "\\gta_sa.set", true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.StackTrace);
            }
        }


        // version 1.00 singleplayer
        public void loadFirstVersionSetting()
        {
            loadSinglePlayerSetting();
        }

        //version 1.01 singleplayer
        public void loadSecondVersionSetting()
        {
            try
            {
                if (!(SettingsLayout.PatchSettings == (null)))
                {
                    File.Copy(SettingsLayout.PatchSettings, SettingsLayout.InitalPath + "\\gta_sa.set", true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.StackTrace);
            }
        }

        public void setMTASetting(string path)
        {
            SettingsLayout.MtaSettings = path;
            writeToSettings();
        }

        public void setSAMPSetting(string path)
        {
            SettingsLayout.SampSettings = path;
            writeToSettings();
        }

        public void setSinglePlayerSetting(string path)
        {
            SettingsLayout.SpSettings = path;
            writeToSettings();
        }

        public void setSecondVersionSetting(string path)
        {
            settingsLayout.PatchSettings = path;
            writeToSettings();
        }

        private string getTempFolderPath()
        {
            return new List<string>(Directory.EnumerateDirectories(Path.GetTempPath())).FindAll(directory => directory.Contains("GTASASettingsSwitcher"))[0];
        }
        private bool doesTempFolderExist()
        {
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(Path.GetTempPath())).FindAll(directory => directory.Contains("GTASASettingsSwitcher"));
            return dirs.Count > 0;
        }
        private string determineInitalPath()
        {
            // here by we need to check if the user is using onedrive or locally saved files
            string initalPath = "";
            try
            {

                initalPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\GTA San Andreas User Files";

            }
            catch (Exception error)
            {
                /// throw;
                Console.WriteLine(error.StackTrace);
            }
            return initalPath;
        }

        private void writeToSettings()
        {
            List<SettingsLayout> _data = new List<SettingsLayout>();
            _data.Add(SettingsLayout);
            using (StreamWriter file = File.CreateText(SettingsFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, SettingsLayout);
            }
        }

        private void loadSettings()
        {
            // read file into a string and deserialize JSON to a type
            SettingsLayout = JsonConvert.DeserializeObject<SettingsLayout>(File.ReadAllText(SettingsFile));

        }
        private void createSettingsFile()
        {
            try
            {
                writeToSettings(); 
            }
            catch(Exception error)
            {
                MessageBox.Show(error.StackTrace);
            }

        }
        private void setSettingsDirectory()
        {
            //string tempDirectory = Path.Combine(Path.GetTempPath(), "GTASASettingsSwitcher" + Path.GetRandomFileName());
            //if(Directory.Exists(tempDirectory))
            //{
            //    GetTemporaryDirectory();
            //}
            //Directory.CreateDirectory(tempDirectory);
            //return tempDirectory;

            if(doesTempFolderExist())
            {
                SettingsDirectory = getTempFolderPath();
                SettingsFile = SettingsDirectory + "\\settings.json";
                loadSettings();
            }
            else
            {
                string tempDirectory = Path.Combine(Path.GetTempPath(), "GTASASettingsSwitcher---" + Path.GetRandomFileName());
                if (Directory.Exists(tempDirectory))
                {
                    setSettingsDirectory();
                }
                Directory.CreateDirectory(tempDirectory);
                SettingsDirectory = tempDirectory;
                SettingsFile = tempDirectory + "\\settings.json";
                createSettingsFile();
            }
        }
    }
}
