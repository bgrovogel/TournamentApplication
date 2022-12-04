using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initailze the database connections
            TrackerLibrary.GlobalConfig.InitializeConnections(true, true);
            Application.Run(new CreatePrizeForm()); // just want to see this working

            //Application.Run(new TournamentDashboardForm()); // real startup form
        }
    }
}
