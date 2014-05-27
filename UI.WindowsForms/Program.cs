using System;
using System.Windows.Forms;
using UI.WindowsForms.Forms.Main;

namespace UI.WindowsForms
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

            var form = new MainForm();
            var presenter = new MainPresenter(form);
            Application.Run(form);
        }
    }
}
