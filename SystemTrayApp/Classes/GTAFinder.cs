using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTASASettingsChanger.structs;

namespace GTASASettingsChanger.Classes
{

    public delegate void Found(GTAProcess process);
    public delegate void Ended(GTAProcess process);
    public class GTAFinder
    {

        public event Found GTAFound;
        public event Ended GTAExited;
        private GTAProcess currentGTAProcess;
        public GTAFinder()
        {
            currentGTAProcess = new GTAProcess(Process.GetCurrentProcess(), null);
        }

        public void lookForGTA()
        {
            new Thread(() =>
            {
                while(true)
                {
                    Thread.Sleep(0);
                    try
                    {
                        // sdaf
                        try
                        {
                            lookForSpecificGtaProcess("gta_sa");
                        }
                        catch(Exception error)
                        {

                        }
                        
                        lookForSpecificGtaProcess("proxy_sa");
                    }
                    catch(Exception error)
                    {
                    }
                }
            }).Start();
        }
        private void saveEditedGtaSettings()
        {
            if(currentGTAProcess != null)
            {
                if(currentGTAProcess.GameProcess.HasExited)
                {
                    gtaProcessEnded(currentGTAProcess);
                }
            }
        }

        private void lookForSpecificGtaProcess(string name)
        {

            if(Process.GetProcessesByName(name).Length <= 0)
            {
                return;
            }

            Process gta = Process.GetProcessesByName(name)[0];
            if (gta != null)
            {
                Process parent = ParentProcessUtilities.GetParentProcess(gta.Id);
                GTAProcess temp;
                // if parent was killed immediately (sampcmd for example)
                if (parent == null)
                    temp = new GTAProcess(gta, Process.GetCurrentProcess());
                else
                    temp = new GTAProcess(gta, parent);

                // check if process id are matching
                if (!(currentGTAProcess.GameProcess.Id == temp.GameProcess.Id))
                {
                    currentGTAProcess = temp;
                    gtaProcessFound(currentGTAProcess);
                }
                saveEditedGtaSettings();
            }
            else
            {
                if (currentGTAProcess != null)
                    currentGTAProcess = null;
            }
        }
        private void gtaProcessFound(GTAProcess gtaProcess)
        {
            GTAFound?.Invoke(gtaProcess);
        }

        private void gtaProcessEnded(GTAProcess gtaProcess)
        {
            GTAExited?.Invoke(gtaProcess);
        }
    }
}
