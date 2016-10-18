using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
  
    /// <summary>
    /// One time installation of the evnt log source. Build the project and execute the cmd "installutil <assemblydllpath of this class>" on visual studio cmd
    /// </summary>
        [RunInstaller(true)]
        public class UtilityEventLogInstaller : Installer
        {
            private EventLogInstaller installer;

            /// <summary>
            /// Installer with 0 params
            /// </summary>
            public UtilityEventLogInstaller()
            {
                //Create Instance of EventLogInstaller
                installer = new EventLogInstaller();

                // Set the Source of Event Log, to be created.
                installer.Source = ConfigurationManager.AppSettings["source"];

                // Set the Log that source is created in
                installer.Log = ConfigurationManager.AppSettings["application"];

                // Add EventLogInstaller to the Installers Collection.
                Installers.Add(installer);

            }
        }
}
