﻿using UI.WindowsForms.Forms.Main;
using UI.WindowsForms.SoundPlayer;

namespace UI.WindowsForms.Forms.Maids
{
    public interface IMaidForm
    {
        string AlarmSound { get; }

        void SetupMaid(MainForm form, ISoundPlayer soundPlayer);

        void Show();
        void Hide();

        void OnPomodoroStopped();
        void OnPomodoroStarted();
        void OnPomodoroReset();
    }
}
