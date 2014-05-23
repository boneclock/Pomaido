using System;

namespace Pomaido
{

    public enum PomodoroRoundType { 
        Work,
        ShortBreak,
        LongBreak
    }

    public class PomodoroSettings
    {
        public TimeSpan WorkRoundLength { get; set; }
        public TimeSpan ShortBreakRoundLength { get; set; }
        public TimeSpan LongBreakRoundLength { get; set; }
        public int NbWorkRoundBeforeLongBreak { get; set; }
    }

    public class Pomodoro
    {
        private int nbWorkRoundDone;
        private PomodoroSettings settings;

        public TimeSpan TimeUntilEndOfTheRound { get; private set; }
        public PomodoroRoundType CurrentRoundType { get; private set; }

        public Pomodoro(PomodoroSettings pomodoroSettings)
        {
            settings = pomodoroSettings;
            nbWorkRoundDone = 0;
            StartWorkRound();
        }

        public void Tick()
        {
            TimeUntilEndOfTheRound -= TimeSpan.FromSeconds(1);
            
            if (TimeUntilEndOfTheRound.TotalSeconds == 0) {
                StartNextRound();
            }
        }

        private void StartNextRound()
        {
            if (CurrentRoundType != PomodoroRoundType.Work) {
                StartWorkRound();
                return;
            }

            if (++nbWorkRoundDone % settings.NbWorkRoundBeforeLongBreak == 0) {
                StartLongBreakRound();
            } else {
                StartShortBreakRound();
            }
        }

        private void StartShortBreakRound()
        {
            TimeUntilEndOfTheRound = settings.ShortBreakRoundLength;
            CurrentRoundType = PomodoroRoundType.ShortBreak;
        }

        private void StartLongBreakRound()
        {
            TimeUntilEndOfTheRound = settings.LongBreakRoundLength;
            CurrentRoundType = PomodoroRoundType.LongBreak;
        }

        private void StartWorkRound()
        {
            TimeUntilEndOfTheRound = settings.WorkRoundLength;
            CurrentRoundType = PomodoroRoundType.Work;
        }

    }
}
