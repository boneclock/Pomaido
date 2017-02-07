using System;
using System.Drawing;
using System.Windows.Forms;
using UI.WindowsForms.Forms.Maids;
using UI.WindowsForms.SoundPlayer;

namespace UI.WindowsForms.Forms.Main
{
    public partial class MainForm : Form, IMainView
    {

        public event Action ChangeViewMode;
        public event Action Reset;
        public event Action Tick;

        private IMaidForm maid;

        public MainForm()
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlaceWindowsAtTheRightBottomOfTheScreen();

            maid = new MeguminForm();
            maid.SetupMaid(this, SoundPlayerFactory.Create());
            maid.Show();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Close();
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

        public void PomodoroChronoRoundSwitched(Pomaido.Pomodoro pomodoro)
        {
            ISoundPlayer player = SoundPlayerFactory.Create();

            if (string.IsNullOrEmpty(maid.AlarmSound)) {
                player.Play(@"Ressources\Shared\Sounds\alarm.wav");
            } else {
                player.Play(maid.AlarmSound);
            }
        }

        public void RefreshPomodoroChrono(Pomaido.Pomodoro pomodoro)
        {
            ChronoLabel.Text = pomodoro.TimeUntilEndOfTheRound.ToString("mm':'ss");
        }

        public void RefreshViewMode(MainViewMode mode)
        {
            if (mode == MainViewMode.Started) { 
                btnStart.Text = "Stop";
                maid.OnPomodoroStarted();
            } else {
                btnStart.Text = "Start";
                maid.OnPomodoroStopped();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ChangeViewMode();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            maid.OnPomodoroReset();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Tick();
        }
    }
}
