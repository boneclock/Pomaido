using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pomaido.UnitTest
{
    [TestClass]
    public class PomodoroTest
    {

        private TimeSpan workRoundLength = TimeSpan.FromMinutes(25);
        private TimeSpan shortBreakRoundLength = TimeSpan.FromMinutes(5);
        private TimeSpan longBreakRoundLength = TimeSpan.FromMinutes(15);

        private Pomodoro pomodoro;
        private int pomodoroRoundSwitchedEventCallTime;

        [TestInitialize]
        public void SetUp()
        {
            pomodoro = new Pomodoro(new PomodoroSettings { 
                WorkRoundLength = workRoundLength,
                ShortBreakRoundLength = shortBreakRoundLength,
                LongBreakRoundLength = longBreakRoundLength,
                NbWorkRoundBeforeLongBreak = 4
            });

            pomodoroRoundSwitchedEventCallTime = 0;
            pomodoro.RoundSwitched += delegate() { pomodoroRoundSwitchedEventCallTime++; };
        }

        [TestMethod]
        public void TestNewPomodoroInitialization()
        {
            AssertInitialPomodoroWorkState();
            Assert.AreEqual(0, pomodoroRoundSwitchedEventCallTime);
        }

        [TestMethod]
        public void TestOneTickThatDecrementRoundTime()
        {
            TickPomodoro(1);
            AssertPomodoroState(workRoundLength.Subtract(TimeSpan.FromSeconds(1)), PomodoroRoundType.Work);
            Assert.AreEqual(0, pomodoroRoundSwitchedEventCallTime);
        }

        [TestMethod]
        public void TestTickThatSwitchRound()
        {
            TickPomodoro((int)pomodoro.TimeUntilEndOfTheRound.TotalSeconds);
            AssertInitialPomodoroShortBreakState();
            Assert.AreEqual(1, pomodoroRoundSwitchedEventCallTime);
        }

        [TestMethod]
        public void TestFlowOfPomodoro()
        {
            for (var i = 0; i < 4; i++) {
                AssertFlowExecutionForFourWorkRounds();
                Assert.AreEqual(8 * (i + 1), pomodoroRoundSwitchedEventCallTime);
            }
        }

        private void AssertFlowExecutionForFourWorkRounds()
        {
            AssertInitialPomodoroWorkState();
            TickPomodoroUntilEndOfTheRound();
            AssertInitialPomodoroShortBreakState();
            TickPomodoroUntilEndOfTheRound();

            AssertInitialPomodoroWorkState();
            TickPomodoroUntilEndOfTheRound();
            AssertInitialPomodoroShortBreakState();
            TickPomodoroUntilEndOfTheRound();

            AssertInitialPomodoroWorkState();
            TickPomodoroUntilEndOfTheRound();
            AssertInitialPomodoroShortBreakState();
            TickPomodoroUntilEndOfTheRound();

            AssertInitialPomodoroWorkState();
            TickPomodoroUntilEndOfTheRound();
            AssertInitialPomodoroLongBreakState();
            TickPomodoroUntilEndOfTheRound();
        }

        private void TickPomodoroUntilEndOfTheRound()
        {
            TickPomodoro((int)pomodoro.TimeUntilEndOfTheRound.TotalSeconds);
        }

        private void TickPomodoro(int nbOfTick)
        {
            for (var i = 0; i < nbOfTick; i++) {
                pomodoro.Tick();
            }
        }

        private void AssertInitialPomodoroWorkState()
        {
            AssertPomodoroState(workRoundLength, PomodoroRoundType.Work);
        }

        private void AssertInitialPomodoroShortBreakState()
        {
            AssertPomodoroState(shortBreakRoundLength, PomodoroRoundType.ShortBreak);
        }

        private void AssertInitialPomodoroLongBreakState()
        {
            AssertPomodoroState(longBreakRoundLength, PomodoroRoundType.LongBreak);
        }

        private void AssertPomodoroState(TimeSpan timeUntilEndOfRound, PomodoroRoundType roundType)
        {
            Assert.AreEqual(timeUntilEndOfRound, pomodoro.TimeUntilEndOfTheRound);
            Assert.AreEqual(roundType, pomodoro.CurrentRoundType);
        }
    }
}
