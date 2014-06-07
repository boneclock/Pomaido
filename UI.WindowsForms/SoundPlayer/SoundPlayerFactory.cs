
namespace UI.WindowsForms.SoundPlayer
{
    public class SoundPlayerFactory
    {
        public static ISoundPlayer Create()
        {
            return new NAudioSoundPlayer();
        }
    }
}
