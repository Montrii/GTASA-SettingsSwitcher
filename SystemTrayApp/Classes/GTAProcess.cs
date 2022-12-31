using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTASASettingsChanger.Classes
{
    public class GTAProcess
    {

        private Process gameProcess;
        private Process parentProcess;
        private string gameType;

        public GTAProcess(Process gameProcess, Process parentProcess)
        {
            this.gameProcess = gameProcess;
            this.parentProcess = parentProcess;
            GameType = determineGameType();
        }


        private string determineGameType()
        {
            if (parentProcess == null)
                return "SinglePlayer";
            else if (gameProcess.ProcessName.Contains("proxy_sa"))
                return "MTA";
            else if (parentProcess.ProcessName.Contains("samp"))
                return "SAMP";
            else if (parentProcess.ProcessName.Contains(System.Diagnostics.Process.GetCurrentProcess().ProcessName))
                return "SAMP";
            else if (new System.IO.FileInfo(gameProcess.MainModule.FileName).Length == 14383616)
                return "1.00";
            else if (new System.IO.FileInfo(gameProcess.MainModule.FileName).Length == 15806464)
                return "1.01";
            else
                return "SinglePlayer";

        }

        public Process GameProcess { get => gameProcess; set => gameProcess = value; }
        public Process ParentProcess { get => parentProcess; set => parentProcess = value; }
        public string GameType { get => gameType; set => gameType = value; }

        public override string ToString()
        {
            return gameProcess.ProcessName + " with Parent: " + parentProcess.ProcessName;
        }
    }
}
