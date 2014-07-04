using Pomaido;
using System;

namespace UI.WindowsForms.Forms.Main
{

    public enum MainViewMode
    {
        Started,
        Stopped
    }

    public interface IMainView
    {

        event Action ChangeViewMode;
        event Action Reset;
        event Action Tick;

        void RefreshViewMode(MainViewMode mode);
        void RefreshPomodoroChrono(Pomodoro pomodoro);
        void PomodoroChronoRoundSwitched(Pomodoro pomodoro);
    }
}
