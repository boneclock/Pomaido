using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pomaido;
using System;
using UI.WindowsForms.Forms.Main;
using UI.WindowsForms.Settings;

namespace UI.WindowsForms.UnitTest
{
    [TestClass]
    public class MainPresenterTest
    {

        private MainPresenter presenter;
        private Mock<IMainView> view;
        private Mock<IPomodoroFactory> pomodoroFactory;
        private Pomodoro defaultPomodoro;

        [TestInitialize]
        public void SetUp()
        { 
            view = new Mock<IMainView>();

            defaultPomodoro = new Pomodoro(new PomodoroSettings { 
                WorkRoundLength = TimeSpan.FromMinutes(25),
                ShortBreakRoundLength = TimeSpan.FromMinutes(5),
                LongBreakRoundLength = TimeSpan.FromMinutes(15),
                NbWorkRoundBeforeLongBreak = 4
            });
            pomodoroFactory = new Mock<IPomodoroFactory>();
            pomodoroFactory.Setup(x => x.Create()).Returns(defaultPomodoro);

            presenter = new MainPresenter(view.Object, pomodoroFactory.Object);
        }

        [TestMethod]
        public void TestChangeViewMode()
        {
            ChangeViewModeAndExpectThisNewMode(MainViewMode.Started);
            ChangeViewModeAndExpectThisNewMode(MainViewMode.Stopped);
            ChangeViewModeAndExpectThisNewMode(MainViewMode.Started);
            ChangeViewModeAndExpectThisNewMode(MainViewMode.Stopped);
        }

        private void ChangeViewModeAndExpectThisNewMode(MainViewMode expected)
        {
            view.ResetCalls();
            view.Raise(x => x.ChangeViewMode += null);
            view.Verify(x => x.RefreshViewMode(expected), Times.Once());
        }

        [TestMethod]
        public void TestResetWhenModeIsStopped()
        {
            view.Raise(x => x.Reset += null);

            view.Verify(x => x.RefreshViewMode(MainViewMode.Stopped));
            pomodoroFactory.Verify(x => x.Create());
            view.Verify(x => x.RefreshPomodoroChrono(defaultPomodoro));
        }

        [TestMethod]
        public void TestResetWhenModeIsStarted()
        {
            view.Raise(x => x.ChangeViewMode += null);
            view.Raise(x => x.Reset += null);

            view.Verify(x => x.RefreshViewMode(MainViewMode.Stopped));
            pomodoroFactory.Verify(x => x.Create());
            view.Verify(x => x.RefreshPomodoroChrono(defaultPomodoro));
        }

        [TestMethod]
        public void TestTickWhenModeIsStopped()
        {
            TickAndExpectNoRefreshPomodoroCall();
            TickAndExpectNoRefreshPomodoroCall();
            TickAndExpectNoRefreshPomodoroCall();
        }

        private void TickAndExpectNoRefreshPomodoroCall()
        {
            view.ResetCalls();
            view.Raise(x => x.Tick += null);
            view.Verify(x => x.RefreshPomodoroChrono(It.IsAny<Pomodoro>()), Times.Never());
        }

        [TestMethod]
        public void TestTickWhenModeIsStarted()
        {
            view.Raise(x => x.ChangeViewMode += null);
            TickAndExpectThisTimeUntilEndOfTheRound("00:24:59");
            TickAndExpectThisTimeUntilEndOfTheRound("00:24:58");
            TickAndExpectThisTimeUntilEndOfTheRound("00:24:57");
        }

        private void TickAndExpectThisTimeUntilEndOfTheRound(string time)
        {
            view.ResetCalls();
            view.Raise(x => x.Tick += null);
            view.Verify(x => x.RefreshPomodoroChrono(
                It.Is<Pomodoro>(p => p.TimeUntilEndOfTheRound == TimeSpan.Parse(time))
            ), Times.Once());
        }
    }
}
