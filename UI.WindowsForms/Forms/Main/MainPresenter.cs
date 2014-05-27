using Pomaido;
using System;
using System.Configuration;

namespace UI.WindowsForms.Forms.Main
{
    public class MainPresenter
    {

        private IMainView view;
        private Pomodoro pomodoro;
        private MainViewMode currentViewMode;

        public MainPresenter(IMainView view)
        {
            currentViewMode = MainViewMode.Stopped;
            InitializePomodoro();

            this.view = view;
            this.view.ChangeViewMode += ChangeViewMode;
            this.view.Reset += Reset;
            this.view.Tick += Tick;
            this.view.RefreshPomodoroChrono(pomodoro);
        }

        private void Tick()
        {
            if (currentViewMode == MainViewMode.Started) {
                pomodoro.Tick();
                view.RefreshPomodoroChrono(pomodoro);
            }
        }

        private void ChangeViewMode()
        {
            if (currentViewMode == MainViewMode.Started) {
                currentViewMode = MainViewMode.Stopped;
            } else {
                currentViewMode = MainViewMode.Started;
            }
            view.RefreshViewMode(currentViewMode);
        }

        private void Reset()
        {
            currentViewMode = MainViewMode.Stopped;
            InitializePomodoro();
            view.RefreshPomodoroChrono(pomodoro);
            view.RefreshViewMode(currentViewMode);
        }

        private void InitializePomodoro()
        {
            //pomodoro = new Pomodoro(new PomodoroSettings {
            //    WorkRoundLength = TimeSpan.Parse(ConfigurationManager.AppSettings["DefaultPomodoroWorkRoundLength"]),
            //    ShortBreakRoundLength = TimeSpan.Parse(ConfigurationManager.AppSettings["DefaultPomodoroShortBreakRoundLength"]),
            //    LongBreakRoundLength = TimeSpan.Parse(ConfigurationManager.AppSettings["DefaultPomodoroLongBreakRoundLength"]),
            //    NbWorkRoundBeforeLongBreak = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultPomodoroNbWorkRoundBeforeLongBreak"])
            //});
            pomodoro = new Pomodoro(new PomodoroSettings {
                WorkRoundLength = TimeSpan.FromMinutes(20),
                ShortBreakRoundLength = TimeSpan.FromMinutes(5),
                LongBreakRoundLength = TimeSpan.FromMinutes(15),
                NbWorkRoundBeforeLongBreak = 4
            });
        }

    }
}
