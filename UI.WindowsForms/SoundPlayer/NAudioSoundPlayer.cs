using NAudio.Wave;
using System.ComponentModel;
using System.Threading;

namespace UI.WindowsForms.SoundPlayer
{
    public class NAudioSoundPlayer : ISoundPlayer
    {
        public void Play(string filename)
        {
            using (var thread = new BackgroundWorker()) {
                thread.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs args) {
                    PlayWithNAudio(filename);
                });
                thread.RunWorkerAsync();
            }
        }

        private void PlayWithNAudio(string filename)
        {
            using (var output = new WaveOutEvent()) {
                using (var player = new AudioFileReader(filename)) {
                    output.Init(player);
                    output.Play();
                    while (output.PlaybackState == PlaybackState.Playing) {
                        Thread.Sleep(500);
                    }
                }
            }
        }

    }
}
