using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace UI.WindowsForms
{
    public partial class MainForm : Form
    {

        private Pomaido.Pomodoro pomodoro;

        public MainForm()
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlaceWindowsAtTheRightBottomOfTheScreen();
            ShowHinagikuNeko();
            InitializePomodoro();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlaceWindowsAtTheRightBottomOfTheScreen()
        {
            int taskbarHeight = Screen.PrimaryScreen.Bounds.Bottom - Screen.PrimaryScreen.WorkingArea.Bottom;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int padding = 10;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                screenWidth - this.Width - padding, 
                screenHeight - this.Height - taskbarHeight - padding
            );
        }

        private void ShowHinagikuNeko()
        {
            var hinagiku = new HinagikuNekoForm();

            hinagiku.Location = new Point(
                this.Location.X + (this.Width / 2) - (hinagiku.Width / 2),
                this.Location.Y - hinagiku.Height + 15
            );

            hinagiku.Show();
        }

        private void InitializePomodoro()
        {
            pomodoro = new Pomaido.Pomodoro(new Pomaido.PomodoroSettings {
                WorkRoundLength = TimeSpan.Parse(ConfigurationManager.AppSettings["DefaultPomodoroWorkRoundLength"]),
                ShortBreakRoundLength = TimeSpan.Parse(ConfigurationManager.AppSettings["DefaultPomodoroShortBreakRoundLength"]),
                LongBreakRoundLength = TimeSpan.Parse(ConfigurationManager.AppSettings["DefaultPomodoroLongBreakRoundLength"])
            });
            RefreshChronoLabel();
            ChronoTimer.Start();
        }

        private void ChronoTimer_Tick(object sender, EventArgs e)
        {
            pomodoro.Tick();
            RefreshChronoLabel();
        }

        private void RefreshChronoLabel()
        {
            ChronoLabel.Text = pomodoro.TimeUntilEndOfTheRound.ToString("mm':'ss");
        }

    }
}
