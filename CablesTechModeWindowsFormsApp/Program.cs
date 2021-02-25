using CableTechModeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CablesTechModeWindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dataRepository = new ProgramDataRepository();
            var mainForm = new MainForm(dataRepository);
            var presenter = new MainPresenter(mainForm, dataRepository);

            Application.Run(mainForm);
        }
    }
}
