using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using AssignLaneLot_ProgramSimulation;

namespace AssignLaneLot_WinFormsUI
{
    static class Program
    {
        private static readonly ProgramSimulation ApplicationWorkflow = new ProgramSimulation();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AssignLaneLot(
                ApplicationWorkflow.VINPassedByUser(), 
                ApplicationWorkflow.SellerIDPassedByUser(), 
                ApplicationWorkflow.StockInDatabaseConnection,
                ApplicationWorkflow.WhenDelegatedWorkCompleted
                )
            );
        }
    }
}
