using System;
using System.Windows.Forms;
using UI.WindowsForms.Forms.Main;
using UI.WindowsForms.Settings;

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
            var pomodoroFactory = new PomodoroFactory();
            var presenter = new MainPresenter(form, pomodoroFactory);
            Application.Run(form);
        }
    }
}
