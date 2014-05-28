using Pomaido;
using UI.WindowsForms.Settings;

namespace UI.WindowsForms.Forms.Main
{
    public class MainPresenter
    {

        private IMainView view;
        private MainViewMode currentViewMode;
        private IPomodoroFactory pomodoroFactory;
        private Pomodoro pomodoro;

        public MainPresenter(IMainView view, IPomodoroFactory pomodoroFactory)
        {
            currentViewMode = MainViewMode.Stopped;

            this.pomodoroFactory = pomodoroFactory;
            this.pomodoro = pomodoroFactory.Create();

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
            pomodoro = pomodoroFactory.Create();
            view.RefreshPomodoroChrono(pomodoro);
            view.RefreshViewMode(currentViewMode);
        }

    }
}
