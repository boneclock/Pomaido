using System;
using System.Drawing;
using System.Windows.Forms;
using UI.WindowsForms.SoundPlayer;

namespace UI.WindowsForms.Forms.Maids
{
    public partial class RemForm : Form, IMaidForm
    {
        private ISoundPlayer soundPlayer;

        public RemForm()
        {
            InitializeComponent();
            this.Width = 150;
            this.Height = 225;
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            soundPlayer.Play(@"Ressources\Hinagiku\Sounds\Hinagiku to yobinasai.wav");
        }

        public void SetupMaid(Main.MainForm form, ISoundPlayer soundPlayer)
        {
            this.soundPlayer = soundPlayer;
            this.Location = new Point(
                form.Location.X + (form.Width / 2) - (this.Width / 2),
                form.Location.Y - this.Height + 15
            );
        }

        public void Show()
        {
            base.Show();
        }

        public void Hide()
        {
            base.Hide();
        }

        public void OnPomodoroStopped()
        {
            soundPlayer.Play(@"Ressources\Hinagiku\Sounds\Daijoubu.wav");
        }

        public void OnPomodoroStarted()
        {
            soundPlayer.Play(@"Ressources\Hinagiku\Sounds\Hayaku ikimashou.wav");
        }

        public void OnPomodoroReset()
        {
        }
    }
}
