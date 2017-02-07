using System;
using System.Drawing;
using System.Windows.Forms;
using UI.WindowsForms.SoundPlayer;

namespace UI.WindowsForms.Forms.Maids
{
    public partial class MeguminForm : Form, IMaidForm
    {
        private ISoundPlayer soundPlayer;

        public string AlarmSound { get { return @"Ressources\Megumin\Sounds\explosion-sound.wav"; } }

        public MeguminForm()
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 251;
        }

        private void HinagikuNekoForm_Shown(object sender, EventArgs e)
        {
            soundPlayer.Play(@"Ressources\Megumin\Sounds\Wa ga na wa megumin.wav");
        }

        public void SetupMaid(Main.MainForm form, ISoundPlayer soundPlayer)
        {
            this.soundPlayer = soundPlayer;
            this.Location = new Point(
                form.Location.X + (form.Width / 2) - (this.Width / 2),
                form.Location.Y - this.Height + 30
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
            soundPlayer.Play(@"Ressources\Megumin\Sounds\Saiko desu.wav");
        }

        public void OnPomodoroStarted()
        {
            soundPlayer.Play(@"Ressources\Megumin\Sounds\Explosion.wav");
        }

        public void OnPomodoroReset()
        {
        }
    }
}
