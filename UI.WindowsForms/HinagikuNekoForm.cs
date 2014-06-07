using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.WindowsForms.SoundPlayer;

namespace UI.WindowsForms
{
    public partial class HinagikuNekoForm : Form
    {
        private ISoundPlayer soundPlayer;

        public HinagikuNekoForm(ISoundPlayer soundPlayer)
        {
            InitializeComponent();
            this.soundPlayer = soundPlayer;
            this.Width = 150;
            this.Height = 153;
        }

        private void HinagikuNekoForm_Shown(object sender, EventArgs e)
        {
            SayHinagikuToYobinasai();
        }

        public void SayBenkyouShinasai()
        {
            soundPlayer.Play(@"Ressources\Hinagiku\Sounds\Benkyou shinasai.wav");
        }

        public void SayDaijoubu()
        {
            soundPlayer.Play(@"Ressources\Hinagiku\Sounds\Daijoubu.wav");
        }

        public void SayHinagikuToYobinasai()
        {
            soundPlayer.Play(@"Ressources\Hinagiku\Sounds\Hinagiku to yobinasai.wav");
        }

        public void SayWatashiWaKatsuraHinagiku()
        {
            soundPlayer.Play(@"Ressources\Hinagiku\Sounds\Watashi wa Katsura Hinagiku.wav");
        }

        public void SayHayakuIkimashou()
        {
            soundPlayer.Play(@"Ressources\Hinagiku\Sounds\Hayaku ikimashou.wav");
        }
    }
}
