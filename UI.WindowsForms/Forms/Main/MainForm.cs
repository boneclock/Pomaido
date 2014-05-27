using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.WindowsForms.Forms.Main
{
    public partial class MainForm : Form, IMainView
    {

        public event Action ChangeViewMode;
        public event Action Reset;
        public event Action Tick;

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

        private void ShowHinagikuNeko()
        {
            var hinagiku = new HinagikuNekoForm();

            hinagiku.Location = new Point(
                this.Location.X + (this.Width / 2) - (hinagiku.Width / 2),
                this.Location.Y - hinagiku.Height + 15
            );

            hinagiku.Show();
        }

        public void RefreshPomodoroChrono(Pomaido.Pomodoro pomodoro)
        {
            ChronoLabel.Text = pomodoro.TimeUntilEndOfTheRound.ToString("mm':'ss");
        }

        public void RefreshViewMode(MainViewMode mode)
        {
            if (mode == MainViewMode.Started) { 
                btnStart.Text = "Stop";
            } else {
                btnStart.Text = "Start";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ChangeViewMode();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Tick();
        }

    }
}
