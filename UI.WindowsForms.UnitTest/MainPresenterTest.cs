using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pomaido;
using UI.WindowsForms.Forms.Main;

namespace UI.WindowsForms.UnitTest
{
    [TestClass]
    public class MainPresenterTest
    {

        private MainPresenter presenter;
        private Mock<IMainView> view;

        [TestInitialize]
        public void SetUp()
        { 
            view = new Mock<IMainView>();
            presenter = new MainPresenter(view.Object);
        }

        [TestMethod]
        public void TestChangeViewMode()
        {
            view.Raise(x => x.ChangeViewMode += null);
            view.Verify(x => x.RefreshViewMode(MainViewMode.Started));

            view.ResetCalls();

            view.Raise(x => x.ChangeViewMode += null);
            view.Verify(x => x.RefreshViewMode(MainViewMode.Stopped));

            view.ResetCalls();

            view.Raise(x => x.ChangeViewMode += null);
            view.Verify(x => x.RefreshViewMode(MainViewMode.Started));
        }

        [TestMethod]
        public void TestResetWhenModeIsStopped()
        {
            view.Raise(x => x.Reset += null);
            view.Verify(x => x.RefreshViewMode(MainViewMode.Stopped));
            view.Verify(x => x.RefreshPomodoroChrono(It.IsAny<Pomodoro>()));
        }

        [TestMethod]
        public void TestResetWhenModeIsStarted()
        {
            view.Raise(x => x.ChangeViewMode += null);
            view.Raise(x => x.Reset += null);
            view.Verify(x => x.RefreshViewMode(MainViewMode.Stopped));
            view.Verify(x => x.RefreshPomodoroChrono(It.IsAny<Pomodoro>()));
        }
    }
}
